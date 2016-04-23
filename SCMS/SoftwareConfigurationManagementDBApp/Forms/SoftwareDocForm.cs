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
    public partial class SoftwareDocForm : Form
    {
        private Attributes _softwareDocument;
        private int _softwareID;
        private bool _update;
        public SoftwareDocForm(int softwareID)
        {
            InitializeComponent();
            _update = false;
        }

        public SoftwareDocForm(Attributes attributes)
        {
            InitializeComponent();
            _softwareDocument = attributes;
            SetUpdateFields();
            _update = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSoftDocName.Text != String.Empty && txtSoftDocRevision.Text != String.Empty)
            {

                var obj = new SoftwareDoc
                {
                    ID = _softwareDocument != null ? Convert.ToInt32(_softwareDocument.ID) : 0,
                    Name = txtSoftDocName.Text.Trim(),
                    Date = Convert.ToString(SoftwarDocDate.Value.Date),
                    Revision = txtSoftDocRevision.Text.Trim(),
                    Location = txtSoftDocRevision.Text.Trim(),
                    Description = txtSoftDocDescription.Text.Trim(),
                };

                AttributeControl attributeControl = new AttributeControl();

                if (_update)
                {
                    if (attributeControl.updateSoftDoc(obj))
                    {
                        MessageBox.Show("Software Doc updated", "Success", MessageBoxButtons.OK);
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
                    if (attributeControl.submitSoftDoc(obj, _softwareID))
                    {
                        MessageBox.Show("Software Doc added", "Success", MessageBoxButtons.OK);
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
            btnSubmit.BackColor = Color.Empty;

        }

        private void SetUpdateFields()
        {

            txtSoftDocName.Text = _softwareDocument.Name;
            txtSoftDocDescription.Text = _softwareDocument.Description;
            txtSoftDocLocation.Text = _softwareDocument.Location;
            txtSoftDocRevision.Text = _softwareDocument.Revision;
            SoftwarDocDate.Value =  _softwareDocument.Date != "N/A" ? Convert.ToDateTime(_softwareDocument.Date) : DateTime.Today;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
