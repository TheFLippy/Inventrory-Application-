﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Inventory.Forms
{
    public partial class EditVan : Form
    {
        db sqlCon = new db();
        int id;
        DataTable driverdt = new DataTable();

        public string connectionString = @"Data Source=gapt-inventory.database.windows.net;Initial Catalog = Inventory; Persist Security Info=True;User ID = TheFLippy; Password=Gapt1234";

        private string getDriver(DataTable dtdriver)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter("SELECT username FROM login WHERE jobPosition = 'Driver'", connectionString);
                sda.Fill(dtdriver);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }


            return dtdriver.ToString();
        }
        public EditVan(int id)
        {
            this.id = id;
            InitializeComponent();
            populatefields();
        }

        public void PassValue(int editid)
        {
            id = editid;
            Console.WriteLine("Vid " + id);

        }
        public void populatefields()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM van Where id =" + id.ToString(), sqlCon.connectionString);
                sda.Fill(dt);

                //populating the text fields with the data table items
                //package info
                txtnoplate.Text = dt.Rows[0][1].ToString();
                txtvolume.Text = dt.Rows[0][2].ToString();
                txtweight.Text = dt.Rows[0][3].ToString();
                txtmake.Text = dt.Rows[0][7].ToString();
                txtmodel.Text = dt.Rows[0][8].ToString();
                txtengsize.Text = dt.Rows[0][9].ToString();
                txtyom.Text = dt.Rows[0][10].ToString();
                drivercmbx.Text = dt.Rows[0][11].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //check if textboxes are empty
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text.Equals(""))
                    {
                        MessageBox.Show("Please enter missing fields!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        c.Focus();
                        return;
                    }
                }

            }
            //check if integer textboxes contains integers
            float Value;
            int value2;
            if (!float.TryParse(txtvolume.Text, out Value))
            {
                MessageBox.Show("Please enter the correct volume amount");
                txtvolume.Focus();
                return;
            }
            else if (!float.TryParse(txtweight.Text, out Value))
            {
                MessageBox.Show("Please enter the correct weight amount");
                txtweight.Focus();
                return;
            }
            else if (!int.TryParse(txtyom.Text, out value2))
            {
                MessageBox.Show("Please enter the correct  YoM amount");
                txtyom.Focus();
                return;
            }
            try
            {
                db sqlCon = new db();

                float vol = (float)Convert.ToDouble(txtvolume.Text);
                float weight = (float)Convert.ToDouble(txtweight.Text);
                int yom = Convert.ToInt32(txtyom.Text);
                string driver = drivercmbx.SelectedItem.ToString();
                //if successfully added

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM van Where id =" + id.ToString(), sqlCon.connectionString);
                sda.Fill(dt);

                if (sqlCon.editvan(txtnoplate.Text, vol, weight, dt.Rows[0][4].ToString(), Convert.ToInt32(dt.Rows[0][5]), dt.Rows[0][6].ToString(), txtmake.Text, txtmodel.Text, txtengsize.Text, yom, (int)dt.Rows[0][0], driver))
                {
                    MessageBox.Show("Successfully edited a van!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Van is not valid.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");
            }


        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EditVan_Load(object sender, EventArgs e)
        {
            getDriver(driverdt);

            for (int i = 0; i < driverdt.Rows.Count; i++)
            {
                drivercmbx.Items.Add(driverdt.Rows[i][0]);
            }
        }
    }
}
