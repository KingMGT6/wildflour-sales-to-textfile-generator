using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QBFile.Classes;

namespace QBFile
{
    public partial class Mapping : Form
    {
        ClassQuery clsq = new ClassQuery();

        public Mapping()
        {
            InitializeComponent();
        }

        private void Mapping_Load(object sender, EventArgs e)
        {
            clsq.LoadDGVMOP();
            dgvMOP.DataSource = clsq.dtmop;
            dgvMOP.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMOP.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            clsq.RMLoadDGVMOP();
            dgvrmmop.DataSource = clsq.rmdtmop;
            dgvrmmop.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvrmmop.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            clsq.LoadDGVCAT();
            dgvCategory.DataSource = clsq.dtcat;
            dgvCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCategory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            clsq.RMLoadDGVCAT();
            dgvrmcat.DataSource = clsq.rmdtcat;
            dgvrmcat.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvrmcat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OleDbCommandBuilder cmdbldr;
            cmdbldr = new OleDbCommandBuilder(clsq.ldmop);
            clsq.ldmop.Update(clsq.dtmop);

            cmdbldr = new OleDbCommandBuilder(clsq.ldcat);
            clsq.ldcat.Update(clsq.dtcat);
            MessageBox.Show("Successfully Updated!");
            this.Dispose();
        }
    }
}
