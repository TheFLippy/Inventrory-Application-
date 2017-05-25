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
using Inventory.Forms;

namespace Inventory.Forms
{
    public partial class ManageVans : Form
    {
        public ManageVans()
        {
            InitializeComponent();
            btnDeleteVan.Enabled = false;
            btnEdit.Enabled = false;
        }

        //variables for deletion of multiple rows
        bool ranOnce = false;
        int totalChk = 0;
        int[] checkArray = new int [20];
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        db sqlCon = new db();
        int totalchk = 0;
        int[] id = new int[20];

        //Variables for editing
        public int editID { get; set; }

        private void ManageVans_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            for (int i = 1; i < gridMngVans.ColumnCount; i++)
            { gridMngVans.Columns[i].ReadOnly = true; }
        }

        //Redirect to add van form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddVan add = new AddVan();
            add.Show();
        }

        //Redirect back
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormState.PreviousPage.Show();
        }

        //Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Creating data table to put our data onto it
            DataTable dt = new DataTable();
            //Connectining to database
            sqlCon.sqlConnect();
            //Creating data adapter to query the database
            SqlDataAdapter sda = new SqlDataAdapter("select * from van where noPlate like'" + txtSearch.Text + "%'", sqlCon.connectionString);

            //Filling the datatable with retrieved rows
            sda.Fill(dt);

            //If function has more than once, will not put checkbox onto the row
            if (ranOnce == false)
            {
                gridMngVans.Columns.Add(chk);
                chk.HeaderText = "Delete";
                chk.Width = 43;
            }
            ranOnce = true;

            //Passing the data table to grid veiw to display it
            gridMngVans.DataSource = dt;
            gridMngVans.Columns[1].Width = 43;
        }

        //Checkbox mark
        private void gridMngVans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)gridMngVans.Rows[gridMngVans.CurrentRow.Index].Cells[0];
            string temp = null;
           
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
                    temp = gridMngVans.Rows[ch1.RowIndex].Cells[1].Value.ToString();
                    //Placing that ID into an array with an index (needs to be this way in order to remove id when unchecked)
                    deleteArrayPopulation(temp, ch1.RowIndex);
                    //Display delete button
                    btnDeleteVan.Enabled = true;
                }
                else if (ch1.Value.ToString() == "False")
                {
                    totalchk--;
                    id[ch1.RowIndex] = 0;
                    if (totalchk == 0)
                    {
                        btnDeleteVan.Enabled = false;
                    }
                }
            
        }

        //Array that is used to pass multiple IDs of users in order to delete them
        public void deleteArrayPopulation(string temp, int index)
        {
            //Initializing the variable
            int id = 0;
            //Converting the id (varchar) to string
            id = Convert.ToInt32(temp);

            //Incrementing the global variable 
            totalChk++;
            checkArray[index] = id;
        }


        //public void deletefields(string temp, int index)
        //{
        //    index = 0;
        //    //Initializing the variable
        //    int fieldid = 0;
        //    //Converting the id (varchar) to string
        //    fieldid = Convert.ToInt32(temp);

        //    //Incrementing the global variable 
        //    totalchk++;
        //    id[index] = fieldid;
        //    index++;
        //}

        //Delete
        private void btnDeleteVan_Click(object sender, EventArgs e)
        {
            //Storing dialogue result in order to see what user pressed
            DialogResult d = MessageBox.Show("Caution! This will permenantly delete " + totalChk + " row(s).\nDo you wish to proceed?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (d == DialogResult.OK)
            {
                //Passing the array of IDs to delete to DB class
                if (sqlCon.deleteVan(checkArray))
                {
                    MessageBox.Show("Successfully deleted " + totalChk + " row(s)!");
                    totalChk = 0;
                    //Reset the array of IDs 
                    resetArray(checkArray);
                    //gridMngVans.DataSource = null;
                    btnDeleteVan.Enabled = false;
                    btnSearch_Click(sender, e);

                }
                else
                {
                    MessageBox.Show("There was an error! sorry", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //Reset array
        private void resetArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        private void gridMngVans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 &&e.RowIndex !=-1)
            {
                btnEdit.Enabled = true;

                string tempID = gridMngVans.Rows[e.RowIndex].Cells[1].Value.ToString();
                editID = Convert.ToInt32(tempID);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (editID != 0)
            {
                //Create connection with db
                SqlConnection con = new SqlConnection(sqlCon.connectionString);
                con.Open();

                //Create command and reader
                SqlCommand command = new SqlCommand("select * from van where id='" + editID + "'", con);
                SqlDataReader read = command.ExecuteReader();

                //Creating user object to hold values
                string noPlate = null, location = null, state = null, make = null, model = null, engSize = null;
                float volume = 0, weight = 0;
                int YoM = 0, inUse = 0;
                

                while (read.Read())
                {
                    noPlate = (string)read["noPlate"];
                    volume = (float)Convert.ToDouble(read["volume"]);
                    weight = (float)Convert.ToDouble(read["weight"]);
                    location = (string)read["location"];
                    inUse = Convert.ToInt32(read["inUse"]);
                    state = (string)read["state"];
                    make = (string)read["make"];
                    model = (string)read["model"];
                    engSize = (string)read["engSize"];
                    YoM = Convert.ToInt32(read["YoM"]);
                }

                EditVan edit = new EditVan(editID);
                edit.Show();
            }
        }

       

        private void ManageVans_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
