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
        public string connectionString = @"Data Source=gapt-inventory.database.windows.net;Initial Catalog = Inventory; Persist Security Info=True;User ID = TheFLippy; Password=Gapt1234";
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
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                if(con.State == System.Data.ConnectionState.Open)
                {
                    string query = "select username from login where username='"+txtUser.ToString()+"'and password='"+txtPassword.ToString()+"'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int result = cmd.ExecuteNonQuery();
                    if(result != 0)
                    {
                        MessageBox.Show("You have logged in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Creating the main menu form and showing it and hiding the login form
                        MainMenu menu = new MainMenu();
                        menu.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Your username or password was incorrect!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
