namespace Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.btnDeliveries = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcomeMsg = new System.Windows.Forms.Label();
            this.btnManageVans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(146, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solar Transport and Delivery";
            // 
            // btnManageEmployees
            // 
            this.btnManageEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(255)))));
            this.btnManageEmployees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnManageEmployees.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnManageEmployees.FlatAppearance.BorderSize = 0;
            this.btnManageEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageEmployees.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageEmployees.Image = ((System.Drawing.Image)(resources.GetObject("btnManageEmployees.Image")));
            this.btnManageEmployees.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManageEmployees.Location = new System.Drawing.Point(102, 73);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(110, 87);
            this.btnManageEmployees.TabIndex = 0;
            this.btnManageEmployees.Text = "Employees";
            this.btnManageEmployees.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManageEmployees.UseVisualStyleBackColor = false;
            this.btnManageEmployees.Click += new System.EventHandler(this.btnManageEmployees_Click);
            // 
            // btnViewInventory
            // 
            this.btnViewInventory.BackColor = System.Drawing.Color.White;
            this.btnViewInventory.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnViewInventory.FlatAppearance.BorderSize = 2;
            this.btnViewInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewInventory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnViewInventory.Image")));
            this.btnViewInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewInventory.Location = new System.Drawing.Point(58, 187);
            this.btnViewInventory.Name = "btnViewInventory";
            this.btnViewInventory.Size = new System.Drawing.Size(206, 61);
            this.btnViewInventory.TabIndex = 2;
            this.btnViewInventory.Text = "Inventory";
            this.btnViewInventory.UseVisualStyleBackColor = false;
            this.btnViewInventory.Click += new System.EventHandler(this.btnViewIntentory_Click);
            // 
            // btnDeliveries
            // 
            this.btnDeliveries.BackColor = System.Drawing.Color.White;
            this.btnDeliveries.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeliveries.FlatAppearance.BorderSize = 2;
            this.btnDeliveries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeliveries.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliveries.Image = ((System.Drawing.Image)(resources.GetObject("btnDeliveries.Image")));
            this.btnDeliveries.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeliveries.Location = new System.Drawing.Point(319, 187);
            this.btnDeliveries.Name = "btnDeliveries";
            this.btnDeliveries.Size = new System.Drawing.Size(206, 61);
            this.btnDeliveries.TabIndex = 6;
            this.btnDeliveries.Text = "Deliveries";
            this.btnDeliveries.UseVisualStyleBackColor = false;
            this.btnDeliveries.Click += new System.EventHandler(this.btnDeliveries_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.BorderSize = 2;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(235, 277);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(115, 51);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblWelcomeMsg
            // 
            this.lblWelcomeMsg.AutoSize = true;
            this.lblWelcomeMsg.Location = new System.Drawing.Point(12, 335);
            this.lblWelcomeMsg.MinimumSize = new System.Drawing.Size(200, 10);
            this.lblWelcomeMsg.Name = "lblWelcomeMsg";
            this.lblWelcomeMsg.Size = new System.Drawing.Size(200, 13);
            this.lblWelcomeMsg.TabIndex = 6;
            // 
            // btnManageVans
            // 
            this.btnManageVans.BackColor = System.Drawing.Color.White;
            this.btnManageVans.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnManageVans.FlatAppearance.BorderSize = 2;
            this.btnManageVans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageVans.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageVans.Image = ((System.Drawing.Image)(resources.GetObject("btnManageVans.Image")));
            this.btnManageVans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageVans.Location = new System.Drawing.Point(319, 84);
            this.btnManageVans.Name = "btnManageVans";
            this.btnManageVans.Size = new System.Drawing.Size(206, 61);
            this.btnManageVans.TabIndex = 1;
            this.btnManageVans.Text = "Vans";
            this.btnManageVans.UseVisualStyleBackColor = false;
            this.btnManageVans.Click += new System.EventHandler(this.btnManageVans_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(571, 342);
            this.Controls.Add(this.btnManageVans);
            this.Controls.Add(this.lblWelcomeMsg);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnDeliveries);
            this.Controls.Add(this.btnViewInventory);
            this.Controls.Add(this.btnManageEmployees);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageEmployees;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button btnDeliveries;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcomeMsg;
        private System.Windows.Forms.Button btnManageVans;
    }
}