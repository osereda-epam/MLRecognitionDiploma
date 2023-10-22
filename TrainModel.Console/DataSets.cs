using System;
using System.IO;
using System.Net;

namespace MnistDemo
{
    internal class DataSets
    {
        private const string urlMnist = @"https://rds.westernsydney.edu.au/Institutes/MARCS/BENS/EMNIST/emnist-gzip.zip";
        private const string mnistFolder = @"..\Emnist\";
        private const string trainingLabelFile = "emnist-byclass-train-labels-idx1-ubyte.gz";
        private const string trainingImageFile = "emnist-byclass-train-images-idx3-ubyte.gz";
        private const string testingLabelFile = "emnist-byclass-test-labels-idx1-ubyte.gz";
        private const string testingImageFile = "emnist-byclass-test-images-idx3-ubyte.gz";

        public DataSet Train { get; set; }

        public DataSet Validation { get; set; }

        public DataSet Test { get; set; }

        public bool Load(int validationSize = 1000)
        {
            Directory.CreateDirectory(mnistFolder);

            var trainingLabelFilePath = Path.Combine(mnistFolder, trainingLabelFile);
            var trainingImageFilePath = Path.Combine(mnistFolder, trainingImageFile);
            var testingLabelFilePath = Path.Combine(mnistFolder, testingLabelFile);
            var testingImageFilePath = Path.Combine(mnistFolder, testingImageFile);

            // Load data
            Console.WriteLine("Loading the datasets...");
            var train_images = MnistReader.Load(trainingLabelFilePath, trainingImageFilePath).ToList();
            var testing_images = MnistReader.Load(testingLabelFilePath, testingImageFilePath).ToList();

            var max = train_images.MaxBy(t => t.Label);

            var valiation_images = train_images.GetRange(train_images.Count - validationSize, validationSize);
            train_images = train_images.GetRange(0, train_images.Count - validationSize);

            if (train_images.Count == 0 || valiation_images.Count == 0 || testing_images.Count == 0)
            {
                Console.WriteLine("Missing Mnist training/testing files.");
                Console.ReadKey();
                return false;
            }

            this.Train = new DataSet(train_images);
            this.Validation = new DataSet(valiation_images);
            this.Test = new DataSet(testing_images);

            return true;
        }
    }
}