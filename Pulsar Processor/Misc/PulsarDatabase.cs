using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pulsar_Processor.Pulsar_Database;

namespace Pulsar_Processor.Misc
{
    public partial class PulsarDatabase : Form
    {
        public PulsarDatabase()
        {
            InitializeComponent();
        }

        private void PulsarDatabase_Load(object sender, EventArgs e)
        {
            DataTable myTable = new DataTable();
            DataColumn pulsarName = new DataColumn();
            pulsarName.ColumnName = "Pulsar Name";
            pulsarName.DataType = Type.GetType("System.String");
            pulsarName.Caption = "Pulsar Name";
            myTable.Columns.Add(pulsarName);
            DataColumn pulsarPeriod = new DataColumn();
            pulsarPeriod.ColumnName = "Pulsar Period";
            pulsarPeriod.DataType = Type.GetType("System.Double");
            pulsarPeriod.Caption = "Pulsar Period (s)";
            myTable.Columns.Add(pulsarPeriod);
            foreach(PulsarInformation n in PulsarDB.PulsarDatabase)
            {
                DataRow dr = myTable.NewRow();
                dr[0] = n.PulsarName;
                dr[1] = n.PulsarPeriod;
                myTable.Rows.Add(dr);
            }
            dataGridView1.DataSource = myTable;
        }
    }
}
