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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.btnDeliveries = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcomeMsg = new System.Windows.Forms.Label();
            this.btnManageVans = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNotification = new System.Windows.Forms.Label();
            this.picNotification = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // btnManageEmployees
            // 
            this.btnManageEmployees.BackColor = System.Drawing.Color.Transparent;
            this.btnManageEmployees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnManageEmployees.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnManageEmployees.FlatAppearance.BorderSize = 0;
            this.btnManageEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageEmployees.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageEmployees.Image = ((System.Drawing.Image)(resources.GetObject("btnManageEmployees.Image")));
            this.btnManageEmployees.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManageEmployees.Location = new System.Drawing.Point(188, 155);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(120, 120);
            this.btnManageEmployees.TabIndex = 0;
            this.btnManageEmployees.Text = "Employees";
            this.btnManageEmployees.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnManageEmployees, "Manage Employee details");
            this.btnManageEmployees.UseVisualStyleBackColor = false;
            this.btnManageEmployees.Click += new System.EventHandler(this.btnManageEmployees_Click);
            // 
            // btnViewInventory
            // 
            this.btnViewInventory.BackColor = System.Drawing.Color.Transparent;
            this.btnViewInventory.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnViewInventory.FlatAppearance.BorderSize = 0;
            this.btnViewInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewInventory.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnViewInventory.Image")));
            this.btnViewInventory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnViewInventory.Location = new System.Drawing.Point(188, 307);
            this.btnViewInventory.Name = "btnViewInventory";
            this.btnViewInventory.Size = new System.Drawing.Size(120, 120);
            this.btnViewInventory.TabIndex = 2;
            this.btnViewInventory.Text = "Inventory";
            this.btnViewInventory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnViewInventory, "Manage Package details");
            this.btnViewInventory.UseVisualStyleBackColor = false;
            this.btnViewInventory.Click += new System.EventHandler(this.btnViewIntentory_Click);
            // 
            // btnDeliveries
            // 
            this.btnDeliveries.BackColor = System.Drawing.Color.Transparent;
            this.btnDeliveries.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeliveries.FlatAppearance.BorderSize = 0;
            this.btnDeliveries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeliveries.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliveries.Image = ((System.Drawing.Image)(resources.GetObject("btnDeliveries.Image")));
            this.btnDeliveries.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeliveries.Location = new System.Drawing.Point(433, 307);
            this.btnDeliveries.Name = "btnDeliveries";
            this.btnDeliveries.Size = new System.Drawing.Size(120, 120);
            this.btnDeliveries.TabIndex = 3;
            this.btnDeliveries.Text = "Deliveries";
            this.btnDeliveries.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnDeliveries, "Manage Deliveries");
            this.btnDeliveries.UseVisualStyleBackColor = false;
            this.btnDeliveries.Click += new System.EventHandler(this.btnDeliveries_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(666, 85);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(57, 30);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblWelcomeMsg
            // 
            this.lblWelcomeMsg.AutoSize = true;
            this.lblWelcomeMsg.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeMsg.Location = new System.Drawing.Point(523, 52);
            this.lblWelcomeMsg.MinimumSize = new System.Drawing.Size(200, 10);
            this.lblWelcomeMsg.Name = "lblWelcomeMsg";
            this.lblWelcomeMsg.Size = new System.Drawing.Size(200, 13);
            this.lblWelcomeMsg.TabIndex = 6;
            this.lblWelcomeMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnManageVans
            // 
            this.btnManageVans.BackColor = System.Drawing.Color.Transparent;
            this.btnManageVans.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnManageVans.FlatAppearance.BorderSize = 0;
            this.btnManageVans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageVans.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageVans.Image = ((System.Drawing.Image)(resources.GetObject("btnManageVans.Image")));
            this.btnManageVans.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManageVans.Location = new System.Drawing.Point(433, 155);
            this.btnManageVans.Name = "btnManageVans";
            this.btnManageVans.Size = new System.Drawing.Size(120, 120);
            this.btnManageVans.TabIndex = 1;
            this.btnManageVans.Text = "Vans";
            this.btnManageVans.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnManageVans, "Manage Van details");
            this.btnManageVans.UseVisualStyleBackColor = false;
            this.btnManageVans.Click += new System.EventHandler(this.btnManageVans_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(524, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification.Location = new System.Drawing.Point(532, 21);
            this.lblNotification.MinimumSize = new System.Drawing.Size(140, 10);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(140, 13);
            this.lblNotification.TabIndex = 8;
            this.lblNotification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNotification.Click += new System.EventHandler(this.lblNotification_Click);
            // 
            // picNotification
            // 
            this.picNotification.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picNotification.BackgroundImage")));
            this.picNotification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picNotification.Location = new System.Drawing.Point(678, 12);
            this.picNotification.Name = "picNotification";
            this.picNotification.Size = new System.Drawing.Size(45, 35);
            this.picNotification.TabIndex = 9;
            this.picNotification.TabStop = false;
            this.toolTip1.SetToolTip(this.picNotification, "New Notification");
            this.picNotification.Click += new System.EventHandler(this.lblNotification_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(735, 461);
            this.Controls.Add(this.picNotification);
            this.Controls.Add(this.lblNotification);
            this.Controls.Add(this.btnManageVans);
            this.Controls.Add(this.lblWelcomeMsg);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnDeliveries);
            this.Controls.Add(this.btnViewInventory);
            this.Controls.Add(this.btnManageEmployees);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNotification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnManageEmployees;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button btnDeliveries;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcomeMsg;
        private System.Windows.Forms.Button btnManageVans;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.PictureBox picNotification;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}