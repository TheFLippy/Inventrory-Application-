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
    //comment for testing
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Please enter your Username!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }
            if(string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter your Password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            try
            {
                using (dbtestEntities test = new dbtestEntities())
                {
                    var query = from o in test.Users where o.Username == txtUser.Text && o.Password == txtPassword.Text
                                select o;

                    if(query.SingleOrDefault() != null)
                    {
                        MessageBox.Show("You have loged in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //TODO::Code to process login
                        MainMenu menu = new MainMenu();
                        menu.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Your username or password was incorrect!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
