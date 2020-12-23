using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pulsar_Processor
{
    public static class Program
    {
        public static Home myHome = new Home();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(myHome);

        }
    }
}
