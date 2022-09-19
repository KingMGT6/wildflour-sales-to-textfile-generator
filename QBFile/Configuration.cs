using System;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;
using QBFile.Classes;

namespace QBFile
{
    public partial class Configuration : Form
    {
        ClassQuery clsquery = new ClassQuery();

        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            clsquery.LoadConfigurations();

            clsquery.GetClassDesc();
            cmbstore.DisplayMember = "classdesc";
            cmbstore.DataSource = clsquery.dsclsdesc.Tables[0];

            clsquery.GetClassCust();
            cmbdesc.DisplayMember = "classcustomer";
            cmbdesc.DataSource = clsquery.dsclscust.Tables[0];

            txtbranchname.Text = clsquery.branchdesc;
            cmbstore.Text = clsquery.clsdesc;
            cmbdesc.Text = clsquery.clscust;
            txtrmwinpath.Text = clsquery.rmpath;
            txtfolderpath.Text = clsquery.folderpath;
        }

        private void btnrmwinfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdRM = new FolderBrowserDialog();
            fbdRM.ShowDialog();
            if(fbdRM.SelectedPath != null)
            {
                txtrmwinpath.Text = fbdRM.SelectedPath.ToString();
            }
        }

        private void btnsavefolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdSF = new FolderBrowserDialog();
            fbdSF.ShowDialog();
            if(fbdSF.SelectedPath != null)
            {
                txtfolderpath.Text = fbdSF.SelectedPath.ToString();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            clsquery.UpdateConfig("@branchname", OleDbType.Char, 100, "branchname", txtbranchname.Text);
            clsquery.UpdateConfig("@class_desc", OleDbType.Char, 100, "class_desc", cmbstore.Text);
            clsquery.UpdateConfig("@class_cust", OleDbType.Char, 100, "class_cust", cmbdesc.Text);
            clsquery.UpdateConfig("@rmwinpath", OleDbType.Char, 100, "rmwinpath", txtrmwinpath.Text);
            clsquery.UpdateConfig("@folderpath", OleDbType.Char, 100, "folderpath", txtfolderpath.Text);
            MessageBox.Show("Successfully updated!");
            this.Dispose();
        }
    }
}
