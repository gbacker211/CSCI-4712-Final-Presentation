using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace SoftwareConfigurationManagementDBApp
{
    class DisplayControl
    {
        private String _connectionString;

        public DisplayControl()
        {

           _connectionString = ConfigurationManager.ConnectionStrings["SCMDatabaseConnectionString"].ConnectionString;
        }
        public DataTable GetSoftwareOverview(int groupID, int UserID)
        {
            DataTable dt = new DataTable();



            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Select_SoftwareOverview", connect))
                {
                    connect.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", groupID);
                    //command.Parameters.AddWithValue("@UserID", UserID);

                    using (SqlDataAdapter getData = new SqlDataAdapter(command))
                    {
                        getData.Fill(dt);
                    }



                }
            }


            return dt;
        }

        public DataTable GetSoftwareView(int groupID, int UserID)
        {
            DataTable dt = new DataTable();



            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Select_SoftwareView", connect))
                {
                    connect.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GroupID", groupID);
                    //command.Parameters.AddWithValue("@UserID", UserID);

                    using (SqlDataAdapter getData = new SqlDataAdapter(command))
                    {
                        getData.Fill(dt);
                    }

                }
            }


            return dt;
        }

        public DataTable GetGroups(User userInfo)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Select_GroupsByUserID", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userInfo.User_ID);
                    using (SqlDataAdapter dataOperation = new SqlDataAdapter(command))
                    {
                        dataOperation.Fill(dt);
                    }





                }
            }

            return dt;
        }

        public DataTable GetAllSoftware()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Select_AllSoftware", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataAdapter getAdapter = new SqlDataAdapter(command))
                    {
                        getAdapter.Fill(dt);
                    }
                }

            }




            return dt;
        }

    }
}
