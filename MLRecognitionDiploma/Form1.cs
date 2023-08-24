using Microsoft.ML;
using Microsoft.ML.Vision;
using MLRecognitionDiploma.Models;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace MLRecognitionDiploma;

public partial class Form1 : Form
{
    private static readonly string _predictedLabelColumnName = "PredictedLabel";
    private static readonly string _keyColumnName = "LabelAsKey";
    private List<Point> points = new List<Point>();

    private bool _isMouseDown = false;
    private Bitmap _image;
    private Graphics _graphics;
    private Pen _pen;

    public Form1()
    {
        InitializeComponent();

        _pen = new Pen(Color.Black, 5);
        _pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        _pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        _image = new Bitmap(1000, 1000);
        _graphics = Graphics.FromImage(_image);

        _graphics.Clear(Color.White);
        pictureBox1.Image = _image;
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        _isMouseDown = true;
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        _isMouseDown = false;
        points.Clear();
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (!_isMouseDown) { return; }
        if (points.Count < 2)
        {
            points.Add(new Point(e.X, e.Y));
            return;
        }

        points.Add(new Point(e.X, e.Y));

        _graphics.DrawLines(_pen, points.ToArray());

        pictureBox1.Image = _image;
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void вибратиToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void згеренуватиКартинкиДляТренуванняToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Directory.CreateDirectory("TrainingImages");
        var alphabet = new List<string>
        {
            "A",
            "B", "C",
            //"D", "E", "F", "G", "H", "I", "J",
            //"K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            //"U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
            //"k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
            //"u", "v", "w", "x", "y", "z",
            //"1", "2", "3", "4", "5", "6","7", "8", "9", "0"
        };

        var bitmap = new Bitmap(1000, 1000);
        var graphics = Graphics.FromImage(bitmap);

        var installedFontCollection = new InstalledFontCollection();

        foreach (var element in alphabet)
        {
            Directory.CreateDirectory($"TrainingImages/{element}");
            var imageCount = 0;
            foreach (var fontFamily in installedFontCollection.Families.Take(100))
            {
                graphics.Clear(Color.White);
                graphics.DrawString(element, new Font(fontFamily, 400), Brushes.Black, 100, 100);

                bitmap.Save($"TrainingImages/{element}/{element}_{imageCount}.png", ImageFormat.Png);

                imageCount++;
            }
        }
    }

    private void тренуватиМодельToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var context = new MLContext(seed: 0);

        var imagesInput = new List<ImageInputModel>();
        var directories = Directory.EnumerateDirectories("TrainingImages");

        foreach (var directory in directories)
        {
            var files = Directory.EnumerateFiles(directory);

            imagesInput.AddRange(files.Select(x => new ImageInputModel
            {
                ImagePath = Path.GetFullPath(x),
                Label = Path.GetFileName(directory)
            }));
        }

        var data = context.Data.LoadFromEnumerable(imagesInput);
        data = context.Data.ShuffleRows(data);

        // Load the images and convert the labels to keys to serve as categorical values
        var images = context.Transforms.Conversion.MapValueToKey(inputColumnName: nameof(ImageInputModel.Label), outputColumnName: _keyColumnName)
            .Append(context.Transforms.LoadRawImageBytes(inputColumnName: nameof(ImageInputModel.ImagePath), outputColumnName: nameof(ImageInputModel.Image), imageFolder: "TrainingImages"))
            .Fit(data).Transform(data);

        // Split the dataset for training and testing
        var trainTestData = context.Data.TrainTestSplit(images, testFraction: 0.2, seed: 1);
        var trainData = trainTestData.TrainSet;
        var testData = trainTestData.TestSet;

        // Create an image-classification pipeline and train the model
        var options = new ImageClassificationTrainer.Options()
        {
            FeatureColumnName = nameof(ImageInputModel.Image),
            LabelColumnName = _keyColumnName,
            ValidationSet = testData,
            Arch = ImageClassificationTrainer.Architecture.ResnetV2101, // Pretrained DNN
            MetricsCallback = (metrics) => Console.WriteLine(metrics),
            TestOnTrainSet = false
        };

        var pipeline = context.MulticlassClassification.Trainers.ImageClassification(options)
            .Append(context.Transforms.Conversion.MapKeyToValue(_predictedLabelColumnName));

        Console.WriteLine("Training the model...");
        var model = pipeline.Fit(trainData);

        // Evaluate the model and show the results
        var predictions = model.Transform(testData);
        var metrics = context.MulticlassClassification.Evaluate(predictions, labelColumnName: _keyColumnName, predictedLabelColumnName: _predictedLabelColumnName);

        textBox1.Text = $"Macro accuracy = {metrics.MacroAccuracy:P2}";
        textBox2.Text = $"Micro accuracy = {metrics.MicroAccuracy:P2}";
        textBox3.Text = metrics.ConfusionMatrix.GetFormattedConfusionTable();

        context.Model.Save(model, trainData.Schema, "MLModel.zip");
    }
}