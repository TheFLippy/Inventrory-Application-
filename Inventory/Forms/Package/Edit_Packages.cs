using System;
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
    public partial class Edit_Packages : Form
    {
        db sqlCon = new db();
        int id;
        string city = "";
        string city2 = "";
        public Edit_Packages()
        {
            InitializeComponent();
        }

        public void PassValue(int editid)
        {
            id = editid;
            Console.WriteLine("Eid " + id);
            populatefields();
        }
        public void populatefields()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM package Where id =" + id.ToString(), sqlCon.connectionString);
            sda.Fill(dt);

            //populating the text fields with the data table items
            //package info
            txtpackagenumber.Text = dt.Rows[0][26].ToString();
            txtweight.Text = dt.Rows[0][9].ToString();
            txtwidth.Text = dt.Rows[0][10].ToString();
            txtlength.Text = dt.Rows[0][8].ToString();
            txtheight.Text = dt.Rows[0][7].ToString();

            //return packge contact info
            txtname_2.Text = dt.Rows[0][23].ToString();
            txtsurname_2.Text = dt.Rows[0][25].ToString();
            txttelephone_2.Text = dt.Rows[0][11].ToString();
            txtaddress1_2.Text = dt.Rows[0][19].ToString();
            txtaddress2_2.Text = dt.Rows[0][20].ToString();
            txtcity_2.Text = dt.Rows[0][21].ToString();
            txtpostcode_2.Text = dt.Rows[0][24].ToString();
            txtcountry_2.Text = dt.Rows[0][22].ToString();

            //destination package contact info
            txtname.Text = dt.Rows[0][16].ToString();
            txtsurname.Text = dt.Rows[0][18].ToString();
            txttelephone.Text = dt.Rows[0][6].ToString();
            txtaddress1.Text = dt.Rows[0][12].ToString();
            txtaddress2.Text = dt.Rows[0][13].ToString();
            City_cmbx1.Text = dt.Rows[0][14].ToString();
            txtpostcode.Text = dt.Rows[0][17].ToString();
            txtcountry.Text = dt.Rows[0][15].ToString();


        }
        private void Edit_Packages_Load(object sender, EventArgs e)
        {

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(1);
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(1);
        }

        private void btnnext_2_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(2);
        }

        private void btnprevious2_Click(object sender, EventArgs e)
        {
            TabControl1.SelectTab(0);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Inventory vw = new View_Inventory();
            vw.Show();
        }

   

        private void btnsave_Click(object sender, EventArgs e)
        {
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
                
                if (sqlCon.updatepackage(id, packagenumber,weight, height, width,
                    length, txtname_2.Text, txtsurname_2.Text, returntel, txtaddress1_2.Text,
                    txtaddress2_2.Text, city2, txtpostcode_2.Text, txtcountry_2.Text,
                    txtname.Text, txtsurname.Text, destinationtel, txtaddress1.Text,
                    txtaddress2.Text, txtcity_2.Text, txtpostcode.Text, txtcountry.Text))
                {
                    MessageBox.Show("Successfully edited a package!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //switching to search after completion
                    this.Hide();
                    View_Inventory vi = new View_Inventory();
                    vi.Show();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



      

        private void City_cmbx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               city2 = City_cmbx1.SelectedItem.ToString();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Choose a locality", "Message");
            }
        }
    }
}
