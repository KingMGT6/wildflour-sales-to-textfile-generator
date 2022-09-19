using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QBFile.Classes;
using System.Data.OleDb;

namespace QBFile
{
    public partial class FileCreation : Form
    {
        public string rmconnect;
        public OleDbCommand cmdcat;
        public OleDbCommand cmdmop;
        public OleDbCommand cmdoos;

        public FileCreation()
        {
            InitializeComponent();

            ClassQuery cq = new ClassQuery();
            cq.LoadConfigurations();

            rmconnect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + cq.rmpath +
                       ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
        }

        private void FileCreation_Load(object sender, EventArgs e)
        {
            ClassConn cc = new ClassConn();
            cc.openConn();
            cmdmop = new OleDbCommand("Delete from tblSaveMOP", cc.con);
            cmdmop.ExecuteNonQuery();
            cmdcat = new OleDbCommand("Delete from tblSaveCat", cc.con);
            cmdcat.ExecuteNonQuery();
            cmdoos = new OleDbCommand("Delete from tblOvershort", cc.con);
            cmdoos.ExecuteNonQuery();
            cc.closeConn();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            GetSess();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
             if (lblsesfrom.Text != "0" && lblsesto.Text != "0")
             {
                    btnCreate.Enabled = false;
                    DateTime sfrom, efrom;
                    sfrom = dateTimePicker1.Value;
                    efrom = dateTimePicker2.Value;
                if (sfrom <= efrom)
                {
                    //prgbrData.Maximum = Convert.ToInt32((efrom - sfrom).TotalDays + 1);
                    //do
                    //{
                        Application.DoEvents();
                        lblstatus.Text = sfrom.ToString("MM/dd/yyyy") + " - " + efrom.ToString("MM/dd/yyyy");
                        ClassData cdata = new ClassData();
                        cdata.datestart = sfrom.ToShortDateString();
                        cdata.dateend = efrom.ToShortDateString();
                        cdata.GetSession();
                    //prgbrData.Value = prgbrData.Value + 1;
                    //sfrom = sfrom.AddDays(1);

                    ClassConn cc = new ClassConn();
                    cc.openConn();
                    cmdmop = new OleDbCommand("Delete from tblSaveMOP", cc.con);
                    cmdmop.ExecuteNonQuery();
                    cmdcat = new OleDbCommand("Delete from tblSaveCat", cc.con);
                    cmdcat.ExecuteNonQuery();
                    cmdoos = new OleDbCommand("Delete from tblOvershort", cc.con);
                    cmdoos.ExecuteNonQuery();
                    cc.closeConn();

                    //}
                    //while (sfrom <= efrom);
                    prgbrData.Maximum = 99;
                    prgbrData.Value = 99;

                    MessageBox.Show("Process Complete!");
                    lblstatus.Text = "00/00/0000";
                    prgbrData.Value = 0;
                    btnCreate.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Date Start must not more than Date End!", "Please select again.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             }
             else
             {
                MessageBox.Show("No Session Details found!", "Please select again.", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetSess();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            GetSess();
        }

        //Getting session #
        public void GetSess()
        {
            Int32 sessnum;
            Int32 sessnum1;

            using (OleDbConnection rmconn = new OleDbConnection(rmconnect))
            {
                rmconn.Open();
                //Session from
                OleDbCommand oleCmd = new OleDbCommand("SELECT SESSION_NO, first_bill, last_bill FROM REP" + dateTimePicker1.Value.ToString("yy") +
                                                     " WHERE date_start = #" + dateTimePicker1.Value.ToShortDateString() + "# and first_bill > 0 and last_bill > 0", rmconn);
                OleDbDataReader dbdr = oleCmd.ExecuteReader();
                if (dbdr.HasRows)
                {
                    dbdr.Read();
                    sessnum = Convert.ToInt32(dbdr.GetValue(0).ToString());
                    lblsesfrom.Text = sessnum.ToString();
                }
                else
                {
                    lblsesfrom.Text = "0";
                }
                //Session to
                OleDbCommand oleCmd1 = new OleDbCommand("SELECT SESSION_NO, first_bill, last_bill FROM REP" + dateTimePicker2.Value.ToString("yy") +
                                                     " WHERE date_start = #" + dateTimePicker2.Value.ToShortDateString() + "# and first_bill > 0 and last_bill > 0", rmconn);
                OleDbDataReader dbdr1 = oleCmd1.ExecuteReader();
                if (dbdr1.HasRows)
                {
                    dbdr1.Read();
                    sessnum1 = Convert.ToInt32(dbdr1.GetValue(0).ToString());
                    lblsesto.Text = sessnum1.ToString();
                }
                else
                {
                    lblsesto.Text = "0";
                }
            }
        }

    }
}
