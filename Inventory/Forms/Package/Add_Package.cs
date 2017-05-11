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
    public partial class Add_Package : Form
    {
        public Add_Package()
        {
            InitializeComponent();
        }

        private void delivery_Click(object sender, EventArgs e)
        {

        }

        private void Add_Package_load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //check if textboxes are empty
            foreach (Control c in this.package.Controls)
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
            int Value;
            if (!int.TryParse(txtweight.Text, out Value))
            {
                MessageBox.Show("Please enter the correct amount");
                txtweight.Focus();
                return;
            }
            else if(!int.TryParse(txtheight.Text, out Value))
            {
                MessageBox.Show("Please enter the correct amount");
                txtheight.Focus();
                return;
            }
            else if(!int.TryParse(txtlength.Text, out Value))
            {
                MessageBox.Show("Please enter the correct amount");
                txtlength.Focus();
                return;
            }

            else if (!int.TryParse(txtwidth.Text, out Value))
            {
                MessageBox.Show("Please enter the correct amount");
                txtwidth.Focus();
                return;
            }

            try
            {
                db sqlCon = new db();
                
                float destinationtel = (float)Convert.ToDouble(txttelephone_2.Text);
                float height = (float)Convert.ToDouble(txtheight.Text);
                float length = (float)Convert.ToDouble(txtlength.Text);
                float weight = (float)Convert.ToDouble(txtweight.Text);
                float width = (float)Convert.ToDouble(txtwidth.Text);
                float returntel = (float)Convert.ToDouble(txttelephone.Text);
                float packagenumber = (float)Convert.ToDouble(txtpackagenumber.Text);
                //if successfully added
                if (sqlCon.insertpack(destinationtel, height, length, weight, width, returntel, txtaddress1.Text, txtaddress2.Text, txtcity.Text, txtcountry.Text, txtname.Text, txtpostcode.Text,
                    txtsurname.Text,txtaddress1_2.Text, txtaddress2_2.Text, 
                    txtcity_2.Text,  txtcountry_2.Text, txtname_2.Text, txtpostcode_2.Text, txtsurname_2.Text 
                    , packagenumber))
                {
                    MessageBox.Show("Successfully added an package!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Package is not valid.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //moving through the tabs
        private void btnnext_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(1);
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(0);
        }

        private void btnnext_2_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(2);
        }

        private void btnprevious2_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(1);
        }


        //go back to main menu when cancle button is pressed
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
