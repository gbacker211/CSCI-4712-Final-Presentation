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
using MSExcel = Microsoft.Office.Interop.Excel;


namespace SoftwareConfigurationManagementDBApp
{
    public partial class DashBoard : Form
    {
        private User _userInfo;
        private LoginForm _loginForm;


        public DashBoard(User aUser, LoginForm login)
        {
            InitializeComponent();
            _userInfo = aUser;
            _loginForm = login;
            if (_userInfo.AccessGroup == 2)
            {
                grpAdmin.Hide();
                grpAttributes.Location = new Point(75, 199);
                grpDataViewing.Location = new Point(75, 289);
            }
            if (_userInfo.AccessGroup == 3)
            {
                grpAdmin.Hide();
                grpAttributes.Hide();
                grpDataViewing.Location = new Point(75, 255);
            }
        }



        private void viewlb_Click(object sender, EventArgs e)
        {

        }

        private void selectView(object sender, EventArgs e)
        {
            if (ddlGroups.SelectedValue != null)
            {
                int viewSelection = Convert.ToInt32(cmbDataViews.SelectedIndex);
                switch (viewSelection)
                {
                    case 0:
                        dataGridView1.DataSource = ViewSoftwareOverview();
                        dataGridView1.Columns[8].Visible = false;
                        setColumnHeadersForSoftwareOverview();
                        break;
                    case 1:
                        dataGridView1.DataSource = ViewSoftwareView();
                        dataGridView1.Columns["SoftwareID"].Visible = false;
                        setColumnHeadersForSoftwareView();
                        break;

                    case 2:
                        dataGridView1.DataSource = ShowAllSoftware();
                        dataGridView1.Columns[7].Visible = false;
                        setColumnHeadersForSoftwareOverview();
                        break;
                    default:
                        break;

                }
            }
            else
            {
                MessageBox.Show("Must Select a Group First", "ERROR!", MessageBoxButtons.OK);
            }

        }

        private void btnAddSoftw_Click(object sender, EventArgs e)
        {
            Software aSoftware = new Software();
            Form aNewSoftware = new SoftwareForm(aSoftware, _userInfo, 1, this);
            aNewSoftware.Show();
        }

        private void btnEditSoftw_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && cmbDataViews.SelectedIndex != 1)
            {
                int column = 0;

                switch (cmbDataViews.SelectedIndex)
                {
                    case 0:
                        column = 8;
                        break;

                    case 2:
                        column = 7;
                        break;

                    default:
                        break;
                }

                var aSoftware = new Software()
                {
                    SoftwareName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                    Classification = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                    DesignAuthority = dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                    Description = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                    ResponsibleEngineer = dataGridView1.SelectedRows[0].Cells[4].Value.ToString(),
                    SystemName = dataGridView1.SelectedRows[0].Cells[5].Value.ToString(),
                    Owner = dataGridView1.SelectedRows[0].Cells[6].Value.ToString(),
                    Group = cmbDataViews.SelectedIndex == 2 ? ddlGroups.SelectedText  : dataGridView1.SelectedRows[0].Cells[7].Value.ToString(),
                    Software_ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[column].Value.ToString())
                };



