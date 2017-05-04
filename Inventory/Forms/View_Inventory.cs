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
    public partial class View_Inventory : Form
    {
        //variables for deletion of multiple rows
        bool ranOnce = false;
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        db sqlCon = new db();
        Add_Package addPckg = new Add_Package();

        int totalchk = 0;
        int[] id = new int[20];
        int i =0;
        Edit_Packages edtpk = new Edit_Packages();
        public int editid { set; get; }

        public View_Inventory()
        {
            InitializeComponent();
        }

        private void View_Inventory_Load(object sender, EventArgs e)
        {
            btnDelete.Visible = false;
            btnEdit.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          //creating a table for data storage
            DataTable dt = new DataTable();
           //connecting to the db
            sqlCon.sqlConnect();
            //creating query
            SqlDataAdapter sda = new SqlDataAdapter("select id,packageNumber,delivered,height,length,weight,width,deliveryAddress1,deliveryAddress2,deliveryCity,deliveryCountry,deliveryPostcode,deliveryName,deliverySurname,deliveryNumber,returnAddress1,returnAddress2,returnCity,returnCountry,returnPostcode,returnName,returnSurname,returnNumber,driver from package where packageNumber like'" + txtSearch.Text.ToString() + "%' AND deleted = 0", sqlCon.connectionString);
            //fills the table with the result of the query
            sda.Fill(dt);

            //to produce the checkbox
            if (ranOnce == false)
            {
                gridViewInv.Columns.Add(chk);

            }
            ranOnce = true;


            //filling the grid with the table contents
            gridViewInv.DataSource = dt;
        }

        private void gridViewInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                btnEdit.Visible = true;

                string tempID = gridViewInv.Rows[e.RowIndex].Cells[1].Value.ToString();
                editid = Convert.ToInt32(tempID);
                
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Console.WriteLine("id " + editid);
            this.Hide();
            
            edtpk.Show();
            this.edtpk.PassValue(editid);
            this.Close();
        }

        private void gridViewInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string temp = null;
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)gridViewInv.Rows[gridViewInv.CurrentRow.Index].Cells[0];

            //Checking wheter the box has been checked or unchecked
            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    break;
            }
            if (ch1.Value.ToString() == "True")
            {
                //Getting the ID of the user
                temp = gridViewInv.Rows[ch1.RowIndex].Cells[1].Value.ToString();
                //Placing that ID into an array with an index (needs to be this way in order to remove id when unchecked)
                deletefields(temp, ch1.RowIndex);
                //Display delete button
                btnDelete.Visible = true;
            }
            else if (ch1.Value.ToString() == "False")
            {
                totalchk--;
                id[ch1.RowIndex] = 0;
                if (totalchk == 0)
                {
                    btnDelete.Visible = false;
                }
            }

        }

        public void deletefields(string temp, int index)
        {
            index = 0;
            //Initializing the variable
            int fieldid = 0;
            //Converting the id (varchar) to string
            fieldid = Convert.ToInt32(temp);

            //Incrementing the global variable 
            totalchk++;
            id[index] = fieldid;
            index++;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            for(int i = 0; i < totalchk; i++)
            {
                Console.WriteLine("array" + id[i]);
            }



            DialogResult d = MessageBox.Show("Caution! This will permenantly delete " + totalchk + " row(s).\nDo you wish to proceed?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (d == DialogResult.OK)
            {
                //Passing the array of IDs to delete to DB class
                if (sqlCon.deletepackage(id))
                {
                    MessageBox.Show("Successfully deleted " + totalchk + " row(s)!");
                    i = 0;
                    //Reset the array of IDs 
                    
                    gridViewInv.DataSource = null;
                    btnDelete.Visible = false;
                    txtSearch.Text = null;
                }
                else
                {
                    MessageBox.Show("There was an error! sorry", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearch.Text = null;
                }
            }

        }

        private void ViewAll_Click(object sender, EventArgs e)
        {
            //creating a table for data storage
            DataTable dt = new DataTable();
            //connecting to the db
            sqlCon.sqlConnect();
            //creating query
            SqlDataAdapter sda = new SqlDataAdapter("select id,packageNumber,delivered,height,length,weight,width,deliveryAddress1,deliveryAddress2,deliveryCity,deliveryCountry,deliveryPostcode,deliveryName,deliverySurname,deliveryNumber,returnAddress1,returnAddress2,returnCity,returnCountry,returnPostcode,returnName,returnSurname,returnNumber,driver from package where deleted = 0", sqlCon.connectionString);
            //fills the table with the result of the query
            sda.Fill(dt);

            //to produce the checkbox
            if (ranOnce == false)
            {
                gridViewInv.Columns.Add(chk);

            }
            ranOnce = true;


            //filling the grid with the table contents
            gridViewInv.DataSource = dt;
        }

        private void btnAddPckg_Click(object sender, EventArgs e)
        {
            if (addPckg == null)
            {
                addPckg = new Add_Package();
                addPckg.FormClosed += addPckg_FormClosed;
            }
            addPckg.Show(this);
            Hide();
        }

        void addPckg_FormClosed(object sender, FormClosedEventArgs e)
        {
            addPckg = null;
            Show();
        }
    }
}
