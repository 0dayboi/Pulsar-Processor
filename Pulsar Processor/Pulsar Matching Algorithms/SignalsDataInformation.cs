using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace Pulsar_Processor.Pulsar_Matching_Algorithms
{
    /// <summary>
    /// This file will hold the data point containers.
    /// </summary>
    public class SignalsDataInformation
    {
        [LoadColumn(0)]
        public string SampleIndex;

        [LoadColumn(1)]
        public double Value;
    }

    public class PulsarPrediction
    {
        //vector to hold anomaly detection results. Including isAnomaly, anomalyScore, magnitude, expectedValue, boundaryUnits, upperBoundary and lowerBoundary.
        [VectorType(7)]
        public double[] Prediction { get; set; }
    }
}
