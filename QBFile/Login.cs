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
using QBFile.Classes;

namespace QBFile
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ClassQuery cq = new ClassQuery();
                cq.AuthUser();
                if (txtuserpass.Text != "")
                {
                    if(txtuserpass.Text == cq.adcode)
                    {
                        MessageBox.Show("Welcome SHC!", "Master Logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Main main = new Main();
                        main.isConfigUnhide = true;
                        main.isBrandingUnhide = true;
                        main.Show();
                    }
                    else if(txtuserpass.Text == cq.uscode)
                    {
                        MessageBox.Show("Welcome Guest!", "Guest Logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Main main = new Main();
                        main.isConfigUnhide = false;
                        main.isBrandingUnhide = false;
                        main.isMappingUnhide = false;
                        main.Show();
                    }
                    else if (txtuserpass.Text == cq.seancode)
                    {
                        MessageBox.Show("Welcome Sean!", "Admin Logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Main main = new Main();
                        main.isConfigUnhide = false;
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sorry, the userid Or password you entered may be incorrect.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, the userid Or password you entered may be incorrect.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtuserpass.Focus();
        }
    }
}
