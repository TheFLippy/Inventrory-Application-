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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.adding = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 2);
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
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.adding);
            this.panel2.Controls.Add(this.AssignBtn);
            this.panel2.Location = new System.Drawing.Point(640, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 497);
            this.panel2.TabIndex = 1;
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
            this.adding.Location = new System.Drawing.Point(0, 0);
            this.adding.Name = "adding";
            this.adding.Size = new System.Drawing.Size(354, 193);
            this.adding.TabIndex = 2;
            // 
            // AssignPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 501);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssignPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssignPackage";
            this.Load += new System.EventHandler(this.AssignPackage_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AssignBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel adding;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}