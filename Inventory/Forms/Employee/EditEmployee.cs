using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory.Forms
{
    public partial class EditEmployee : Form
    {
        int tempID;
        string editGroup;

        //Hold old data to put into logs
        string oldUsername, oldName, oldSurname, oldGroup;

        public EditEmployee(string username, string name, string surname, string group, int id)
        {
            InitializeComponent();

            //Populate textboxes with old data
            txtEditUsername.Text = username;
            txtEditName.Text = name;
            txtEditSurname.Text = surname;
            tempID = id;

            oldUsername = username;
            oldName = name;
            oldSurname = surname;
            oldGroup = group;

            switch(group)
            {
                case "Admin":
                    rbAdmin.Checked = true;
                    break;

                case "Clerk":
                    rbClerk.Checked = true;
                    break;

                case "Driver":
                    rbDriver.Checked = true;
                    break;
            }
         }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditUsername.Text))
            {
                MessageBox.Show("Please enter Username!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtEditOldPassword.Text))
            {
                MessageBox.Show("Please enter your old Password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditOldPassword.Focus();
                return;
            }
            if (txtEditNewPassword.Text != txtEditConfirmPassword.Text)
            {
                MessageBox.Show("Passwords must match!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditNewPassword.Focus();
                return;
            }
            try
            {
                db sqlCon = new db();
                //if successfully added
                if (sqlCon.updateEmp(txtEditUsername.Text, txtEditNewPassword.Text, txtEditName.Text, txtEditSurname.Text, editGroup, tempID))
                {
                    MessageBox.Show("Successfully edited an employee!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            editGroup = "Admin";
        }

        private void rbClerk_CheckedChanged(object sender, EventArgs e)
        {
            editGroup = "Clerk";
        }

        private void rbDriver_CheckedChanged(object sender, EventArgs e)
        {
            editGroup = "Driver";
        }
    }
}
