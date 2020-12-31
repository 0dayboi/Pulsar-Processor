using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pulsar_Processor.Pulsar_Matching_Algorithms.IID_Spike_Detector;

namespace Pulsar_Processor.Pulsar_Matching_Algorithms
{
    public class SpikeDataFilter
    {
        public void FilterSpikesFromIID()
        {

            List<int> DeltaSampleIndex = new List<int>();

            //foreach (SpikeInformation s in Trainer.SpikeData)//Filtering out the noise from the data
            //{
            //    if (s.SampleValue < 1200)
            //    {
            //        Trainer.SpikeData.Remove(s);
            //    }
            //}

            int index = 0;

            while (Trainer.SpikeData[index + 1] != null)
            {
                int initial = Trainer.SpikeData[index].SampleIndex;
                int final = Trainer.SpikeData[index + 1].SampleIndex;
                int Difference = final - initial;
                DeltaSampleIndex.Add(Difference);
                index++;
            }

            Program.myHome.Log("finished filtering");
        }
    }
}
