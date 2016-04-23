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
    public partial class Attribute_s_ : Form
    {
        private int _softwareID;
        private Attributes _attributesInfo;
        private List<Attributes> _attributesesInfoAll = new List<Attributes>();
        private bool _update = false;
        private int _attributeType;
        private ViewAttributes _attributes;
        private DashBoard _myDashBoard;
        private int _configItemID;


        //TODO: Need to decide if there is a mistake, should we allow them to make corrections or start over.

        /// <summary>
        /// Should be comming from the dashboard
        /// </summary>
        /// <param name="softwareID"></param>
        /// <param name="softwareName"></param>
        /// <param name="dashBoard"></param>
        public Attribute_s_(int softwareID, string softwareName, DashBoard dashBoard)
        {
            _softwareID = softwareID;

            InitializeComponent();
            lblSoftwareName.Text = softwareName;
            _myDashBoard = dashBoard;
            _update = false;
        }
        /// <summary>
        /// Use for Inserting Individual Attributes except for ConfigItemDocs
        /// </summary>
        /// <param name="softwareID"></param>
        /// <param name="softwareName"></param>
        /// <param name="dashBoard"></param>
        /// <param name="InsertAttribute"></param>
        public Attribute_s_(int softwareID, string softwareName, DashBoard dashBoard, int InsertAttribute)
        {
            _softwareID = softwareID;

            InitializeComponent();
            lblSoftwareName.Text = softwareName;
            _myDashBoard = dashBoard;
            _update = false;
            SetTextInsert(InsertAttribute);
        }

        public Attribute_s_(int softwareID, string softwareName, DashBoard dashBoard, int InsertAttribute, int configItemID)
        {
            _softwareID = softwareID;

            InitializeComponent();
            lblSoftwareName.Text = softwareName;
            _myDashBoard = dashBoard;
            _update = false;
            _configItemID = configItemID;
            SetTextInsert(InsertAttribute);
        }

        public Attribute_s_(Attributes info, int attributeType, ViewAttributes attributes, int softwareID)
        {
            _attributesInfo = info;
            _softwareID = softwareID;
            InitializeComponent();
            SetTextUpdate(attributeType);
            _attributeType = attributeType;
            _attributes = attributes;
            _update = true;
        }

        public Attribute_s_(List<Attributes> info, int attributeType, ViewAttributes attributes, int softareID)
        {
            _attributesesInfoAll.AddRange(info);
            InitializeComponent();
            SetTextUpdate(attributeType);
            _attributeType = attributeType;
            _attributes = attributes;
            _softwareID = softareID;
            lblSoftwareID.Text = softareID.ToString();
            _update = true;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }


        private void SetTextUpdate(int attributeType)
        {
            lblSoftwareName.Visible = false;
            lblTitle.Visible = false;
            switch (attributeType)
            {
                case 0://Fill all fields
                    {

                        for (int i = 0; i < _attributesesInfoAll.Count; i++)
                        {
                            switch (i)
                            {
                                case 0: //Software DOC
                                    {
                                        txtSoftDocNameAttr.Text = _attributesesInfoAll[i].Name;
                                        txtSoftDocDescAttr.Text = _attributesesInfoAll[i].Description;
                                        txtSoftDocLocAttr.Text = _attributesesInfoAll[i].Location;
                                        txtSoftDocRevisionAttr.Text = _attributesesInfoAll[i].Revision;
                                        dateSoftDocAttr.Value = _attributesesInfoAll[i].Date != "N/A" ? Convert.ToDateTime(_attributesesInfoAll[i].Date) : DateTime.Now;
                                        break;
                                    }

                                case 1: //Config Item
                                    {
                                        txtCINameAttr.Text = _attributesesInfoAll[i].Name;
                                        txtCILocAttr.Text = _attributesesInfoAll[i].Location;
                                        txtCIDesAttr.Text = _attributesesInfoAll[i].Description;
                                        txtCIRevisionAttr.Text = _attributesesInfoAll[i].Revision;
                                        dateCIAttr.Value = _attributesesInfoAll[i].Date != "N/A" ? Convert.ToDateTime(_attributesesInfoAll[i].Date) : DateTime.Now;
                                        break;
                                    }
                                default: //Config Item DOC
                                    {//Third item
                                        txtCIDocNameAttr.Text = _attributesesInfoAll[i].Name;
                                        txtCIDocDesAttr.Text = _attributesesInfoAll[i].Description;
                                        txtCIDocLocAttr.Text = _attributesesInfoAll[i].Location;
                                        txtCIDocRevisAttr.Text = _attributesesInfoAll[i].Revision;
                                        dateCIDocAttr.Value = _attributesesInfoAll[i].Date != "N/A" ? Convert.ToDateTime(_attributesesInfoAll[i].Date) : DateTime.Now;
                                        break;
                                    }
                            }
                        }

                        //SoftwareDOC is first


                        //ConfigItem is Second
                        //ConfigItemDOC is Last
                        break;
                    }

                case 1: //Fill fields for Software Document
                    {
                        lblSoftwareDoc.Select();

                        chkboxCIAttr.Checked = true;
                        chkboxCIDocAttr.Checked = true;
                        txtSoftDocNameAttr.Text = _attributesInfo.Name;
                        txtSoftDocDescAttr.Text = _attributesInfo.Description;
                        txtSoftDocLocAttr.Text = _attributesInfo.Location;
                        txtSoftDocRevisionAttr.Text = _attributesInfo.Revision;
                        dateSoftDocAttr.Value = Convert.ToDateTime(_attributesInfo.Date);
                        break;
                    }


                case 2:
                    {
                        txtCINameAttr.Focus();
                        chkboxCIDocAttr.Checked = true;
                        chkboxSoftDocAttr.Checked = true;
                        txtCINameAttr.Text = _attributesInfo.Name;
                        txtCILocAttr.Text = _attributesInfo.Location;
                        txtCIDesAttr.Text = _attributesInfo.Description;
                        txtCIRevisionAttr.Text = _attributesInfo.Revision;
                        dateCIAttr.Value = Convert.ToDateTime(_attributesInfo.Date);
                        break;
                    }
                case 3:
                    {
                        chkboxCIAttr.Checked = true;
                        chkboxSoftDocAttr.Checked = true;
                        txtCIDocNameAttr.Focus();
                        txtCIDocNameAttr.Text = _attributesInfo.Name;
                        txtCIDocDesAttr.Text = _attributesInfo.Description;
                        txtCIDocLocAttr.Text = _attributesInfo.Location;
                        txtCIDocRevisAttr.Text = _attributesInfo.Revision;
                        dateCIDocAttr.Value = Convert.ToDateTime(_attributesInfo.Date);
                        break;
                    }
                default:
                    break;
            }
        }

        private void SetTextInsert(int attributeType)
        {
            switch (attributeType)
            {
                case 1: // Software Document
                    lblSoftwareDoc.Select();
                    break;
                case 2: // ConfigItem
                    if (_configItemID == 0)
                        lblConfigItem.Select();
                    else
                        lblConfigItemDOC.Select();
                    break;

                default:
                    break;
            }
        }

        private void btnAttrSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();

            AttributeControl newAttributes = new AttributeControl();

            bool haultFormCloser = false;
            if (!_update)
            {
                if (chkboxSoftDocAttr.Checked == false)
                {
                    if (txtSoftDocNameAttr.Text != String.Empty && txtSoftDocRevisionAttr.Text != String.Empty)
                    {
                        var objSoftware = new SoftwareDoc()
                        {
                            Name = txtSoftDocNameAttr.Text,
                            Date = Convert.ToString(dateSoftDocAttr.Value.Date),
                            Revision = txtSoftDocRevisionAttr.Text,
                            Location = txtSoftDocLocAttr.Text,
                            Description = txtSoftDocDescAttr.Text,
                        };

                        if (newAttributes.submitSoftDoc(objSoftware, _softwareID))
                        {
                            result.Append("Software Document has been added" + Environment.NewLine);
                            chkboxSoftDocAttr.Checked = true;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Please make sure that a Name and Revision for Software Document are filled",
                            "ERROR!", MessageBoxButtons.OK);

                        haultFormCloser = true;
                    }
                }

                if (chkboxCIAttr.Checked == false)
                {
                    if (txtCINameAttr.Text != String.Empty && txtCIRevisionAttr.Text != String.Empty)
                    {
                        var objCI = new CI()
                        {
                            Name = txtCINameAttr.Text.Trim(),
                            Date = Convert.ToString(dateCIAttr.Value.Date),
                            Revision = txtCIRevisionAttr.Text.Trim(),
                            Location = txtCILocAttr.Text.Trim(),
                            Description = txtCIDesAttr.Text.Trim()
                        };

                        if (newAttributes.submitCI(objCI, _softwareID))
                        {
                            result.Append("Configuration Item added" + Environment.NewLine);
                            chkboxCIAttr.Checked = true;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Please make sure that a Name and Revision for Configuration Item are filled",
                            "ERROR!", MessageBoxButtons.OK);
                        haultFormCloser = true;
                    }
                }

                if (chkboxCIDocAttr.Checked == false)
                {
                    if (txtCIDocNameAttr.Text != String.Empty && txtCIDocRevisAttr.Text != String.Empty)
                    {
                        var objCIDoc = new CIDocs()
                        {

                            Name = txtCIDocNameAttr.Text.Trim(),
                            Date = Convert.ToString(dateCIDocAttr.Value.Date),
                            Revision = txtCIDocRevisAttr.Text.Trim(),
                            Location = txtCIDocLocAttr.Text.Trim(),
                            Description = txtCIDocDesAttr.Text.Trim()
                        };

                        if (newAttributes.submitCIDoc(objCIDoc, _configItemID))
                        {
                            result.Append("CI Document Added" + Environment.NewLine);
                            chkboxCIDocAttr.Checked = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please make sure that a Name and Revision for Configuration Item Document are filled", "ERROR!", MessageBoxButtons.OK);
                        haultFormCloser = true;
                    }

                }

                MessageBox.Show(result.ToString(), "Adding Attribute(s) Result:", MessageBoxButtons.OK);

                if (!haultFormCloser)
                {
                   
                    _myDashBoard.UpdateGrid(sender, e);
                    this.Close();
                }
               
            }
            else
            {
                AttributeControl updateAttributeControl = new AttributeControl();


                //MessageBox.Show("Update", "Message", MessageBoxButtons.OK);

                if (chkboxSoftDocAttr.Checked == false)
                {
                    var objSoftware = new SoftwareDoc()
                    {
                        ID = (_attributesInfo != null ? _attributesInfo.ID : _attributesesInfoAll[0].ID),
                        Name = txtSoftDocNameAttr.Text.Trim(),
                        Date = Convert.ToString(dateSoftDocAttr.Value.Date),
                        Revision = txtSoftDocRevisionAttr.Text.Trim(),
                        Location = txtSoftDocLocAttr.Text.Trim(),
                        Description = txtSoftDocDescAttr.Text.Trim(),
                    };

                    if (updateAttributeControl.updateSoftDoc(objSoftware, lblSoftwareID.Text))
                    {
                        result.Append("Software Document has been updated" + Environment.NewLine);
                    }




                }

                if (chkboxCIAttr.Checked == false)
                {
                    var objCI = new CI()
                    {
                        ID = (_attributesInfo != null ? _attributesInfo.ID : _attributesesInfoAll[1].ID),
                        Name = txtCINameAttr.Text.Trim(),
                        Date = Convert.ToString(dateCIAttr.Value.Date),
                        Revision = txtCIRevisionAttr.Text.Trim(),
                        Location = txtCILocAttr.Text.Trim(),
                        Description = txtCIDesAttr.Text.Trim()
                    };

                    if (updateAttributeControl.updateConfigItem(objCI, lblSoftwareID.Text))
                    {
                        result.Append("ConfigItem updated" + Environment.NewLine);
                    }


                }

                if (chkboxCIDocAttr.Checked == false)
                {
                    var objCIDoc = new CIDocs()
                    {
                        ID = (_attributesInfo != null ? _attributesInfo.ID : _attributesesInfoAll[2].ID),
                        Name = txtCIDocNameAttr.Text.Trim(),
                        Date = Convert.ToString(dateCIDocAttr.Value.Date),
                        Revision = txtCIDocRevisAttr.Text.Trim(),
                        Location = txtCIDocLocAttr.Text.Trim(),
                        Description = txtCIDocDesAttr.Text.Trim()
                    };

                    if (updateAttributeControl.updateConfigItemDoc(objCIDoc, lblSoftwareID.Text))
                    {
                        result.Append("ConfigItem Doc updated" + Environment.NewLine);
                    }


                }


                MessageBox.Show(result.ToString(), "Update Attribute(s) Result", MessageBoxButtons.OK);
                _attributes.RefreshGrid(sender, e);
                this.Close();



            }


        }

        private void btnAttrSubmit_MouseHover(object sender, EventArgs e)
        {
            btnAttrSubmit.BackColor = Color.CornflowerBlue;

        }

        private void btnAttrSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnAttrSubmit.BackColor = Color.Empty;
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
