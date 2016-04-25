using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareConfigurationManagementDBApp
{
    public partial class AddUser : Form
    {
        private UserControl mUserControl;
        private int mAddUpdate;
        private User mUser;
        private ViewUsers _UserForm;
        public AddUser(UserControl aControl, User aUser, int aAddUpdate, ViewUsers UserForm)
        {
            InitializeComponent();
            mUserControl = aControl;
            mUser = aUser;
            mAddUpdate = aAddUpdate;
            _UserForm = UserForm;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

            UserControl userGroups = new UserControl();


            DataTable dt = new DataTable();

            dt = userGroups.getGroups();


            DataRow dr = dt.NewRow();

            dr["ID"] = "0";
            dr["GroupName"] = " ";
            dt.Rows.InsertAt(dr, 0);

            if (dt.Rows.Count > 0)
            {
                cmdGroups.DataSource = dt;
                cmdGroups.DisplayMember = "GroupName";
                cmdGroups.ValueMember = "ID";
            }

         //   cmdGroups.Items.Insert(0, " ");
            
           
            
            cmbAccessGroup.Items.Add("Select Group");
            cmbAccessGroup.Items.Add("Admin");
            cmbAccessGroup.Items.Add("Editor");
            cmbAccessGroup.Items.Add("Read-Only");

            if (mAddUpdate == 2)
            {
                txtFname.Text = mUser.Fname;
                txtLname.Text = mUser.Lname;
                txtUsername.Text = mUser.Username;
                txtUsername.Enabled = false;
                txtPassword.Text = "Enter new password";
                cmbAccessGroup.SelectedIndex = mUser.AccessGroup;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFname.Text == "" || txtLname.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || cmbAccessGroup.SelectedIndex == -1)
                MessageBox.Show("Please make sure that the fields are filled and a User Access Level is selected.");
            else
            {
                int AccessLvl = 3; // for assigning User access level.
                switch (cmbAccessGroup.SelectedIndex)
                {
                    case 1:
                        AccessLvl = 1;
                        break;
                    case 2:
                        AccessLvl = 2;
                        break;
                    case 3:
                        AccessLvl = 3;
                        break;
                    default:
                        break;
                }


                if (cmdGroups.SelectedValue != "0" && txtGroupName.Text == String.Empty)
                {
                    //use dropdown
                   

                    if (mAddUpdate == 1)
                    {

                        var obj = new User()
                        {
                            User_ID = 1,
                            Fname = txtFname.Text.Trim(),
                            Lname = txtLname.Text.Trim(),
                            Username = txtUsername.Text.Trim(),
                            Password = txtPassword.Text.Trim(),
                            AccessGroup = AccessLvl,
                            GroupName = cmdGroups.Text.Trim()
                        };

                        if (mUserControl.AddUser(obj))
                        {
                            MessageBox.Show("User has been added!", "Success!", MessageBoxButtons.OK);
                            this.Close();
                           // _UserForm.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("User name already exists in the system",
                                "ERROR", MessageBoxButtons.OK);

                        }
                        
                      

                    }
                    if (mAddUpdate == 2)
                    {

                        var obj = new User()
                        {
                            User_ID = mUser.User_ID,
                            Fname = txtFname.Text.Trim(),
                            Lname = txtLname.Text.Trim(),
                            Username = txtUsername.Text.Trim(),
                            Password = txtPassword.Text != "Enter new password" ? txtPassword.Text.Trim() : String.Empty,
                            AccessGroup = AccessLvl,
                            GroupID = Convert.ToInt32(cmdGroups.SelectedValue.ToString())
                        };

                        if (mUserControl.UpdateUser(obj))
                        {
                            MessageBox.Show("User has been updated!", "Success!", MessageBoxButtons.OK);
                            ViewUsers.ActiveForm.Close();
                            this.Close();
                            _UserForm.RefreshGrid(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("User name already exists in the system",
                                "ERROR", MessageBoxButtons.OK);
                        }
                     
                    }
                }
                else if(cmdGroups.SelectedValue == "0" && txtGroupName.Text != String.Empty)
                {
                    //use text
                    var obj = new User()
                    {
                        User_ID = 1,
                        Fname = txtFname.Text.Trim(),
                        Lname = txtLname.Text.Trim(),
                        Username = txtUsername.Text.Trim(),
                        Password = txtPassword.Text.Trim(),
                        AccessGroup = AccessLvl,
                        GroupName = txtGroupName.Text.Trim()
                    };

                    if (mAddUpdate == 1)
                    {
                        mUserControl.AddUser(obj);
                        MessageBox.Show("User has been added!", "Success!", MessageBoxButtons.OK);
                        Close();
                    }
                    if (mAddUpdate == 2)
                    {
                        mUserControl.UpdateUser(obj);
                        MessageBox.Show("User has been updated!", "Success!", MessageBoxButtons.OK);
                        // ViewUsers.ActiveForm.Close();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Must enter group name, or select one from the drop down", "Error",
                        MessageBoxButtons.OK);
                }
              
            }
        }

        private void btnSubmit_MouseHover(object sender, EventArgs e)
        {

            btnSubmit.BackColor = Color.CornflowerBlue;
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.Empty;
        }
    }
    }

