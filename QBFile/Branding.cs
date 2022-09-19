using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using QBFile.Classes;

namespace QBFile
{
    public partial class Branding : Form
    {
        ClassQuery clsque = new ClassQuery();

        public Branding()
        {
            InitializeComponent();
        }

        private void Branding_Load(object sender, EventArgs e)
        {
            clsque.LoadDGVClass();
            dgvbranding.DataSource = clsque.dtbrand;
            dgvbranding.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvbranding.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OleDbCommandBuilder cmdbldr;
            cmdbldr = new OleDbCommandBuilder(clsque.ldbrand);
            clsque.ldbrand.Update(clsque.dtbrand);
            MessageBox.Show("Successfully updated!");
            this.Dispose();
        }
    }
}
