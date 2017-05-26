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
    public partial class AddVan : Form
    {
        public AddVan()
        {
            InitializeComponent();
        }

        private void AddVan_load(object sender, EventArgs e)
        {

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
                MessageBox.Show("Please enter the correct amount");
                txtvolume.Focus();
                return;
            }
            else if (!float.TryParse(txtweight.Text, out Value))
            {
                MessageBox.Show("Please enter the correct amount");
                txtweight.Focus();
                return;
            }
            else if (!int.TryParse(txtyom.Text, out value2))
            {
                MessageBox.Show("Please enter the correct amount");
                txtyom.Focus();
                return;
            }
            try
            {
                db sqlCon = new db();

                float vol = (float)Convert.ToDouble(txtvolume.Text);
                float weight = (float)Convert.ToDouble(txtweight.Text);
                int yom = Convert.ToInt32(txtyom.Text);
                //if successfully added
                if (sqlCon.insertvan(txtnoplate.Text, vol, weight, txtmake.Text, txtmodel.Text, txtengsize.Text, yom))
                {
                    MessageBox.Show("Successfully added a van!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Van is not valid.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
