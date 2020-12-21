using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pulsar_Processor
{
    public partial class Home : Form
    {
        DateTime dt = new DateTime();
        public static string FileLoaded = "";
        public static string FileData = "";
        public static string[] DataChunks;
        public static int[] PossiblePeriods;

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Log("Pulsar processor initiated..");
        }


        #region MISC

        public void Log(string ks)
        {
            dt = DateTime.Now;
            string dateAndTime = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString() + " " + dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString();
            richTxtBox_Console.Text = richTxtBox_Console.Text + Environment.NewLine + "@" + dateAndTime + "|> " + ks; 
        }

        private void ReadFile()
        {
            if (FileLoaded.Length < 2)
            {
                MessageBox.Show("Please input possible pulsar data");
                Log("Pulsar processing exited due to no data provided...");
            }else
            {
               FileData = File.ReadAllText(FileLoaded);
               Log("Temporary data has been stored in memory, loaded succesfully. Total size: " + FileData.Length.ToString());
               Log("Data reading process finished.");
            }

        }

        private void splitDataIntoArray()
        {
            DataChunks = FileData.Split(',');
            Log("Array splitted into " + DataChunks.Length.ToString() + " chunks");
        }
        
        private void locatePossiblePeriods()
        {

        }

        private void FixPeriods()//This code will fix the period data by adding random values to fullfill the epoch folding.
        {

        }

        private void TryPeriod()
        {
            
        }

        #endregion

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
        }

        private void fileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FileLoaded = fileDialog.FileName;
            txtBox_Filepath.Text = FileLoaded;
        }

        private void btnStartPulsarProcessing_Click(object sender, EventArgs e)
        {
            Log("Pulsar processing is starting...");
            Log("Inititating file buffering..");
            ReadFile();
            Log("Chopping data into array");
            splitDataIntoArray();
            Log("Trying to find accurate period of pulsars");

        }
    }
}
