namespace SoftwareConfigurationManagementDBApp
{
    partial class CIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CIForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblCIName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCIName = new System.Windows.Forms.TextBox();
            this.txtCIRevision = new System.Windows.Forms.TextBox();
            this.txtCILocation = new System.Windows.Forms.TextBox();
            this.txtCIInfoCI = new System.Windows.Forms.TextBox();
            this.btnSubmitCI = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CIDate = new System.Windows.Forms.DateTimePicker();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "CI";
            // 
            // lblCIName
            // 
            this.lblCIName.AutoSize = true;
            this.lblCIName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCIName.Location = new System.Drawing.Point(69, 114);
            this.lblCIName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCIName.Name = "lblCIName";
            this.lblCIName.Size = new System.Drawing.Size(59, 23);
            this.lblCIName.TabIndex = 1;
            this.lblCIName.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Revision";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(68, 231);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(84, 23);
            this.lbl.TabIndex = 3;
            this.lbl.Text = "Location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 281);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description";
            // 
            // txtCIName
            // 
            this.txtCIName.Location = new System.Drawing.Point(165, 116);
            this.txtCIName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCIName.Name = "txtCIName";
            this.txtCIName.Size = new System.Drawing.Size(225, 22);
            this.txtCIName.TabIndex = 6;
            // 
            // txtCIRevision
            // 
            this.txtCIRevision.Location = new System.Drawing.Point(160, 192);
            this.txtCIRevision.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCIRevision.Name = "txtCIRevision";
            this.txtCIRevision.Size = new System.Drawing.Size(231, 22);
            this.txtCIRevision.TabIndex = 7;
            // 
            // txtCILocation
            // 
            this.txtCILocation.Location = new System.Drawing.Point(160, 231);
            this.txtCILocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCILocation.Name = "txtCILocation";
            this.txtCILocation.Size = new System.Drawing.Size(231, 22);
            this.txtCILocation.TabIndex = 8;
            // 
            // txtCIInfoCI
            // 
            this.txtCIInfoCI.Location = new System.Drawing.Point(160, 282);
            this.txtCIInfoCI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCIInfoCI.Multiline = true;
            this.txtCIInfoCI.Name = "txtCIInfoCI";
            this.txtCIInfoCI.Size = new System.Drawing.Size(528, 121);
            this.txtCIInfoCI.TabIndex = 10;
            // 
            // btnSubmitCI
            // 
            this.btnSubmitCI.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitCI.Location = new System.Drawing.Point(165, 440);
            this.btnSubmitCI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmitCI.Name = "btnSubmitCI";
            this.btnSubmitCI.Size = new System.Drawing.Size(128, 46);
            this.btnSubmitCI.TabIndex = 12;
            this.btnSubmitCI.Text = "Submit";
            this.btnSubmitCI.UseVisualStyleBackColor = true;
            this.btnSubmitCI.Click += new System.EventHandler(this.btnSubmitCI_Click);
            this.btnSubmitCI.MouseLeave += new System.EventHandler(this.btnSubmitCI_MouseLeave);
            this.btnSubmitCI.MouseHover += new System.EventHandler(this.btnSubmitCI_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Date";
            // 
            // CIDate
            // 
            this.CIDate.Location = new System.Drawing.Point(160, 154);
            this.CIDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CIDate.Name = "CIDate";
            this.CIDate.Size = new System.Drawing.Size(231, 22);
            this.CIDate.TabIndex = 14;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(441, 440);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(128, 46);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // CIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(737, 513);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.CIDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubmitCI);
            this.Controls.Add(this.txtCIInfoCI);
            this.Controls.Add(this.txtCILocation);
            this.Controls.Add(this.txtCIRevision);
            this.Controls.Add(this.txtCIName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCIName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CIForm";
            this.Text = "CIForm";
            this.Load += new System.EventHandler(this.CIForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCIName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCIName;
        private System.Windows.Forms.TextBox txtCIRevision;
        private System.Windows.Forms.TextBox txtCILocation;
        private System.Windows.Forms.TextBox txtCIInfoCI;
        private System.Windows.Forms.Button btnSubmitCI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker CIDate;
        private System.Windows.Forms.Button btnBack;
    }
}