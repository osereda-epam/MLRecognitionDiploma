﻿using ConvNetSharp.Core;
using ConvNetSharp.Core.Layers.Double;
using ConvNetSharp.Core.Serialization;
using ConvNetSharp.Core.Training;
using ConvNetSharp.Volume;

namespace MnistDemo
{
    internal class Program
    {
        private readonly CircularBuffer<double> _testAccWindow = new CircularBuffer<double>(100);
        private readonly CircularBuffer<double> _trainAccWindow = new CircularBuffer<double>(100);
        private Net<double> _net;
        private int _stepCount;
        private SgdTrainer<double> _trainer;

        private static void Main()
        {
            var program = new Program();
            program.MnistDemo();
        }

        private void MnistDemo()
        {
            var datasets = new DataSets();
            if (!datasets.Load(100))
            {
                return;
            }

            // Create network
            this._net = new Net<double>();
            this._net.AddLayer(new InputLayer(28, 28, 1));
            this._net.AddLayer(new ConvLayer(5, 5, 8) { Stride = 1, Pad = 2 });
            this._net.AddLayer(new ReluLayer());
            this._net.AddLayer(new PoolLayer(2, 2) { Stride = 2 });
            this._net.AddLayer(new ConvLayer(5, 5, 16) { Stride = 1, Pad = 2 });
            this._net.AddLayer(new ReluLayer());
            this._net.AddLayer(new PoolLayer(3, 3) { Stride = 3 });
            this._net.AddLayer(new FullyConnLayer(62));
            this._net.AddLayer(new SoftmaxLayer(62));

            this._trainer = new SgdTrainer<double>(this._net)
            {
                LearningRate = 0.01,
                BatchSize = 1024,
                Momentum = 0.9
            };

            Console.WriteLine("Convolutional neural network learning...[Press any key to stop]");
            do
            {
                var trainSample = datasets.Train.NextBatch(this._trainer.BatchSize);
   
                Train(trainSample.Item1, trainSample.Item2, trainSample.Item3);

                var testSample = datasets.Test.NextBatch(this._trainer.BatchSize);
                Test(testSample.Item1, testSample.Item3, this._testAccWindow);

                Console.WriteLine("Loss: {0} Train accuracy: {1}% Test accuracy: {2}%", this._trainer.Loss,
                    Math.Round(this._trainAccWindow.Items.Average() * 100.0, 2),
                    Math.Round(this._testAccWindow.Items.Average() * 100.0, 2));

                Console.WriteLine("Example seen: {0} Fwd: {1}ms Bckw: {2}ms", this._stepCount,
                    Math.Round(this._trainer.ForwardTimeMs, 2),
                    Math.Round(this._trainer.BackwardTimeMs, 2));
            } while (!Console.KeyAvailable);


            var json = _net.ToJson();

            File.WriteAllText(@"NeuralNetwork.json", json);
        }

        private void Test(Volume<double> x, int[] labels, CircularBuffer<double> accuracy, bool forward = true)
        {
            if (forward)
            {
                this._net.Forward(x);
            }

            var prediction = this._net.GetPrediction();

            for (var i = 0; i < labels.Length; i++)
            {
                accuracy.Add(labels[i] == prediction[i] ? 1.0 : 0.0);
            }
        }

        private void Train(Volume<double> x, Volume<double> y, int[] labels)
        {
            this._trainer.Train(x, y);

            Test(x, labels, this._trainAccWindow, false);

            this._stepCount += labels.Length;
        }
    }
}