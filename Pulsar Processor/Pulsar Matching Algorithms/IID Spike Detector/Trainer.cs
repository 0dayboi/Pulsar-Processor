using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.TimeSeries;
using System.IO;


namespace Pulsar_Processor.Pulsar_Matching_Algorithms.IID_Spike_Detector
{
    public class Trainer
    {
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "CompleteFoldedPulsar.csv");
        //assign the Number of records in dataset file to constant variable
        const int _docsize = 74321;

        MLContext mlContext = new MLContext();

        IDataView dataView;

        public static List<SpikeInformation> SpikeData = new List<SpikeInformation>();

        public void EntryMain()
        {
            dataView= mlContext.Data.LoadFromTextFile<SignalInformation>(path: _dataPath, hasHeader: false, separatorChar: ';');
            DetectSpike(mlContext, _docsize, dataView);
        }

        static void DetectSpike(MLContext mlContext, int docSize, IDataView signalView)
        {
            var iidSpikeEstimator = mlContext.Transforms.DetectIidSpike(outputColumnName: nameof(PulsePrediction.Prediction), inputColumnName: nameof(SignalInformation.value), confidence: 95, pvalueHistoryLength: docSize / 4);
            ITransformer iidSpikeTransform = iidSpikeEstimator.Fit(CreateEmptyDataView(mlContext));
            IDataView transformedData = iidSpikeTransform.Transform(signalView);
            var predictions = mlContext.Data.CreateEnumerable<PulsePrediction>(transformedData, reuseRowObject: false);
            Program.myHome.Log("Alert\tScore\tP-Value");
            string mrk = "";
            int sampleIndex = 1;
            foreach (var p in predictions)
            {
                var results = $"{p.Prediction[0]}\t{p.Prediction[1]:f2}\t{p.Prediction[2]:F2}";

                if (p.Prediction[0] == 1)
                {
                    SpikeInformation newSpike = new SpikeInformation();
                    newSpike.SampleIndex = sampleIndex;
                    newSpike.SampleValue = p.Prediction[1];
                    SpikeData.Add(newSpike);
                    Program.myHome.Log("Spike Loaded");
                }
                sampleIndex++;
            }
            
        }

        static IDataView CreateEmptyDataView(MLContext mlContext)
        {
            // Create empty DataView. We just need the schema to call Fit() for the time series transforms
            IEnumerable<SignalInformation> enumerableData = new List<SignalInformation>();
            return mlContext.Data.LoadFromEnumerable(enumerableData);
        }

    }
}
