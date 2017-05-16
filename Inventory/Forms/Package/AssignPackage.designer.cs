namespace Inventory.Forms
{
    partial class AssignPackage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignPackage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.AssignBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.adding = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.Helpbtn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 497);
            this.panel1.TabIndex = 0;
            // 
            // AssignBtn
            // 
            this.AssignBtn.Location = new System.Drawing.Point(255, 464);
            this.AssignBtn.Name = "AssignBtn";
            this.AssignBtn.Size = new System.Drawing.Size(78, 23);
            this.AssignBtn.TabIndex = 0;
            this.AssignBtn.Text = "Assign";
            this.AssignBtn.UseVisualStyleBackColor = true;
            this.AssignBtn.Click += new System.EventHandler(this.AssignBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.adding);
            this.panel2.Controls.Add(this.AssignBtn);
            this.panel2.Location = new System.Drawing.Point(630, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 497);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Add";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 199);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(348, 110);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // adding
            // 
            this.adding.AutoScroll = true;
            this.adding.Location = new System.Drawing.Point(0, 28);
            this.adding.Name = "adding";
            this.adding.Size = new System.Drawing.Size(354, 176);
            this.adding.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(395, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Assign Packages";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(19, 23);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(32, 32);
            this.btnBack.TabIndex = 4;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Helpbtn
            // 
            this.Helpbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Helpbtn.BackgroundImage")));
            this.Helpbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Helpbtn.FlatAppearance.BorderSize = 0;
            this.Helpbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Helpbtn.Location = new System.Drawing.Point(931, 23);
            this.Helpbtn.Name = "Helpbtn";
            this.Helpbtn.Size = new System.Drawing.Size(32, 32);
            this.Helpbtn.TabIndex = 3;
            this.Helpbtn.UseVisualStyleBackColor = true;
            this.Helpbtn.Click += new System.EventHandler(this.Helpbtn_Click);
            // 
            // AssignPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(983, 578);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.Helpbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssignPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Package";
            this.Load += new System.EventHandler(this.AssignPackage_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AssignBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel adding;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Helpbtn;
    }
}