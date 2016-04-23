using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareConfigurationManagementDBApp
{
    public partial class Pathway : Form
    {
        private LoginForm _login;
        private bool _connectionSet;
        public Pathway(LoginForm login)
        {
            InitializeComponent();
            _login = login;
            pnlCredentials.Visible = false;

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            LoginControl setPathway = new LoginControl();

            try
            {
                if (txtPathway.Text != String.Empty)
                {
                    if (setPathway.SetUpApplication(txtPathway.Text, txtUserName.Text, txtPassword.Text))
                    {
                        _connectionSet = true;
                        if (MessageBox.Show("Connection add, appliction will need to be restarted", "Success",
                             MessageBoxButtons.OK) == DialogResult.OK)
                        {
                            Application.Exit();

                        }
                    }

                    _connectionSet = false;

                }
                else
                {

                    if (MessageBox.Show("Pathway to database cannot be null",
                        "Error", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                //EAT ERROR For Now

            }



        }

        private void ShowUserNameAndPassword(object sender, EventArgs e)
        {
            if (chkViewFormB.Checked)
                pnlCredentials.Visible = true;
            else
                pnlCredentials.Visible = false;
        }

        private void Pathway_Closing(object sender, FormClosingEventArgs e)
        {
            if (!_connectionSet)
            {


                if (MessageBox.Show("No connection to datawase was established, are you sure you want to quit?",
              "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Stay open
                    //  e.Cancel = false;
                    Application.Exit();
                }
                else
                {
                    //  e.Cancel = true;
                    CancelEventArgs ea = e;

                    ea.Cancel = true;

                }


            }



        }
    }
}
