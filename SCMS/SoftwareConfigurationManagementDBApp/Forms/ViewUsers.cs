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
    public partial class ViewUsers : Form
    {

        private UserControl mUControl;

        public ViewUsers(UserControl aUControl)
        {
            InitializeComponent();

            mUControl = aUControl;
        }

        private void setColumnHeadersForUser()
        {
            dataGridView1.Columns[0].HeaderText = "First Name";
            dataGridView1.Columns[1].HeaderText = "Last Name";
            dataGridView1.Columns[2].HeaderText = "Username";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Access Group";
            dataGridView1.Columns[5].Visible = false;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var obj = new User()
                {
                    Fname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                    Lname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                    Username = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                    Password = dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                    AccessGroup = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value),
                    User_ID =   Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value) // unsure about
                    
                };

                mUControl.OpenUserForm(obj, 2, this);
            }
            else
            {
                MessageBox.Show("Please select a User!", "Error!", MessageBoxButtons.OK);
            }
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = mUControl.getUsers();
            dataGridView1.DataSource = dt;
            setColumnHeadersForUser();
        }

        private void btnEditUser_MouseHover(object sender, EventArgs e)
        {
            btnEditUser.BackColor = Color.CornflowerBlue;
        }

        private void btnEditUser_MouseLeave(object sender, EventArgs e)
        {
            btnEditUser.BackColor = Color.Empty;
        }

        public void RefreshGrid(object sender, EventArgs e)
        {
           ViewUsers_Load(sender, e);   
        }

    }
}