                Form aNewSoftware = new SoftwareForm(aSoftware, _userInfo, 2, this);
                aNewSoftware.Show();
            }
            else
            {
                MessageBox.Show("No Software Selected or Software View is selected", "Error", MessageBoxButtons.OK);
            }


        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            // LoginForm.ActiveForm.Show();
            //temp
            LoginControl login = new LoginControl(_loginForm);
            login.ReturnToLoginn();

        }

        private void setColumnHeadersForSoftwareOverview()
        {
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Design Authority";
            dataGridView1.Columns[5].HeaderText = "System Name";
            dataGridView1.Columns[7].HeaderText = "Group Name";
        }

        private void setColumnHeadersForSoftwareView()
        {
            dataGridView1.Columns[1].HeaderText = "Software Doc Count";
            dataGridView1.Columns[2].HeaderText = "CI Count";
            dataGridView1.Columns[3].HeaderText = "CID Count";
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            if (cmbDataViews.Items.Count < 0)
            {
                cmbDataViews.Items.Add("Software Overview");
                cmbDataViews.Items.Add("Software View");
                cmbDataViews.Items.Add("All Software");
            }

            UpdateGroups(sender, e);

        }

        private DataTable ViewSoftwareOverview()
        {
            DataTable dt = new DataTable();

            DisplayControl displayData = new DisplayControl();

            dt = displayData.GetSoftwareOverview(Convert.ToInt32(ddlGroups.SelectedValue.ToString()), _userInfo.User_ID);



            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("There is no software for your group, please contact Administrator", "Error!",
                    MessageBoxButtons.OK);
            }


            return dt;

        }

        private DataTable ViewSoftwareView()
        {
            DataTable dt = new DataTable();
            DisplayControl displayData = new DisplayControl();

            dt = displayData.GetSoftwareView(Convert.ToInt32(ddlGroups.SelectedValue.ToString()), _userInfo.User_ID);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("There is no software for your group, please contact Administrator", "Error!",
                   MessageBoxButtons.OK);
            }

            return dt;
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            PrintControl daPrintControl = new PrintControl(dataGridView1, cmbDataViews.SelectedItem.ToString());
            daPrintControl.ExportGridData();
        }


        private void btnDeleteSoft_Click(object sender, EventArgs e)
        {
            SoftwareControl software = new SoftwareControl();



            int column = 0;
            if (cmbDataViews.SelectedIndex == 0)
            {
                column = 8;
            }
            else if (cmbDataViews.SelectedIndex == 2)
            {
                column = 7;
            }
            else
            {
                column = 4;
            }



            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows.Count < 2)
            {


                if (software.DeleteSoftware(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[column].Value.ToString())))
                {
                    MessageBox.Show("Software has been successfully deleted", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Failure has occured", "Error!", MessageBoxButtons.OK);
                }
                UpdateGrid(sender, e);
            }
            else
            {
                MessageBox.Show("Must select one row to delete software", "Error", MessageBoxButtons.OK);
            }
        }



        public void UpdateGrid(object sender, EventArgs e)
        {
            selectView(sender, e);
            UpdateGroups(sender, e);
        }

        private void UpdateGroups(object sender, EventArgs e)
        {
            //TODO: Move to DisplayController
            DataTable dt = new DataTable();

            DisplayControl displayOperation = new DisplayControl();
            UserControl displayGroups = new UserControl();

            if (_userInfo.AccessGroup == 1)
            {
                dt = displayGroups.getGroups();

            }
            else
            {
                dt = displayOperation.GetGroups(_userInfo);
            }



            if (dt.Rows.Count > 0)
            {
                ddlGroups.DataSource = dt;
                ddlGroups.DisplayMember = "GroupName";
                ddlGroups.ValueMember = "ID";
            }



        }

        private void btnAddAttr_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count != 0)
            {
                AttributeControl attControl = new AttributeControl();
                switch (cmbDataViews.SelectedIndex)
                {
                    case 0:
                        attControl.openAttributeForm(
                            Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[8].Value.ToString()),
                            dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim(), this);
                        break;
                    case 1:
                        attControl.openAttributeForm(
                            Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()),
                            dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim(), this);

                        break;
                    case 2:
                        attControl.openAttributeForm(
                            Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[7].Value.ToString()),
                            dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim(), this);

                        break;
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserControl newUser = new UserControl();
            newUser.OpenUserForm(_userInfo, 1);
        }

        private void btnViewAttr_Click(object sender, EventArgs e)
        {
            //Pass the software id into the form
            if (dataGridView1.SelectedRows.Count != 0)
            {
                AttributeControl attControl = new AttributeControl(_userInfo);
                switch (cmbDataViews.SelectedIndex)
                {
                    case 0:
                        attControl.viewAttributes(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[8].Value.ToString()),
                            dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                        break;
                    case 1:

                        attControl.viewAttributes(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()),
                                dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                        break;
                    case 2:
                        attControl.viewAttributes(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[7].Value.ToString()),
                             dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                        break;

                }


            }
        }

        private DataTable ShowAllSoftware()
        {
            DisplayControl display = new DisplayControl();
            return display.GetAllSoftware();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            UserControl allUsers = new UserControl();
            allUsers.OpenUserView();
        }

        private void btnLogOut_MouseHover(object sender, EventArgs e)
        {
            btnLogOut.BackColor = Color.CornflowerBlue;
        }

        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut.BackColor = Color.Empty;
        }

        private void btnPrintReport_MouseHover(object sender, EventArgs e)
        {
            btnPrintReport.BackColor = Color.CornflowerBlue;
        }

        private void btnPrintReport_MouseLeave(object sender, EventArgs e)
        {
            btnPrintReport.BackColor = Color.Empty;
        }

        private void btnViewAttr_MouseHover(object sender, EventArgs e)
        {
            btnViewAttr.BackColor = Color.CornflowerBlue;
        }

        private void btnViewAttr_MouseLeave(object sender, EventArgs e)
        {
            btnViewAttr.BackColor = Color.Empty;
        }

        private void btnAddAttr_MouseHover(object sender, EventArgs e)
        {
            btnAddAttr.BackColor = Color.CornflowerBlue;
        }

        private void btnAddAttr_MouseLeave(object sender, EventArgs e)
        {
            btnAddAttr.BackColor = Color.Empty;
        }

        private void btnViewUser_MouseHover(object sender, EventArgs e)
        {
            btnViewUser.BackColor = Color.CornflowerBlue;
        }

        private void btnViewUser_MouseLeave(object sender, EventArgs e)
        {
            btnViewUser.BackColor = Color.Empty;
        }

        private void btnAddUser_MouseHover(object sender, EventArgs e)
        {
            btnAddUser.BackColor = Color.CornflowerBlue;
        }

        private void btnAddUser_MouseLeave(object sender, EventArgs e)
        {
            btnAddUser.BackColor = Color.Empty;
        }

        private void btnDeleteSoft_MouseHover(object sender, EventArgs e)
        {
            btnDeleteSoft.BackColor = Color.CornflowerBlue;
        }

        private void btnDeleteSoft_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteSoft.BackColor = Color.Empty;
        }

        private void btnEditSoftw_MouseHover(object sender, EventArgs e)
        {
            btnEditSoftw.BackColor = Color.CornflowerBlue;
        }

        private void btnEditSoftw_MouseLeave(object sender, EventArgs e)
        {
            btnEditSoftw.BackColor = Color.Empty;
        }

        private void btnAddSoftw_MouseHover(object sender, EventArgs e)
        {
            btnAddSoftw.BackColor = Color.CornflowerBlue;
        }

        private void btnAddSoftw_MouseLeave(object sender, EventArgs e)
        {
            btnAddSoftw.BackColor = Color.Empty;
        }
        private void ResetSCMSApp(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    "Doing this means that you will have to re-enter the connection to the database, are you sure?",
                    "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoginControl operation = new LoginControl();

                operation.ResetApplication();
            }
        }
    }
}
