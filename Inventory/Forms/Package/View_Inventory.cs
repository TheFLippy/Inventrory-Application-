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
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSearch_Click(sender, e);
            for (int i = 1; i < gridViewInv.ColumnCount; i++)
            { gridViewInv.Columns[i].ReadOnly = true; }

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
                chk.HeaderText = "Delete";
                chk.Width = 43;

            }
            ranOnce = true;


            //filling the grid with the table contents
            gridViewInv.DataSource = dt;
            gridViewInv.Columns[1].Width = 43;
        }

        private void gridViewInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                btnEdit.Enabled = true;

                string tempID = gridViewInv.Rows[e.RowIndex].Cells[1].Value.ToString();
                editid = Convert.ToInt32(tempID);
                
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormState.PreviousPage.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Console.WriteLine("id " + editid);
            this.Hide();
            
            edtpk.Show();
            this.edtpk.PassValue(editid);
   
        }

        private void gridViewInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridViewInv.CurrentCell == gridViewInv.Rows[gridViewInv.CurrentRow.Index].Cells[3])
            {
                return;
            }
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
                btnDelete.Enabled = true;
            }
            else if (ch1.Value.ToString() == "False")
            {
                totalchk--;
                id[ch1.RowIndex] = 0;
                if (totalchk == 0)
                {
                    btnDelete.Enabled = false;
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
                    btnDelete.Enabled = false;
                    txtSearch.Text = null;
                    btnSearch_Click(sender, e);
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

        }

        private void btnAddPckg_Click(object sender, EventArgs e)
        {
            Add_Package add = new Add_Package();
            add.Show();
            
        }

        void addPckg_FormClosed(object sender, FormClosedEventArgs e)
        {
            addPckg = null;
            Show();
        }

        private void View_Inventory_FormClosed(object sender, FormClosedEventArgs e)
        {
                System.Windows.Forms.Application.Exit();

        }

        private void View_Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
