namespace Inventory.Forms
{
    partial class EditEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEmployee));
            this.rbDriver = new System.Windows.Forms.RadioButton();
            this.rbClerk = new System.Windows.Forms.RadioButton();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEditSurname = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEditConfirmPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEditNewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEditUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEditOldPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rbDriver
            // 
            this.rbDriver.AutoSize = true;
            this.rbDriver.Location = new System.Drawing.Point(314, 271);
            this.rbDriver.Name = "rbDriver";
            this.rbDriver.Size = new System.Drawing.Size(53, 17);
            this.rbDriver.TabIndex = 21;
            this.rbDriver.TabStop = true;
            this.rbDriver.Text = "Driver";
            this.rbDriver.UseVisualStyleBackColor = true;
            this.rbDriver.CheckedChanged += new System.EventHandler(this.rbDriver_CheckedChanged);
            // 
            // rbClerk
            // 
            this.rbClerk.AutoSize = true;
            this.rbClerk.Location = new System.Drawing.Point(239, 271);
            this.rbClerk.Name = "rbClerk";
            this.rbClerk.Size = new System.Drawing.Size(49, 17);
            this.rbClerk.TabIndex = 19;
            this.rbClerk.TabStop = true;
            this.rbClerk.Text = "Clerk";
            this.rbClerk.UseVisualStyleBackColor = true;
            this.rbClerk.CheckedChanged += new System.EventHandler(this.rbClerk_CheckedChanged);
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Location = new System.Drawing.Point(153, 271);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(54, 17);
            this.rbAdmin.TabIndex = 18;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "Admin";
            this.rbAdmin.UseVisualStyleBackColor = true;
            this.rbAdmin.CheckedChanged += new System.EventHandler(this.rbAdmin_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Surname";
            // 
            // txtEditSurname
            // 
            this.txtEditSurname.Location = new System.Drawing.Point(198, 227);
            this.txtEditSurname.Name = "txtEditSurname";
            this.txtEditSurname.Size = new System.Drawing.Size(154, 20);
            this.txtEditSurname.TabIndex = 16;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(408, 331);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(408, 302);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Confirm Password";
            // 
            // txtEditConfirmPassword
            // 
            this.txtEditConfirmPassword.Location = new System.Drawing.Point(198, 156);
            this.txtEditConfirmPassword.Name = "txtEditConfirmPassword";
            this.txtEditConfirmPassword.PasswordChar = '*';
            this.txtEditConfirmPassword.Size = new System.Drawing.Size(154, 20);
            this.txtEditConfirmPassword.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Name";
            // 
            // txtEditName
            // 
            this.txtEditName.Location = new System.Drawing.Point(198, 192);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(154, 20);
            this.txtEditName.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "New Password";
            // 
            // txtEditNewPassword
            // 
            this.txtEditNewPassword.Location = new System.Drawing.Point(198, 121);
            this.txtEditNewPassword.Name = "txtEditNewPassword";
            this.txtEditNewPassword.PasswordChar = '*';
            this.txtEditNewPassword.Size = new System.Drawing.Size(154, 20);
            this.txtEditNewPassword.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Username";
            // 
            // txtEditUsername
            // 
            this.txtEditUsername.Location = new System.Drawing.Point(198, 50);
            this.txtEditUsername.Name = "txtEditUsername";
            this.txtEditUsername.Size = new System.Drawing.Size(154, 20);
            this.txtEditUsername.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Old Password";
            // 
            // txtEditOldPassword
            // 
            this.txtEditOldPassword.Location = new System.Drawing.Point(198, 85);
            this.txtEditOldPassword.Name = "txtEditOldPassword";
            this.txtEditOldPassword.PasswordChar = '*';
            this.txtEditOldPassword.Size = new System.Drawing.Size(154, 20);
            this.txtEditOldPassword.TabIndex = 26;
            // 
            // EditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 366);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEditOldPassword);
            this.Controls.Add(this.rbDriver);
            this.Controls.Add(this.rbClerk);
            this.Controls.Add(this.rbAdmin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEditSurname);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEditConfirmPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEditName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEditNewPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEditUsername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditEmployee";
            this.Load += new System.EventHandler(this.EditEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDriver;
        private System.Windows.Forms.RadioButton rbClerk;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEditSurname;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEditConfirmPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEditName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEditNewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEditUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEditOldPassword;
    }
}