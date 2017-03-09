using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory
{
    public partial class Login : Form
    {
        public string logedUser;
        public int logedPriveleges; 

        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //LOGIN BUTTON//
        private void button1_Click(object sender, EventArgs e)
        {
            //Checking if form fields are empty
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
                //Create new instance of database
                using (dbtestEntities test = new dbtestEntities())
                {
                    //Querying the database
                    var query = from o in test.Users where o.Username == txtUser.Text && o.Password == txtPassword.Text
                                select o;

                    //If query returns a row (more than 0 a.k.a not null) then it has been successfull
                    if(query.SingleOrDefault() != null)
                    {
                        MessageBox.Show("You have logged in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Creating the main menu form and showing it and hiding the login form
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
            //Exceptions
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
