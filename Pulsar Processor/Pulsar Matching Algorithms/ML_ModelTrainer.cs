using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.TimeSeries;
using System.IO;

namespace Pulsar_Processor.Pulsar_Matching_Algorithms
{
    public class ML_ModelTrainer
    {
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "TrainingData.csv");
        MLContext mlContext = new MLContext();
        public static string dtr = "";
        IDataView MainTrainingData;

        public void Main()
        {
            MainTrainingData = mlContext.Data.LoadFromTextFile<SignalsDataInformation>(path: _dataPath, hasHeader: true, separatorChar: ',');
            int period = DetectPeriod(mlContext, MainTrainingData);
            DetectAnomaly(mlContext, MainTrainingData, period);
        }

        static int DetectPeriod(MLContext mlContext, IDataView signalData)
        {
            int period = mlContext.AnomalyDetection.DetectSeasonality(signalData, nameof(SignalsDataInformation.Value));
            Program.myHome.Log("Period of the series is: "+period.ToString()+" .");
            return period;
        }

        static void DetectAnomaly(MLContext mlContext, IDataView signalData, int period)
        {
            var options = new SrCnnEntireAnomalyDetectorOptions()
            {
                Threshold = 0.3,
                Sensitivity = 64.0,
                DetectMode = SrCnnDetectMode.AnomalyAndMargin,
                Period = period,
            };
            var outputDataView = mlContext.AnomalyDetection.DetectEntireAnomalyBySrCnn(signalData, nameof(PulsarPrediction.Prediction), nameof(SignalsDataInformation.Value), options);
            var predictions = mlContext.Data.CreateEnumerable<PulsarPrediction>(outputDataView, reuseRowObject: false);
            Program.myHome.Log("Index\tData\tAnomaly\tAnomalyScore\tMag\tExpectedValue\tBoundaryUnit\tUpperBoundary\tLowerBoundary");

            var index = 0;

            foreach (var p in predictions)
            {
                if (p.Prediction[0] == 1)
                {
                    dtr = dtr + (index.ToString()+","+p.Prediction[0].ToString()+","+ p.Prediction[3].ToString()+ ","+ p.Prediction[5].ToString()+ ","+ p.Prediction[6] + "  <-- alert is on, detecte anomaly") + Environment.NewLine;
                }
                else
                {
                    dtr = dtr + (index.ToString() + "," + p.Prediction[0].ToString() + "," + p.Prediction[3].ToString() + "," + p.Prediction[5].ToString() + "," + p.Prediction[6]) + Environment.NewLine;
                }
                ++index;

            }

            Program.myHome.Log(dtr);

        }
    }
}
