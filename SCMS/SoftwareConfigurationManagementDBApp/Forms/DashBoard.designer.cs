namespace SoftwareConfigurationManagementDBApp
{
    partial class DashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            this.btnLogOut = new System.Windows.Forms.Button();
            this.viewlb = new System.Windows.Forms.Label();
            this.cmbDataViews = new System.Windows.Forms.ComboBox();
            this.btnViewAttr = new System.Windows.Forms.Button();
            this.btnAddAttr = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteSoft = new System.Windows.Forms.Button();
            this.btnEditSoftw = new System.Windows.Forms.Button();
            this.btnAddSoftw = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.ddlGroups = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpAdmin = new System.Windows.Forms.GroupBox();
            this.btnViewUser = new System.Windows.Forms.Button();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.grpDataViewing = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpAdmin.SuspendLayout();
            this.grpAttributes.SuspendLayout();
            this.grpDataViewing.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(156, 866);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(129, 48);
            this.btnLogOut.TabIndex = 38;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // viewlb
            // 
            this.viewlb.AutoSize = true;
            this.viewlb.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewlb.Location = new System.Drawing.Point(148, 143);
            this.viewlb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.viewlb.Name = "viewlb";
            this.viewlb.Size = new System.Drawing.Size(93, 41);
            this.viewlb.TabIndex = 37;
            this.viewlb.Text = "View";
            // 
            // cmbDataViews
            // 
            this.cmbDataViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataViews.FormattingEnabled = true;
            this.cmbDataViews.Items.AddRange(new object[] {
            "Software Overview",
            "Software View",
            "All Software"});
            this.cmbDataViews.Location = new System.Drawing.Point(86, 226);
            this.cmbDataViews.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDataViews.Name = "cmbDataViews";
            this.cmbDataViews.Size = new System.Drawing.Size(230, 28);
            this.cmbDataViews.TabIndex = 36;
            this.cmbDataViews.SelectedIndexChanged += new System.EventHandler(this.selectView);
            // 
            // btnViewAttr
            // 
            this.btnViewAttr.Location = new System.Drawing.Point(30, 43);
            this.btnViewAttr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewAttr.Name = "btnViewAttr";
            this.btnViewAttr.Size = new System.Drawing.Size(129, 48);
            this.btnViewAttr.TabIndex = 35;
            this.btnViewAttr.Text = "View Attributes";
            this.btnViewAttr.UseVisualStyleBackColor = true;
            this.btnViewAttr.Click += new System.EventHandler(this.btnViewAttr_Click);
            // 
            // btnAddAttr
            // 
            this.btnAddAttr.Location = new System.Drawing.Point(30, 28);
            this.btnAddAttr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddAttr.Name = "btnAddAttr";
            this.btnAddAttr.Size = new System.Drawing.Size(129, 48);
            this.btnAddAttr.TabIndex = 32;
            this.btnAddAttr.Text = "Add Attribute";
            this.btnAddAttr.UseVisualStyleBackColor = true;
            this.btnAddAttr.Click += new System.EventHandler(this.btnAddAttr_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(32, 272);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(129, 48);
            this.btnAddUser.TabIndex = 30;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteSoft
            // 
            this.btnDeleteSoft.Location = new System.Drawing.Point(32, 177);
            this.btnDeleteSoft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteSoft.Name = "btnDeleteSoft";
            this.btnDeleteSoft.Size = new System.Drawing.Size(129, 71);
            this.btnDeleteSoft.TabIndex = 29;
            this.btnDeleteSoft.Text = "Delete Software";
            this.btnDeleteSoft.UseVisualStyleBackColor = true;
            this.btnDeleteSoft.Click += new System.EventHandler(this.btnDeleteSoft_Click);
            // 
            // btnEditSoftw
            // 
            this.btnEditSoftw.Location = new System.Drawing.Point(32, 98);
            this.btnEditSoftw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditSoftw.Name = "btnEditSoftw";
            this.btnEditSoftw.Size = new System.Drawing.Size(129, 48);
            this.btnEditSoftw.TabIndex = 28;
            this.btnEditSoftw.Text = "Edit Software";
            this.btnEditSoftw.UseVisualStyleBackColor = true;
            this.btnEditSoftw.Click += new System.EventHandler(this.btnEditSoftw_Click);
            // 
            // btnAddSoftw
            // 
            this.btnAddSoftw.Location = new System.Drawing.Point(32, 28);
            this.btnAddSoftw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddSoftw.Name = "btnAddSoftw";
            this.btnAddSoftw.Size = new System.Drawing.Size(129, 48);
            this.btnAddSoftw.TabIndex = 27;
            this.btnAddSoftw.Text = "Add Software";
            this.btnAddSoftw.UseVisualStyleBackColor = true;
            this.btnAddSoftw.Click += new System.EventHandler(this.btnAddSoftw_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(447, 171);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1149, 760);
            this.dataGridView1.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 55);
            this.label1.TabIndex = 40;
            this.label1.Text = "DashBoard";
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Location = new System.Drawing.Point(30, 111);
            this.btnPrintReport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(129, 48);
            this.btnPrintReport.TabIndex = 41;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // ddlGroups
            // 
            this.ddlGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGroups.FormattingEnabled = true;
            this.ddlGroups.Location = new System.Drawing.Point(180, 188);
            this.ddlGroups.Name = "ddlGroups";
            this.ddlGroups.Size = new System.Drawing.Size(121, 28);
            this.ddlGroups.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Select Group:";
            // 
            // grpAdmin
            // 
            this.grpAdmin.Controls.Add(this.btnReset);
            this.grpAdmin.Controls.Add(this.btnViewUser);
            this.grpAdmin.Controls.Add(this.btnAddSoftw);
            this.grpAdmin.Controls.Add(this.btnEditSoftw);
            this.grpAdmin.Controls.Add(this.btnDeleteSoft);
            this.grpAdmin.Controls.Add(this.btnAddUser);
            this.grpAdmin.Location = new System.Drawing.Point(14, 320);
            this.grpAdmin.Name = "grpAdmin";
            this.grpAdmin.Size = new System.Drawing.Size(180, 477);
            this.grpAdmin.TabIndex = 44;
            this.grpAdmin.TabStop = false;
            this.grpAdmin.Text = "Admin Functions";
            // 
            // btnViewUser
            // 
            this.btnViewUser.Location = new System.Drawing.Point(32, 348);
            this.btnViewUser.Name = "btnViewUser";
            this.btnViewUser.Size = new System.Drawing.Size(129, 45);
            this.btnViewUser.TabIndex = 31;
            this.btnViewUser.Text = "View Users";
            this.btnViewUser.UseVisualStyleBackColor = true;
            this.btnViewUser.Click += new System.EventHandler(this.btnViewUser_Click);
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.btnAddAttr);
            this.grpAttributes.Location = new System.Drawing.Point(213, 320);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Size = new System.Drawing.Size(198, 97);
            this.grpAttributes.TabIndex = 45;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "Add Attributes";
            // 
            // grpDataViewing
            // 
            this.grpDataViewing.Controls.Add(this.btnViewAttr);
            this.grpDataViewing.Controls.Add(this.btnPrintReport);
            this.grpDataViewing.Location = new System.Drawing.Point(213, 538);
            this.grpDataViewing.Name = "grpDataViewing";
            this.grpDataViewing.Size = new System.Drawing.Size(198, 174);
            this.grpDataViewing.TabIndex = 46;
            this.grpDataViewing.TabStop = false;
            this.grpDataViewing.Text = "View Attributes and Print";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(32, 418);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(129, 42);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "Reset App";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.ResetSCMSApp);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1689, 945);
            this.Controls.Add(this.grpDataViewing);
            this.Controls.Add(this.grpAttributes);
            this.Controls.Add(this.grpAdmin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlGroups);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.viewlb);
            this.Controls.Add(this.cmbDataViews);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpAdmin.ResumeLayout(false);
            this.grpAttributes.ResumeLayout(false);
            this.grpDataViewing.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label viewlb;
        private System.Windows.Forms.ComboBox cmbDataViews;
        private System.Windows.Forms.Button btnViewAttr;
        private System.Windows.Forms.Button btnAddAttr;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteSoft;
        private System.Windows.Forms.Button btnEditSoftw;
        private System.Windows.Forms.Button btnAddSoftw;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.ComboBox ddlGroups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpAdmin;
        private System.Windows.Forms.GroupBox grpAttributes;
        private System.Windows.Forms.GroupBox grpDataViewing;
        private System.Windows.Forms.Button btnViewUser;
        private System.Windows.Forms.Button btnReset;
    }
}