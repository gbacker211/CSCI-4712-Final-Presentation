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
    public partial class CIForm : Form
    {
        private Attributes _CI;
        private bool _update;
        private int _softwareID;

        public CIForm(int softwareID)
        {
            InitializeComponent();
            _update = false;
            _softwareID = softwareID;
        }

        public CIForm(Attributes info)
        {
            InitializeComponent();
            _CI = info;
            _update = true;
            SetFields();
        }

        private void CIForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmitCI_Click(object sender, EventArgs e)
        {

            if (txtCIName.Text != String.Empty && txtCIRevision.Text != String.Empty)
            {
                var Obj = new CI()
                {
                    ID = _CI.ID != null ? Convert.ToInt32(_CI.ID) : 0,
                    Name = txtCIName.Text.Trim(),
                    Date = Convert.ToString(CIDate.Value.Date),
                    Revision = txtCIRevision.Text.Trim(),
                    Location = txtCILocation.Text.Trim(),
                    Description = txtCIInfoCI.Text.Trim(),
                };

                AttributeControl attributeControl = new AttributeControl();

                if (_update)
                {
                    if (attributeControl.updateConfigItem(Obj))
                    {
                        MessageBox.Show("ConfigItem updated", "Success", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An error occured while updating", "ERROR", MessageBoxButtons.OK);
                        this.Close();
                    }

                }
                else
                {
                    if (attributeControl.submitCI(Obj, _softwareID))
                    {
                        MessageBox.Show("ConfigItem added", "Success", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An error occured while updating", "ERROR", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Name and Revision fields cannot be empty", "ERROR", MessageBoxButtons.OK);
            }

           
        }

        private void btnSubmitCI_MouseHover(object sender, EventArgs e)
        {
            btnSubmitCI.BackColor = Color.CornflowerBlue;
        }

        private void btnSubmitCI_MouseLeave(object sender, EventArgs e)
        {
            btnSubmitCI.BackColor = Color.Empty;
        }

        private void SetFields()
        {
            txtCIInfoCI.Text = _CI.Description;
            txtCIRevision.Text = _CI.Revision;
            txtCILocation.Text = _CI.Location;
            txtCIName.Text = _CI.Name;
            CIDate.Value = _CI.Date != "N/A" ? Convert.ToDateTime(_CI.Date) : DateTime.Today;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.CornflowerBlue;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.Empty;
        }
    }
}
