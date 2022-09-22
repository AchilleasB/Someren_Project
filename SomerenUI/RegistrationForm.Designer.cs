namespace SomerenUI
{
    partial class RegistrationForm
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
            this.lblRegistrationUsername = new System.Windows.Forms.Label();
            this.btnRegistrationSubmit = new System.Windows.Forms.Button();
            this.txtBoxRegistrationUsername = new System.Windows.Forms.TextBox();
            this.grpBoxRegistration = new System.Windows.Forms.GroupBox();
            this.lblRegistrationMsg = new System.Windows.Forms.Label();
            this.txtBoxRegistrationLicenseKey = new System.Windows.Forms.TextBox();
            this.lblRegistrationLicenseKey = new System.Windows.Forms.Label();
            this.txtBoxRegistrationPassword = new System.Windows.Forms.TextBox();
            this.lblRegistrationPassword = new System.Windows.Forms.Label();
            this.btnRegistrationCancel = new System.Windows.Forms.Button();
            this.txtBoxRegistrationName = new System.Windows.Forms.TextBox();
            this.lblRegistrationName = new System.Windows.Forms.Label();
            this.txtBoxRegistrationEmail = new System.Windows.Forms.TextBox();
            this.lblRegistrationEmail = new System.Windows.Forms.Label();
            this.grpBoxRegistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRegistrationUsername
            // 
            this.lblRegistrationUsername.AutoSize = true;
            this.lblRegistrationUsername.Location = new System.Drawing.Point(55, 59);
            this.lblRegistrationUsername.Name = "lblRegistrationUsername";
            this.lblRegistrationUsername.Size = new System.Drawing.Size(118, 25);
            this.lblRegistrationUsername.TabIndex = 0;
            this.lblRegistrationUsername.Text = "Username*";
            // 
            // btnRegistrationSubmit
            // 
            this.btnRegistrationSubmit.Location = new System.Drawing.Point(92, 864);
            this.btnRegistrationSubmit.Name = "btnRegistrationSubmit";
            this.btnRegistrationSubmit.Size = new System.Drawing.Size(183, 66);
            this.btnRegistrationSubmit.TabIndex = 1;
            this.btnRegistrationSubmit.Text = "Submit";
            this.btnRegistrationSubmit.UseVisualStyleBackColor = true;
            this.btnRegistrationSubmit.Click += new System.EventHandler(this.btnRegistrationSubmit_Click);
            // 
            // txtBoxRegistrationUsername
            // 
            this.txtBoxRegistrationUsername.Location = new System.Drawing.Point(60, 96);
            this.txtBoxRegistrationUsername.Name = "txtBoxRegistrationUsername";
            this.txtBoxRegistrationUsername.Size = new System.Drawing.Size(230, 31);
            this.txtBoxRegistrationUsername.TabIndex = 2;
            // 
            // grpBoxRegistration
            // 
            this.grpBoxRegistration.Controls.Add(this.txtBoxRegistrationEmail);
            this.grpBoxRegistration.Controls.Add(this.lblRegistrationEmail);
            this.grpBoxRegistration.Controls.Add(this.txtBoxRegistrationName);
            this.grpBoxRegistration.Controls.Add(this.lblRegistrationName);
            this.grpBoxRegistration.Controls.Add(this.lblRegistrationMsg);
            this.grpBoxRegistration.Controls.Add(this.txtBoxRegistrationLicenseKey);
            this.grpBoxRegistration.Controls.Add(this.lblRegistrationLicenseKey);
            this.grpBoxRegistration.Controls.Add(this.txtBoxRegistrationPassword);
            this.grpBoxRegistration.Controls.Add(this.lblRegistrationPassword);
            this.grpBoxRegistration.Controls.Add(this.txtBoxRegistrationUsername);
            this.grpBoxRegistration.Controls.Add(this.lblRegistrationUsername);
            this.grpBoxRegistration.Location = new System.Drawing.Point(32, 33);
            this.grpBoxRegistration.Name = "grpBoxRegistration";
            this.grpBoxRegistration.Size = new System.Drawing.Size(580, 779);
            this.grpBoxRegistration.TabIndex = 3;
            this.grpBoxRegistration.TabStop = false;
            this.grpBoxRegistration.Text = "SignUp";
            // 
            // lblRegistrationMsg
            // 
            this.lblRegistrationMsg.AutoSize = true;
            this.lblRegistrationMsg.Location = new System.Drawing.Point(123, 718);
            this.lblRegistrationMsg.Name = "lblRegistrationMsg";
            this.lblRegistrationMsg.Size = new System.Drawing.Size(0, 25);
            this.lblRegistrationMsg.TabIndex = 7;
            // 
            // txtBoxRegistrationLicenseKey
            // 
            this.txtBoxRegistrationLicenseKey.Location = new System.Drawing.Point(60, 629);
            this.txtBoxRegistrationLicenseKey.Name = "txtBoxRegistrationLicenseKey";
            this.txtBoxRegistrationLicenseKey.Size = new System.Drawing.Size(447, 31);
            this.txtBoxRegistrationLicenseKey.TabIndex = 6;
            // 
            // lblRegistrationLicenseKey
            // 
            this.lblRegistrationLicenseKey.AutoSize = true;
            this.lblRegistrationLicenseKey.Location = new System.Drawing.Point(55, 591);
            this.lblRegistrationLicenseKey.Name = "lblRegistrationLicenseKey";
            this.lblRegistrationLicenseKey.Size = new System.Drawing.Size(138, 25);
            this.lblRegistrationLicenseKey.TabIndex = 5;
            this.lblRegistrationLicenseKey.Text = "License Key*";
            // 
            // txtBoxRegistrationPassword
            // 
            this.txtBoxRegistrationPassword.Location = new System.Drawing.Point(60, 223);
            this.txtBoxRegistrationPassword.Name = "txtBoxRegistrationPassword";
            this.txtBoxRegistrationPassword.Size = new System.Drawing.Size(230, 31);
            this.txtBoxRegistrationPassword.TabIndex = 4;
            this.txtBoxRegistrationPassword.UseSystemPasswordChar = true;
            // 
            // lblRegistrationPassword
            // 
            this.lblRegistrationPassword.AutoSize = true;
            this.lblRegistrationPassword.Location = new System.Drawing.Point(55, 186);
            this.lblRegistrationPassword.Name = "lblRegistrationPassword";
            this.lblRegistrationPassword.Size = new System.Drawing.Size(114, 25);
            this.lblRegistrationPassword.TabIndex = 3;
            this.lblRegistrationPassword.Text = "Password*";
            // 
            // btnRegistrationCancel
            // 
            this.btnRegistrationCancel.Location = new System.Drawing.Point(356, 864);
            this.btnRegistrationCancel.Name = "btnRegistrationCancel";
            this.btnRegistrationCancel.Size = new System.Drawing.Size(183, 66);
            this.btnRegistrationCancel.TabIndex = 4;
            this.btnRegistrationCancel.Text = "Cancel";
            this.btnRegistrationCancel.UseVisualStyleBackColor = true;
            this.btnRegistrationCancel.Click += new System.EventHandler(this.btnRegistrationCancel_Click);
            // 
            // txtBoxRegistrationName
            // 
            this.txtBoxRegistrationName.Location = new System.Drawing.Point(60, 361);
            this.txtBoxRegistrationName.Name = "txtBoxRegistrationName";
            this.txtBoxRegistrationName.Size = new System.Drawing.Size(230, 31);
            this.txtBoxRegistrationName.TabIndex = 9;
            // 
            // lblRegistrationName
            // 
            this.lblRegistrationName.AutoSize = true;
            this.lblRegistrationName.Location = new System.Drawing.Point(55, 324);
            this.lblRegistrationName.Name = "lblRegistrationName";
            this.lblRegistrationName.Size = new System.Drawing.Size(76, 25);
            this.lblRegistrationName.TabIndex = 8;
            this.lblRegistrationName.Text = "Name*";
            // 
            // txtBoxRegistrationEmail
            // 
            this.txtBoxRegistrationEmail.Location = new System.Drawing.Point(60, 491);
            this.txtBoxRegistrationEmail.Name = "txtBoxRegistrationEmail";
            this.txtBoxRegistrationEmail.Size = new System.Drawing.Size(447, 31);
            this.txtBoxRegistrationEmail.TabIndex = 11;
            // 
            // lblRegistrationEmail
            // 
            this.lblRegistrationEmail.AutoSize = true;
            this.lblRegistrationEmail.Location = new System.Drawing.Point(55, 454);
            this.lblRegistrationEmail.Name = "lblRegistrationEmail";
            this.lblRegistrationEmail.Size = new System.Drawing.Size(73, 25);
            this.lblRegistrationEmail.TabIndex = 10;
            this.lblRegistrationEmail.Text = "Email*";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 975);
            this.Controls.Add(this.btnRegistrationCancel);
            this.Controls.Add(this.grpBoxRegistration);
            this.Controls.Add(this.btnRegistrationSubmit);
            this.Name = "RegistrationForm";
            this.Text = "Registration";
            this.grpBoxRegistration.ResumeLayout(false);
            this.grpBoxRegistration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRegistrationUsername;
        private System.Windows.Forms.Button btnRegistrationSubmit;
        private System.Windows.Forms.TextBox txtBoxRegistrationUsername;
        private System.Windows.Forms.GroupBox grpBoxRegistration;
        private System.Windows.Forms.TextBox txtBoxRegistrationPassword;
        private System.Windows.Forms.Label lblRegistrationPassword;
        private System.Windows.Forms.Button btnRegistrationCancel;
        private System.Windows.Forms.TextBox txtBoxRegistrationLicenseKey;
        private System.Windows.Forms.Label lblRegistrationLicenseKey;
        private System.Windows.Forms.Label lblRegistrationMsg;
        private System.Windows.Forms.TextBox txtBoxRegistrationEmail;
        private System.Windows.Forms.Label lblRegistrationEmail;
        private System.Windows.Forms.TextBox txtBoxRegistrationName;
        private System.Windows.Forms.Label lblRegistrationName;
    }
}