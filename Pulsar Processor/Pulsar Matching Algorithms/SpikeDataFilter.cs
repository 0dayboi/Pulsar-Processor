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
        public void FilterSpikesFromIID(List<SpikeInformation> MySpikes)
        {

            List<int> DeltaSampleIndex = new List<int>();
            Dictionary<int, int> SampleDistanceDatabase = new Dictionary<int, int>();//The Key is used for delta sample, and the Value is used for the counts of repition

            int index = 1;

            try
            {
                while (Trainer.SpikeData[index] != null)
                {
                    if (Trainer.SpikeData.Count != (index - 1))
                    {        
                        int initial = Trainer.SpikeData[index - 1].SampleIndex;
                        int final = Trainer.SpikeData[index].SampleIndex;
                        int Difference = final - initial;
                        DeltaSampleIndex.Add(Difference);
                        index++;
                    }else
                    {
                        break;
                    }
                }
            }
            catch
            {
                ;
            }


            //After we have calculated sample distances from the pulses, its time to find the most repeated sample distance.

            foreach(int i in DeltaSampleIndex)
            {
                if (i > 3)
                {
                    int c = 0;
                    if (SampleDistanceDatabase.TryGetValue(i, out c) == true)
                    {
                        SampleDistanceDatabase[i] = SampleDistanceDatabase[i] + 1;
                    }else
                    {
                        SampleDistanceDatabase.Add(i, 1);
                    }
                }
            }

            //After we have counted the distance period repition, its time to filter the highest score.

             int WinnerPeriod = 0;
             int WinnersCounts = 0;
             List<int> listNumber = SampleDistanceDatabase.Keys.ToList();
                foreach(int k in listNumber)
                {
                    if (SampleDistanceDatabase[k] > WinnersCounts)
                    {
                        WinnersCounts = SampleDistanceDatabase[k];
                        WinnerPeriod = k;
                    }
                }

               
            Program.myHome.Log("finished filtering, Choosen final pulsating period in samples is : " + WinnerPeriod.ToString());
            Program.myHome.Log("Calculating the period in seconds.. ");

            double chamron_sampling_time = (468.11429) / 1000000;
            double period_in_seconds = WinnerPeriod * chamron_sampling_time;
            double upper_fix = period_in_seconds + 0.05;
            double lower_fix = period_in_seconds - 0.05;
            Program.myHome.Log("PULSAR PROCESING FINISHED");
            Program.myHome.Log("final period is " + period_in_seconds.ToString() + " seconds, upper fix is " + upper_fix.ToString() + " seconds, and lower fix is " + lower_fix.ToString());

        }
    }
}
