using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBFile
{
    public partial class Main : Form
    {
        public Main()
        {
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            InitializeComponent();
            string str = string.Empty;
            for (int i = 0; i < 50000; i++)
            {
                str += i.ToString();
            }
            t.Abort();
            this.Show();
        }

        public void SplashStart()
        {
            SplashScreen frm = new SplashScreen();
            Application.Run(frm);
        }

    #region "Config Button"

        public Boolean isConfigUnhide
        {
            get { return this.toolStripConfig.Visible; }
            set { this.toolStripConfig.Visible = value; }
        }

        public Boolean isBrandingUnhide
        {
            get { return this.toolStripAddBrand.Visible; }
            set { this.toolStripAddBrand.Visible = value; }
        }

        public Boolean isMappingUnhide
        {
            get { return this.toolStripMapping.Visible; }
            set { this.toolStripMapping.Visible = value; }
        }

        #endregion

        private void toolStripConfig_Click(object sender, EventArgs e)
        {
            Form config = new Configuration();
            config.ShowDialog();
        }

        private void toolStripDataCreation_Click(object sender, EventArgs e)
        {
            Form filec8 = new FileCreation();
            filec8.ShowDialog();
        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Dispose();
            this.Close();
        }

        private void toolStripAddBrand_Click(object sender, EventArgs e)
        {
            Form branding = new Branding();
            branding.ShowDialog();
        }

        private void toolStripMapping_Click(object sender, EventArgs e)
        {
            Form mapping = new Mapping();
            mapping.ShowDialog();
        }
    }
}
