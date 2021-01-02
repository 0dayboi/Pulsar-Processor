using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar_Processor.Pulsar_Matching_Algorithms
{
    public class MatchInformation
    {
        public string PulsarName { get; set; }
        public double ActualPeriod { get; set; }
        public double ErrorMargin { get; set; }
    }
    public class MatcherAlgorithm
    {
        const double toleranceLevel = 5; // 5% 
        public void Match(double Normal, double Upper, double Lower)
        {
            List<MatchInformation> Pulsars = new List<MatchInformation>();
            double Tol = (Upper * 5) / 100;
            double range = Upper + Tol;

            foreach (Pulsar_Database.PulsarInformation ps in Pulsar_Database.PulsarDB.PulsarDatabase)
            {
                if (ps.PulsarPeriod <= range && ps.PulsarPeriod >= Normal)
                {
                    double ErrorMargin = Math.Abs(ps.PulsarPeriod - range);
                    MatchInformation mtch = new MatchInformation();
                    mtch.ActualPeriod = ps.PulsarPeriod;
                    mtch.ErrorMargin = ErrorMargin;
                    mtch.PulsarName = ps.PulsarName;
                    Pulsars.Add(mtch);
                    Program.myHome.Log("Pulsar match found, Name: " + mtch.PulsarName + " Error Margin: " + mtch.ErrorMargin.ToString() + " Actual period: " + mtch.ActualPeriod.ToString());
                }
            }

            
        }
    }
}
