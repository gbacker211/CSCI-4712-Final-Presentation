using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Xml;
using System.IO;

namespace SoftwareConfigurationManagementDBApp
{
    class LoginControl
    {
        private LoginForm _loginForm;
        private String _connectionString;
        public LoginControl(LoginForm login)
        {
            _loginForm = login;

            _connectionString = ConfigurationManager.ConnectionStrings["SCMDatabaseConnectionString"].ConnectionString;
        }

        public LoginControl()
        {
            
        }

        public void submit(string aUsername, string aPassword)
        {
                SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                _connectionString; //Modifed to use application
                    using (conn)
                    {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_Select_User", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", aUsername);
                    cmd.Parameters.AddWithValue("@PassWoard", aPassword);
                    User aUser = new User();
                    DataSet ds = new DataSet();
                    //   DataTable dt = new DataTable();

                    using (SqlDataAdapter getData = new SqlDataAdapter(cmd))
                    {
                        getData.Fill(ds);
                    }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        aUser.User_ID = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
                        aUser.AccessGroup = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

                        DashBoard dashBoard = new DashBoard(aUser, _loginForm);
                        LoginForm.ActiveForm.Hide();
                        dashBoard.Show();
                    }
                    else
                    {
                        MessageBox.Show("User does not exsist", "Error!", MessageBoxButtons.OK);
                    }
                }
                finally
                {
                    conn.Close();
                }
                    }

        }


        public void DisplaySetUpApplication()
        {
            Pathway pathwayOperation = new Pathway(_loginForm);

            pathwayOperation.ShowDialog();

        }

        public bool SetUpApplication(string server, string userName = "", string password = "")
        {
         
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

            connection.InitialCatalog = "SCMDatabase";
            connection.DataSource = server;
            connection.IntegratedSecurity = true;
            if (userName != String.Empty && password != String.Empty)
            {
                connection.UserID = userName;
                connection.Password = password;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connection.ConnectionString))
                {
                    conn.Open();
                }

               

                UpdateConfigFile(connection.ConnectionString);

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "There was error in creating the connection to the database please ensure that the information is valid",
                    "Error", MessageBoxButtons.OK);

                return false;

            }


         
            
        }

        public void UpdateConfigFile(string con)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Clear();

            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("SCMDatabaseConnectionString", con));

            config.Save();

            ConfigurationManager.RefreshSection((config.ConnectionStrings.SectionInformation.SectionName));

          
        }

        public void ReturnToLoginn()
        {
           _loginForm.Show();
           
        }

        public void ResetApplication()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Clear();
            config.Save();

            ConfigurationManager.RefreshSection((config.ConnectionStrings.SectionInformation.SectionName));

            Application.Exit();
        }
    }
}
