namespace SoftwareConfigurationManagementDBApp
{
    partial class Pathway
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathway = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pnlCredentials = new System.Windows.Forms.Panel();
            this.chkViewFormB = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please specify the pathway";
            // 
            // txtPathway
            // 
            this.txtPathway.Location = new System.Drawing.Point(66, 123);
            this.txtPathway.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPathway.Name = "txtPathway";
            this.txtPathway.Size = new System.Drawing.Size(336, 26);
            this.txtPathway.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(168, 336);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(144, 55);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "connect";
            this.btnConnect.UseMnemonic = false;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pnlCredentials
            // 
            this.pnlCredentials.Controls.Add(this.label3);
            this.pnlCredentials.Controls.Add(this.label2);
            this.pnlCredentials.Controls.Add(this.txtUserName);
            this.pnlCredentials.Controls.Add(this.txtPassword);
            this.pnlCredentials.Location = new System.Drawing.Point(66, 186);
            this.pnlCredentials.Name = "pnlCredentials";
            this.pnlCredentials.Size = new System.Drawing.Size(357, 123);
            this.pnlCredentials.TabIndex = 3;
            // 
            // chkViewFormB
            // 
            this.chkViewFormB.AutoSize = true;
            this.chkViewFormB.Location = new System.Drawing.Point(130, 157);
            this.chkViewFormB.Name = "chkViewFormB";
            this.chkViewFormB.Size = new System.Drawing.Size(246, 24);
            this.chkViewFormB.TabIndex = 4;
            this.chkViewFormB.Text = "Add Username and Password";
            this.chkViewFormB.UseVisualStyleBackColor = true;
            this.chkViewFormB.Click += new System.EventHandler(this.ShowUserNameAndPassword);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(156, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(130, 26);
            this.txtPassword.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(156, 27);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(130, 26);
            this.txtUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // Pathway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(465, 428);
            this.Controls.Add(this.chkViewFormB);
            this.Controls.Add(this.pnlCredentials);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPathway);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Pathway";
            this.Text = "Pathway";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pathway_Closing);
            this.pnlCredentials.ResumeLayout(false);
            this.pnlCredentials.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathway;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel pnlCredentials;
        private System.Windows.Forms.CheckBox chkViewFormB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
    }
}