using ConvNetSharp.Core;
using ConvNetSharp.Core.Serialization;
using MnistDemo;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace MLRecognitionDiploma;

public partial class Form1 : Form
{
    private Net<double> _net;

    public Form1()
    {
        InitializeComponent();
    }

    private void вибратиToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var fileDialog = new OpenFileDialog();
        if (fileDialog.ShowDialog() == DialogResult.Cancel)
            return;

        string filename = fileDialog.FileName;

        var bytes = File.ReadAllBytes(filename);

        pictureBox1.Image = new Bitmap(new MemoryStream(bytes));
    }

    private void button1_Click(object sender, EventArgs e)
    {
        using var ms = new MemoryStream();
        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);

        var dataSet = new DataSet(new List<MnistEntry>
        {
            new MnistEntry
            {
                Image = ms.ToArray()
            }
        });
        _net.Forward(dataSet.GetDataVolume(1));
        var predictions = _net.GetPrediction();

        textBox3.Text = JsonConvert.SerializeObject(predictions);
    }

    private void імпортуватиМодельToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var fileDialog = new OpenFileDialog();
        if (fileDialog.ShowDialog() == DialogResult.Cancel)
            return;

        string filename = fileDialog.FileName;

        var json = File.ReadAllText(filename);
        var deserialized = SerializationExtensions.FromJson<double>(json);

        _net = deserialized;
}
}