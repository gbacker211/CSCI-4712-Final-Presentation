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
using System.Data.SqlClient;

namespace SoftwareConfigurationManagementDBApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
          
            //Need to check if connection string is set up
           


        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == String.Empty && txtPassword.Text == String.Empty)
                MessageBox.Show("Please enter your username and password.","ERROR!",MessageBoxButtons.OK);
            else
            {
                LoginControl newLogin = new LoginControl(this);
                newLogin.submit(txtUsername.Text,txtPassword.Text);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = String.Empty;
            CheckForConnectionToDB();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.CornflowerBlue;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.Empty;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.CornflowerBlue;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Empty;
        }

        private void CheckForConnectionToDB()
        {
            try
            {
                string connection =
                    ConfigurationManager.ConnectionStrings["SCMDatabaseConnectionString"].ConnectionString;



                if (connection == String.Empty)
                    throw new Exception();

            }
            catch (Exception ex)
            {

                if (MessageBox.Show("There is no connection to the database, would you like to set up the connection?",
              "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Go to set up application
                    LoginControl setupApplication = new LoginControl();

                    setupApplication.DisplaySetUpApplication();
                }
                else
                {
                    Application.Exit();
                }


            }

       

          
               
               

            
        }

        
    }
}
