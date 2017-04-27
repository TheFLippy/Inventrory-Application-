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

namespace Inventory
{
    public partial class ManageEmployees : Form
    {
        public ManageEmployees()
        {
            InitializeComponent();
        }

        //variables for deletion of multiple rows
        bool ranOnce = false;
        int totalChk = 0;
        int[] checkArray = new int[10];
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        db sqlCon = new db();

        //Variables for editing
        public int editID { get; set; }


        private void ManageEmployees_Load(object sender, EventArgs e)
        {
            btnDeleteEmp.Visible = false;
            btnEdit.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
       
        }

        //Redirect to add employee form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmployee add = new AddEmployee();
            add.Show();
        }

        //Redirect back
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Creating data table to put our data onto it
            DataTable dt = new DataTable();
            //Connectining to database
            sqlCon.sqlConnect();
            //Creating data adapter to query the database
            SqlDataAdapter sda = new SqlDataAdapter("select * from login where username like'" + txtSearch.Text + "%'", sqlCon.connectionString);
            
            //Filling the datatable with retrieved rows
            sda.Fill(dt);

            //If function has more than once, will not put checkbox onto the row
            if (ranOnce == false)
            {
                gridMngEmployees.Columns.Add(chk);

            }
            ranOnce = true;

            //Passing the data table to grid veiw to display it
            gridMngEmployees.DataSource = dt;
        }

        //Checkbox mark
        private void gridMngEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)gridMngEmployees.Rows[gridMngEmployees.CurrentRow.Index].Cells[0];
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
                    temp = gridMngEmployees.Rows[ch1.RowIndex].Cells[7].Value.ToString();
                    //Placing that ID into an array with an index (needs to be this way in order to remove id when unchecked)
                    deleteArrayPopulation(temp, ch1.RowIndex);
                    //Display delete button
                    btnDeleteEmp.Visible = true;
                }
                else if (ch1.Value.ToString() == "False")
                {
                    totalChk--;
                    checkArray[ch1.RowIndex] = 0;
                    if (totalChk == 0)
                    {
                        btnDeleteEmp.Visible = false;
                    }
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

        //Delete
        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            //Storing dialogue result in order to see what user pressed
            DialogResult d = MessageBox.Show("Caution! This will permenantly delete " + totalChk + " row(s).\nDo you wish to proceed?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(d == DialogResult.OK)
            {
                //Passing the array of IDs to delete to DB class
                if(sqlCon.delete(checkArray))
                {
                    MessageBox.Show("Successfully deleted " + totalChk + " row(s)!");
                    totalChk = 0;
                    //Reset the array of IDs 
                    resetArray(checkArray);
                    gridMngEmployees.DataSource = null;
                    btnDeleteEmp.Visible = false;

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
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        private void gridMngEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex != 0)
            {
                btnEdit.Visible = true;

                string tempID = gridMngEmployees.Rows[e.RowIndex].Cells[1].Value.ToString();
                editID = Convert.ToInt32(tempID);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(editID != 0)
            {
                //Create connection with db
                SqlConnection con = new SqlConnection(sqlCon.connectionString);
                con.Open();

                //Create command and reader
                SqlCommand command = new SqlCommand("select * from login where id='" + editID + "'", con);
                SqlDataReader read = command.ExecuteReader();

                //Creating user object to hold values
                string editUserName = null, editName = null, editSurname = null, editGroup = null;

                while (read.Read())
                {
                    editUserName = (string)read["username"];
                    editName = (string)read["name"];
                    editSurname = (string)read["surname"];
                    editGroup = (string)read["group"];
                }

                EditEmployee edit = new EditEmployee(editUserName, editName, editSurname, editGroup, editID);
                edit.Show();
            }
        }

        private void MainMenu(object sender, EventArgs e)
        {

        }
    }
}
