using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class AddEmployee : Form
    {
        public string group;
        
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtAddUsername.Text))
            {
                MessageBox.Show("Please enter Username!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtAddPassword.Text))
            {
                MessageBox.Show("Please enter your Password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddPassword.Focus();
                return;
            }
            if(txtAddPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Passwords must match!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirm.Focus();
                return;
            }
            try
            {
                db sqlCon = new db();
                //if successfully added
                if(sqlCon.insertEmp(txtAddUsername.Text, txtAddPassword.Text, txtAddName.Text, txtSurname.Text, group))
                {
                    MessageBox.Show("Successfully added an employee!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //switching to search after completion
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username already exists!\nPlease chooe a different one.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            group = "Admin";
        }

        private void rbClerk_CheckedChanged(object sender, EventArgs e)
        {
            group = "Clerk";
        }

        private void rbDriver_CheckedChanged(object sender, EventArgs e)
        {
            group = "Driver";
        }
    }
}
