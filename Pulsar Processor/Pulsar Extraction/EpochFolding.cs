using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar_Processor
{
    /// <summary>
    /// This script will perform epoch folding on the discrete time domain of our main pulsar observatory signal.
    /// </summary>
    public class EpochFolding
    {
        public void EXTRACT_PULSAR()
        {
            Program.myHome.Log("Epoch folding proccess starting with " + Home.CurrentPeriodTest + " bins, which will result on a signal with final " + (Home.DataChunks_Float.Count / Home.CurrentPeriodTest).ToString() + " samples");
            //Actual folding start
            List<float> FoldedSignal = new List<float>();
            int SamplesPerBin = (Home.DataChunks_Float.Count / Home.CurrentPeriodTest);
            for(int z = 0; z < SamplesPerBin; z++) { FoldedSignal.Add(Home.DataChunks_Float[z]); }
            float[] temp_ = FoldedSignal.ToArray<float>();
            int second_index = 0;
            for (int x = 1; x < Home.CurrentPeriodTest; x++)
            {
                    for (int n = 0; n < SamplesPerBin; n++)
                    {
                        temp_[n] = Home.DataChunks_Float[second_index];
                        second_index++;
                    }
                    if (x != 1)
                    {   
                        for (int i = 0; i < SamplesPerBin; i++)//int x = 0; x < Home.CurrentPeriodTest; x++
                        {
                            FoldedSignal[i] += temp_[i]; 
                            //final_sample_datalet += Home.DataChunks_Float[sample_index];
                            //sample_index = sample_index + SamplesPerBin;
                        }
                    }
                /*FoldedSignal.Add(final_sample_datalet);*/
            }
            Program.myHome.Log("Folding completed. Folding length " + FoldedSignal.Count.ToString());
            string finality = "";
            foreach(float c in FoldedSignal)
            {
                float k = c / 100;
                finality = finality + Environment.NewLine + k.ToString();
            }
            Program.myHome.GETTER(finality);
        }

    }
}
