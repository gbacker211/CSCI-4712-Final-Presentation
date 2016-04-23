using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SoftwareConfigurationManagementDBApp
{
    public partial class SoftwareForm : Form
    {
        // Variables for adding or updating.
        Software mSoftware;
        User mUser;
        private int mAddUpdate;
        private DashBoard myDashBoard;

        public SoftwareForm(Software aSoftware, User aUser,int aAddUpdate, DashBoard aDashBoard)
        {
            InitializeComponent();
            mSoftware = aSoftware;
            mUser = aUser;
            mAddUpdate = aAddUpdate;
            myDashBoard = aDashBoard;

            if (mAddUpdate == 2)
                txtSoftwareName.Enabled = false;
            else
                txtSoftwareName.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSoftwareName.Text == String.Empty || txtSystemName.Text == String.Empty  ) //A group will always be selected
                MessageBox.Show("Please make sure that the Software and System Name fields are filled, and that the Group and Classification is selected!", "ERROR!", MessageBoxButtons.OK);
            else
            {
                switch (mAddUpdate)
                {
                    case 1: // add
                        {
                            var obj = new Software()
                            {
                                SoftwareName = txtSoftwareName.Text,
                                SystemName = txtSystemName.Text,
                                Group = ddlGroups.SelectedValue.ToString().Trim(),
                                Owner = txtOwner.Text,
                                Classification = cmbClass.SelectedItem.ToString(),
                                ResponsibleEngineer = txtResponsibleEngineer.Text,
                                Description = txtSoftwareDescription.Text,
                                DesignAuthority = txtDesignAuthority.Text
                            };

                            SoftwareControl softwareOperation = new SoftwareControl();

                            if (softwareOperation.AddNewSoftware(mUser, obj))
                            {
                                MessageBox.Show("Software System has been added");
                                myDashBoard.UpdateGrid(sender, e);
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("An unknown error has occur, or the software already exists", "ERROR!", MessageBoxButtons.OK);
                            }




                            break;
                        }
                    case 2: // update except software nmae
                        {
                            var obj = new Software()
                            {
                                Software_ID = mSoftware.Software_ID,
                              //  SoftwareName = txtSoftwareName.Text.Trim(),
                                SystemName = txtSystemName.Text.Trim(),
                                Group = ddlGroups.SelectedValue.ToString().Trim(),
                                Owner = txtOwner.Text.Trim(),
                                Classification = cmbClass.SelectedItem.ToString().Trim(),
                                ResponsibleEngineer = txtResponsibleEngineer.Text.Trim(),
                                Description = txtSoftwareDescription.Text.Trim(),
                                DesignAuthority = txtDesignAuthority.Text.Trim()
                            };

                            SoftwareControl softwareOperation = new SoftwareControl();

                            if (softwareOperation.UpdateSoftware(obj))
                            {
                                MessageBox.Show("Software System has been updated");
                                myDashBoard.UpdateGrid(sender, e);
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("An unknown error has occur", "ERROR!", MessageBoxButtons.OK);
                            }


                            break;
                        }

                    default:
                        break;
                }
            }
        }

        private void SoftwareForm_Load(object sender, EventArgs e)
        {

            UserControl getgroups = new UserControl();

            ddlGroups.Items.Add("Select Group");
            ddlGroups.DataSource = getgroups.getGroups();
            ddlGroups.DisplayMember = "GroupName";
            ddlGroups.ValueMember = "ID";


            //cmbClass.Items.Add("Select");
            cmbClass.Items.Add("A ");
            cmbClass.Items.Add("B ");
            cmbClass.Items.Add("C ");
            cmbClass.Items.Add("D ");
            cmbClass.Items.Add("SC ");
            cmbClass.Items.Add("SS ");
            cmbClass.Items.Add("PC ");
            cmbClass.Items.Add("GS ");

            if ( mAddUpdate == 2)
            {
                txtSoftwareName.Text = mSoftware.SoftwareName;
                txtSystemName.Text = mSoftware.SystemName;
                txtDesignAuthority.Text = mSoftware.DesignAuthority;
                ddlGroups.SelectedItem = mSoftware.Group;
                txtOwner.Text = mSoftware.Owner;
                txtResponsibleEngineer.Text = mSoftware.ResponsibleEngineer;
                txtSoftwareDescription.Text = mSoftware.Description;
                string ClassificationSelection = mSoftware.Classification;
                cmbClass.SelectedIndex = cmbClass.Items.IndexOf(ClassificationSelection);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.CornflowerBlue;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.Empty;
        }

        private void btnSubmit_MouseHover(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.CornflowerBlue;
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.CornflowerBlue;
        }
    }
}
