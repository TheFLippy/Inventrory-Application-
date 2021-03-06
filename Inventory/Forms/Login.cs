﻿using System;
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
        db displayData = new db();

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
                db sqlConn = new db();
                sqlConn.login(txtUser.Text, txtPassword.Text);

                if(sqlConn.login(txtUser.Text, txtPassword.Text))
                {
                    
                    MessageBox.Show("Successfully loged in.");
                    this.Hide();

                    MainMenu menu = new MainMenu(sqlConn.getJobPosition(txtUser.Text), sqlConn.getWelcomeMessage(txtUser.Text));
                    FormState.userName = txtUser.Text;
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Your username or password was incorrect!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                }
                
            }
            //Exceptions
            
            catch (Exception x)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
                System.Windows.Forms.Application.Exit();
        }
    }
}
