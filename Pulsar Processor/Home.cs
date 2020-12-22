﻿using System;
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
        public static List<int> PossiblePeriods = new List<int>();
        public static List<float> DataChunks_Float = new List<float>();
        public static int CurrentPeriodTest = 0;

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Log("Pulsar processor initiated..");
        }

        #region Basic Data Processing

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
            if (DataChunks_Float.Count < 5)
            {
                List<string> ms = DataChunks.ToList<string>();
                foreach (string l in DataChunks)
                {
                    try
                    {
                        DataChunks_Float.Add(float.Parse(l));
                    }
                    catch
                    {
                        DataChunks_Float.Add(0);
                    }
                }
            }

            int sizeOfDatachunks = DataChunks.Length;
            PossiblePeriods = new List<int>();
            for (int i = 2; i < sizeOfDatachunks; i++)
            {
                float temp = sizeOfDatachunks % i;//To see if there is a remainder.
                if (temp == 0)
                {
                    Log("At x=" + i.ToString() + ", is a possible period.");
                    PossiblePeriods.Add(i);
                }
            }

            FixPeriods();
        }

        private void FixPeriods()//This code will fix the period data by adding random values to fullfill the epoch folding.
        {
            if (PossiblePeriods.Count == 0)
            {
                Log("No possible period was found, fixing...");
                Random rn = new Random();
                int k = rn.Next(0, 90);
                DataChunks_Float.Add(float.Parse(k.ToString()));
                Log("Tried to add noise stuff for fixing our periods. Retrying");
                locatePossiblePeriods();
            }
        }

        private void ChoosePeriod()
        {
            Random rn = new Random();
            int r = rn.Next(1, PossiblePeriods.Count);
            int CurrentPeriod = PossiblePeriods[r];
            PossiblePeriods.RemoveAt(r);
            CurrentPeriodTest = CurrentPeriod;
            Log("The choosen period is about " + CurrentPeriodTest + " bins");
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
            locatePossiblePeriods();
            Log("Choosing the period to perform folding...");
            ChoosePeriod();
            Log("Starting the folding procces on a seperate unsafe thread..");
        }
    }
}
