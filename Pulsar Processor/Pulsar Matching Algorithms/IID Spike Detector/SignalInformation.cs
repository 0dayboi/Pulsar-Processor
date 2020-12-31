using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;


namespace Pulsar_Processor.Pulsar_Matching_Algorithms.IID_Spike_Detector
{
    public class SignalInformation
    {
        [LoadColumn(0)]
        public string SampleIndex;

        [LoadColumn(1)]
        public float value;
    }

    public class PulsePrediction
    {
        //vector to hold alert,score,p-value values
        [VectorType(3)]
        public double[] Prediction { get; set; }
    }

    public class SpikeInformation
    {
        public int SampleIndex { get; set; }
        public double SampleValue { get; set; }
    }
}
