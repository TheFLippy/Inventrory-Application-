﻿namespace Inventory
{
    partial class MainMenu
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
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.btnAddPackage = new System.Windows.Forms.Button();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcomeMsg = new System.Windows.Forms.Label();
            this.btnManageVans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solar Transport and Delivery";
            // 
            // btnManageEmployees
            // 
            this.btnManageEmployees.Location = new System.Drawing.Point(72, 51);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(244, 28);
            this.btnManageEmployees.TabIndex = 1;
            this.btnManageEmployees.Text = "Manage Employees";
            this.btnManageEmployees.UseVisualStyleBackColor = true;
            this.btnManageEmployees.Click += new System.EventHandler(this.btnManageEmployees_Click);
            // 
            // btnAddPackage
            // 
            this.btnAddPackage.Location = new System.Drawing.Point(72, 141);
            this.btnAddPackage.Name = "btnAddPackage";
            this.btnAddPackage.Size = new System.Drawing.Size(244, 28);
            this.btnAddPackage.TabIndex = 2;
            this.btnAddPackage.Text = "Add Package";
            this.btnAddPackage.UseVisualStyleBackColor = true;
            this.btnAddPackage.Click += new System.EventHandler(this.btnAddPackage_Click);
            // 
            // btnViewInventory
            // 
            this.btnViewInventory.Location = new System.Drawing.Point(71, 187);
            this.btnViewInventory.Name = "btnViewInventory";
            this.btnViewInventory.Size = new System.Drawing.Size(244, 28);
            this.btnViewInventory.TabIndex = 3;
            this.btnViewInventory.Text = "View Inventory";
            this.btnViewInventory.UseVisualStyleBackColor = true;
            this.btnViewInventory.Click += new System.EventHandler(this.btnViewIntentory_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(71, 232);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(244, 28);
            this.button4.TabIndex = 4;
            this.button4.Text = "Assign deliveries";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(72, 335);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(244, 28);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblWelcomeMsg
            // 
            this.lblWelcomeMsg.AutoSize = true;
            this.lblWelcomeMsg.Location = new System.Drawing.Point(183, 428);
            this.lblWelcomeMsg.MinimumSize = new System.Drawing.Size(200, 10);
            this.lblWelcomeMsg.Name = "lblWelcomeMsg";
            this.lblWelcomeMsg.Size = new System.Drawing.Size(200, 13);
            this.lblWelcomeMsg.TabIndex = 6;
            // 
            // btnManageVans
            // 
            this.btnManageVans.Location = new System.Drawing.Point(72, 96);
            this.btnManageVans.Name = "btnManageVans";
            this.btnManageVans.Size = new System.Drawing.Size(244, 28);
            this.btnManageVans.TabIndex = 7;
            this.btnManageVans.Text = "Manage Vans";
            this.btnManageVans.UseVisualStyleBackColor = true;
            this.btnManageVans.Click += new System.EventHandler(this.btnManageVans_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 450);
            this.Controls.Add(this.btnManageVans);
            this.Controls.Add(this.lblWelcomeMsg);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnViewInventory);
            this.Controls.Add(this.btnAddPackage);
            this.Controls.Add(this.btnManageEmployees);
            this.Controls.Add(this.label1);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageEmployees;
        private System.Windows.Forms.Button btnAddPackage;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcomeMsg;
        private System.Windows.Forms.Button btnManageVans;
    }
}