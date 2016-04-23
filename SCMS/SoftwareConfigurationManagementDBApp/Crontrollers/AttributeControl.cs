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
    class AttributeControl
    {
        private int mSoftware_ID;
        private String _connectionString;
        private User aUser;

        public AttributeControl(User user = null)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SCMDatabaseConnectionString"].ConnectionString;
            aUser = user;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="softwareId"></param>
        /// <param name="softwareName"></param>
        /// <param name="att"></param>
        /// <param name="InsertType"></param>
        /// <param name="configItemID">If adding a config item document this value should be set</param>
        public void openAttributeForm(int softwareId, string softwareName, DashBoard att, int InsertType = 0, int configItemID = 0)
        {
            mSoftware_ID = softwareId;
            switch (InsertType)
            {
                case 1:
                    Attribute_s_ AddAttributeSoftwareDOC = new Attribute_s_(softwareId, softwareName, att, InsertType);
                    AddAttributeSoftwareDOC.Show();
                    break;
                case 2:
                    {
                        if (configItemID == 0)
                        {
                            Attribute_s_ AddAttributeConfig = new Attribute_s_(softwareId, softwareName, att, InsertType);
                            AddAttributeConfig.Show();
                        }
                        else
                        {
                            Attribute_s_ AddAttributeConfig = new Attribute_s_(softwareId, softwareName, att, InsertType,
                                configItemID);
                            AddAttributeConfig.Show();
                        }
                    }
                    break;
                case 3:

                    break;
                default:
                    Attribute_s_ AddAttributes = new Attribute_s_(mSoftware_ID, softwareName, att);
                    AddAttributes.Show();
                    break;

            }

        }
        public bool submitSoftDoc(SoftwareDoc aDoc, int softwareID)
        {
            bool value;
            //Changed to bool to indicate whether insert was a success.
            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Insert_NewSoftwareDOC", connect))
                {
                    connect.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoftwareID", softwareID);
                    command.Parameters.AddWithValue("@Name", aDoc.Name);
                    command.Parameters.AddWithValue("@Revision", aDoc.Revision);
                    command.Parameters.AddWithValue("@Date", aDoc.Date);
                    command.Parameters.AddWithValue("@Description", aDoc.Description);
                    command.Parameters.AddWithValue("@Location", aDoc.Location);

                    int success = command.ExecuteNonQuery();
                    if (success > 0)
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }

                }
            }


            return value;

        }

        public bool submitCI(CI aCI, int softwareID)
        {
            bool value;
            //Changed to bool to indicate whether insert was a success.
            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Insert_NewConfigItem", connect))
                {
                    connect.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoftwareID", softwareID);
                    command.Parameters.AddWithValue("@Name", aCI.Name);
                    command.Parameters.AddWithValue("@Revision", aCI.Revision);
                    command.Parameters.AddWithValue("@Date", aCI.Date);
                    command.Parameters.AddWithValue("@Description", aCI.Description);
                    command.Parameters.AddWithValue("@Location", aCI.Location);

                    int success = command.ExecuteNonQuery();
                    if (success > 0)
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }

                }
            }


            return value;

        }

        public bool submitCIDoc(CIDocs aCIDoc, int CI_ID = 0)
        {

            bool value;
            //Changed to bool to indicate whether insert was a success.
            using (SqlConnection connect = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Insert_NewConfigItemDOC", connect))
                {
                    connect.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CI", CI_ID);
                    command.Parameters.AddWithValue("@Name", aCIDoc.Name);
                    command.Parameters.AddWithValue("@Revision", aCIDoc.Revision);
                    command.Parameters.AddWithValue("@Date", aCIDoc.Date);
                    command.Parameters.AddWithValue("@Description", aCIDoc.Description);
                    command.Parameters.AddWithValue("@Location", aCIDoc.Location);

                    int success = command.ExecuteNonQuery();
                    if (success > 0)
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }

                }
            }


            return value;
        }

        public void viewAttributes(int softwareID, string softwareName)
        {
            mSoftware_ID = softwareID;

            ViewAttributes viewSoftwareAttributes = new ViewAttributes(mSoftware_ID, softwareName, aUser);
            viewSoftwareAttributes.Show();

        }

        /// <summary>
        /// Used for updating attributes
        /// </summary>
        /// <param name="info">Class containing info for an attribute</param>
        public void openAttributForEdit(Attributes info, int update, ViewAttributes att, int software = 0)
        {
            Attribute_s_ attForm = new Attribute_s_(info, update, att, mSoftware_ID);
            attForm.Show();
        }

        public void openSoftwareDocForEdit(Attributes info)
        {
            SoftwareDocForm sdform = new SoftwareDocForm(info);
            sdform.Show();
        }

        public void openConfigItemForEdit(Attributes info)
        {
            CIForm ciForm = new CIForm(info);
            ciForm.Show();
        }

        public void openConfigItemDocForEdit(Attributes info)
        {
            CIDoc cidForm = new CIDoc(info);
            cidForm.Show();
        }

        /// <summary>
        /// Method for editing all attributes for a specific software
        /// item count should be only three
        /// </summary>
        /// <param name="attributeses">List of the attributes</param>
        /// <param name="update">numeric value for displaying data </param>
        public void openAttributForEditAll(List<Attributes> attributeses, int update, ViewAttributes att, int software)
        {
            Attribute_s_ attForm = new Attribute_s_(attributeses, update, att, software);
            attForm.Show();

        }

        /// <summary>
        /// IF doing mass update with empty items configitem etc include lblSoftwareID
        /// </summary>
        /// <param name="softwareDOC"></param>
        /// <param name="softwareID"></param>
        /// <returns></returns>
        public bool updateSoftDoc(Attributes softwareDOC, string SoftwareID = "")
        {
            bool result;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Update_SoftwareDoc", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    if (softwareDOC.ID == 0 && SoftwareID != String.Empty)
                    {
                        int softwareID = Convert.ToInt32(SoftwareID);
                        command.Parameters.AddWithValue("@SoftwareID", softwareID);
                    }

                    command.Parameters.AddWithValue("@SoftwareDOCID", softwareDOC.ID);
                    command.Parameters.AddWithValue("@Name", softwareDOC.Name);
                    command.Parameters.AddWithValue("@Date", softwareDOC.Date);
                    command.Parameters.AddWithValue("@Description", softwareDOC.Description);
                    command.Parameters.AddWithValue("@Location", softwareDOC.Location);
                    command.Parameters.AddWithValue("@Revision", softwareDOC.Revision);
                    connection.Open();

                    int success = Convert.ToInt32(command.ExecuteNonQuery());

                    if (success > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                }
            }


            return result;

        }
        /// <summary>
        /// IF doing mass update with empty items configitem etc include lblSoftwareID
        /// </summary>
        /// <param name="softwareDOC"></param>
        /// <param name="softwareID"></param>
        /// <returns></returns>
        public bool updateConfigItem(Attributes configItem, string SoftwareID = "")
        {
            bool result;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Update_ConfigItem", connection))
                {
                    if (configItem.ID == 0 && SoftwareID != String.Empty)
                    {
                        int softwareID = Convert.ToInt32(SoftwareID);
                        command.Parameters.AddWithValue("@SoftwareID", softwareID);
                    }

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ConfigItem_Id", configItem.ID);
                    command.Parameters.AddWithValue("@Name", configItem.Name);
                    command.Parameters.AddWithValue("@Date", configItem.Date);
                    command.Parameters.AddWithValue("@Description", configItem.Description);
                    command.Parameters.AddWithValue("@Location", configItem.Location);
                    command.Parameters.AddWithValue("@Revision", configItem.Revision);
                    connection.Open();

                    int success = Convert.ToInt32(command.ExecuteNonQuery());

                    if (success > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                }
            }


            return result;

        }
        /// <summary>
        /// IF doing mass update with empty items configitem etc include lblSoftwareID
        /// </summary>
        /// <param name="softwareDOC"></param>
        /// <param name="softwareID"></param>
        /// <returns></returns>
        public bool updateConfigItemDoc(Attributes configItemDOC, string SoftwareID = "")
        {
            bool result;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Update_ConfigItemDOC", connection))
                {
                    if (configItemDOC.ID == 0 && SoftwareID != String.Empty)
                    {
                        int softwareID = Convert.ToInt32(SoftwareID);
                        command.Parameters.AddWithValue("@SoftwareID", softwareID);
                    }

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ConfigItemDOC_ID", configItemDOC.ID);
                    command.Parameters.AddWithValue("@Name", configItemDOC.Name);
                    command.Parameters.AddWithValue("@Date", configItemDOC.Date);
                    command.Parameters.AddWithValue("@Description", configItemDOC.Description);
                    command.Parameters.AddWithValue("@Location", configItemDOC.Location);
                    command.Parameters.AddWithValue("@Revision", configItemDOC.Revision);
                    connection.Open();

                    int success = Convert.ToInt32(command.ExecuteNonQuery());

                    if (success > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                }
            }


            return result;

        }

        public bool deleteSoftDoc(int ID)
        {
            bool result;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Delete_SoftwareDOC", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoftwareDOC_Id", ID);
                    connection.Open();

                    int success = Convert.ToInt32(command.ExecuteNonQuery());

                    if (success > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public bool deleteConfigItem(int ID)
        {
            bool result;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Delete_ConfigItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ConfigItem_Id", ID);
                    connection.Open();

                    int success = Convert.ToInt32(command.ExecuteNonQuery());

                    if (success > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public bool deleteConfigItemDOC(int ID)
        {
            bool result;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Delete_ConfigItemDoc", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ConfigItemDoc_Id", ID);
                    connection.Open();

                    int success = Convert.ToInt32(command.ExecuteNonQuery());

                    if (success > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public DataTable SoftwareItemOverview(int softwareID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Select_SoftwareItemOverview", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoftwareId", softwareID);

                    using (SqlDataAdapter data = new SqlDataAdapter(command))
                    {
                        data.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public DataTable SoftwareViewOne(int softwareID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Select_SoftwareItemView1", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoftwareID", softwareID);

                    using (SqlDataAdapter data = new SqlDataAdapter(command))
                    {
                        data.Fill(dt);
                    }
                }
            }

            return dt;

        }

        public DataTable SoftwareViewTwo(int softwareID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Select_SoftwareItemView2", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoftwareId", softwareID);

                    using (SqlDataAdapter data = new SqlDataAdapter(command))
                    {
                        data.Fill(dt);
                    }
                }
            }

            return dt;
        }
        public DataTable SoftwareViewThree(int softwareID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_Select_SoftwareItemView3", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoftwareId", softwareID);

                    using (SqlDataAdapter data = new SqlDataAdapter(command))
                    {
                        data.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
