using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar_Processor.Pulsar_Database
{
    /// <summary>
    /// Information for the known pulsars was obtained from "PULSAR OBSERVATIONS USING THE FIRST STATION OF THE LONG WAVELENGTH ARRAY AND THE LWA PULSAR DATA ARCHIVE"
    /// Published on arXiv.org.
    /// Credits: K. Stovall, P. S. Ray, J. Blythe, J. Dowell, T. Eftekhari, A. Garcia, T. J. W. Lazio, M. McCrackan,F. K. Schinzel, G.B.Taylor
    /// Document published on August 14, 2018.
    /// </summary>
    public class PulsarInformation
    {
        public string PulsarName { get; set; }
        public double PulsarPeriod { get; set; }
    }
    public class PulsarDB
    {
        public static List<PulsarInformation> PulsarDatabase = new List<PulsarInformation>();//The pulsar database list.

        public void AddPulsars()
        {
            string data = Pulsar_Processor.Properties.Resources.PulsarDatabase_CSV;
            char[] NewLine = Environment.NewLine.ToCharArray();
            string[] Rows = data.Split(NewLine);
            foreach (string r in Rows)
            {
                if (r.Length > 1)
                {
                    string[] PulsarInformation = r.Split(';');
                    PulsarInformation newPulsar = new PulsarInformation();
                    newPulsar.PulsarName = PulsarInformation[0];
                    newPulsar.PulsarPeriod = (double.Parse(PulsarInformation[1])/10000);
                    PulsarDatabase.Add(newPulsar);  
                }
            }
        }
    }
}
