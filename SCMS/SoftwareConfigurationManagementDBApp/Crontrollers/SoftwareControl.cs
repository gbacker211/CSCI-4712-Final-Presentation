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
    class SoftwareControl
    {
        private String _connectionString;

        public SoftwareControl()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SCMDatabaseConnectionString"].ConnectionString;
        }

        public bool DeleteSoftware(int SoftwareID)
        {
            bool value;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Delete_Software", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoftwareID", SoftwareID);


                    int success = command.ExecuteNonQuery();
                    if (success > 0)
                    {
                        value = true;
                    }
                    else
                    {

                        value = false;
                    }

                    return value;
                }
            }

        }

        public bool AddNewSoftware(User user, Software software)
        {
            bool result;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand AddSoftware = new SqlCommand("usp_Insert_NewSoftware", conn))
                {
                    try
                    {
                        conn.Open();
                        AddSoftware.CommandType = CommandType.StoredProcedure;
                        AddSoftware.Parameters.AddWithValue("@SoftwareName", software.SoftwareName);
                        AddSoftware.Parameters.AddWithValue("@Description", software.Description);
                        AddSoftware.Parameters.AddWithValue("@Classification", software.Classification);
                        AddSoftware.Parameters.AddWithValue("@SystemName", software.SystemName);
                        AddSoftware.Parameters.AddWithValue("@Engineer", software.ResponsibleEngineer);
                        AddSoftware.Parameters.AddWithValue("@Owner", software.Owner);
                        AddSoftware.Parameters.AddWithValue("@DesignAuthority", software.DesignAuthority);
                        AddSoftware.Parameters.AddWithValue("@GroupID", software.Group);

                        int success = AddSoftware.ExecuteNonQuery();


                        if (success > 0)
                        {
                            result = true;
                        }
                        else
                        {

                            result = false;
                        }

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }



            return result;
        }

        public bool UpdateSoftware(Software software)
        {
            bool value;


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand UpdateSoftware = new SqlCommand("usp_Update_Software", conn))
                {
                    try
                    {
                        conn.Open();
                        UpdateSoftware.CommandType = CommandType.StoredProcedure;
                        UpdateSoftware.Parameters.AddWithValue("@SoftwareID", software.Software_ID);
                        UpdateSoftware.Parameters.AddWithValue("@Classification", software.Classification);
                       // UpdateSoftware.Parameters.AddWithValue("@Name", software.SoftwareName);
                        UpdateSoftware.Parameters.AddWithValue("@DesignAuthority", software.DesignAuthority);
                        UpdateSoftware.Parameters.AddWithValue("@SystemName", software.SystemName);
                        UpdateSoftware.Parameters.AddWithValue("@Engineer", software.ResponsibleEngineer);
                        UpdateSoftware.Parameters.AddWithValue("@Description", software.Description);
                        UpdateSoftware.Parameters.AddWithValue("@Owner", software.Owner);
                        UpdateSoftware.Parameters.AddWithValue("@MangingGroup", software.Group);

                        int success = UpdateSoftware.ExecuteNonQuery();
                        if (success > 0)
                            value = true;
                        else
                        {
                            value = false;
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }


            return value;

        }

    }
}
