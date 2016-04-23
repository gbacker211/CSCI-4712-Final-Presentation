using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SoftwareConfigurationManagementDBApp
{
    public partial class CIDoc : Form
    {
        private Attributes _cidocInfo;
        private bool _update = false;
        private int _ci;
        public CIDoc(int CI)
        {
            InitializeComponent();
            _update = false;
            _ci = CI;
        }

        public CIDoc(Attributes info)
        {
            InitializeComponent();
            _cidocInfo = info;
            SetFields();
            _update = true;
        }

        private void CIDoc_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmitCIDoc_Click(object sender, EventArgs e)
        {
            if (txtCIDocName.Text != String.Empty && txtCIDocRevision.Text != String.Empty)
            {
                var obj = new CIDocs()
                {
                    ID = _cidocInfo.ID != null ? Convert.ToInt32(_cidocInfo.ID) : 0,
                    Name = txtCIDocName.Text.Trim(),
                    Date = Convert.ToString(CIDocDate.Value.Date),
                    Revision = txtCIDocRevision.Text.Trim(),
                    Location = txtCIDocLocation.Text.Trim(),
                    Description = txtCIInfoCI.Text.Trim(),
                };

                AttributeControl control = new AttributeControl();

                if (_update)
                {
                    if (control.updateConfigItemDoc(obj))
                    {
                        MessageBox.Show("Update succeeded", "Message", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An unknown error occured", "Error", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
                else
                {
                    if (control.submitCIDoc(obj, _ci))
                    {
                        MessageBox.Show("Item added", "Message", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An unknown error occured", "Error", MessageBoxButtons.OK);
                        this.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Name and Revision fields cannot be empty", "ERROR", MessageBoxButtons.OK);

            }
        }

        private void btnSubmitCIDoc_MouseHover(object sender, EventArgs e)
        {
            btnSubmitCIDoc.BackColor = Color.CornflowerBlue;
        }

        private void btnSubmitCIDoc_MouseLeave(object sender, EventArgs e)
        {
            btnSubmitCIDoc.BackColor = Color.Empty;
        }

        private void SetFields()
        {
            txtCIDocName.Text = _cidocInfo.Name;
            txtCIDocLocation.Text = _cidocInfo.Location;
            txtCIDocRevision.Text = _cidocInfo.Revision;
            txtCIInfoCI.Text = _cidocInfo.Description;
            CIDocDate.Value = _cidocInfo.Date != "N/A" ? Convert.ToDateTime(_cidocInfo.Date) : DateTime.Today;
            //Should set a hidden field for ID?
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
