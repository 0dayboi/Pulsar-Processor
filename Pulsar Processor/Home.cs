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
using System.Threading;
using Pulsar_Processor.Pulsar_Matching_Algorithms;
using Pulsar_Processor.Pulsar_Matching_Algorithms.IID_Spike_Detector;

namespace Pulsar_Processor
{
    public partial class Home : Form
    {
        EpochFolding myEpoch = new EpochFolding();
        DateTime dt = new DateTime();
        public static string FileLoaded = "";
        public static string FileData = "";
        public static string[] DataChunks;
        public List<int> PossiblePeriods = new List<int>();
        public static List<double> DataChunks_Float = new List<double>();
        public static int CurrentPeriodTest = 0;
        Thread myEpochFolderThread;

        Trainer myModel = new Trainer();

        public Home()
        {
            InitializeComponent();
            Home.CheckForIllegalCrossThreadCalls = false;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Pulsar_Database.PulsarDB mc = new Pulsar_Database.PulsarDB();
            mc.AddPulsars();
            Log("Pulsar processor initiated..");
            if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Temp_DataPulsars")) == false)
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Temp_DataPulsars"));
            }
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
                        if (l != "0")
                        {
                            string makka = l.Replace('.', ',');
                            DataChunks_Float.Add(double.Parse(makka));
                        }
                       
                    }
                    catch
                    {
                        DataChunks_Float.Add(0);
                    }
                }
            }
            int sizeOfDatachunks = DataChunks_Float.Count;
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
        public void GETTER(string finality)
        {
            richTextBox1.Text = finality;
        }
        private void ChoosePeriod()
        {
            //Reducing the periods, to more possible ones.
            double gmc = DataChunks_Float.Count * 0.1;
            gmc = gmc / 100;
            for (int n = 0; n < PossiblePeriods.Count; n++)
            {
                if (PossiblePeriods[n] > gmc)
                {
                    PossiblePeriods.Remove(n);
                }
            }
            Random rn = new Random();
            int r = rn.Next(1, PossiblePeriods.Count);
            int CurrentPeriod = PossiblePeriods[r];
            PossiblePeriods.RemoveAt(r);
            CurrentPeriodTest = CurrentPeriod;
            Log("The choosen period is about " + CurrentPeriodTest + " bins");
        }

        private void LaunchEpochFolder()
        {
            ThreadStart starter = myEpoch.EXTRACT_PULSAR;
            starter += () => {//Thread callback.
                Program.myHome.Log("Folding completed, thread aborted, starting the spike filtering");
                SaveFoldedSignalData();
                StartAI();
            };
            myEpochFolderThread = new Thread(starter);
            myEpochFolderThread.Name = "Epoch folding thread";
            myEpochFolderThread.Priority = ThreadPriority.Highest;
            myEpochFolderThread.IsBackground = true;
            myEpochFolderThread.Start();
          
        }

        private void SaveFoldedSignalData()
        {
            string folded_data = richTextBox1.Text;
            string path_to_current = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Temp_DataPulsars", "CompleteFoldedPulsar.csv");
            File.WriteAllText(path_to_current, folded_data);
            Log("Data saved");
        }

        private void StartAI()
        {
            ThreadStart starter = myModel.EntryMain;
            starter += () => {//Thread callback.
                Program.myHome.Log("Folding completed, thread aborted, starting the spike filtering");
                
            };
            Thread myThe = new Thread(starter);
            myThe.Priority = ThreadPriority.Normal;
            myThe.IsBackground = true;
            myThe.Start();
        }

        #endregion


        #region UI_Misc

   

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
            LaunchEpochFolder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartAI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpikeDataFilter mySpikeFilter = new SpikeDataFilter();
           // mySpikeFilter.FilterSpikesFromIID();
        }

        #endregion

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
