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
    public partial class ManageEmployees : Form
    {
        public ManageEmployees()
        {
            InitializeComponent();
            
        }

        bool ranOnce = false;
        int totalChk = 0;
        int[] checkArray = new int[10];
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        
        db sqlCon = new db();
        
        private void ManageEmployees_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
       
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEmployee add = new AddEmployee();
            add.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (totalChk == 0)
            {
                btnDeleteEmp.Visible = false;
            }
            DataTable dt = new DataTable();
            sqlCon.sqlConnect();
            SqlDataAdapter sda = new SqlDataAdapter("select * from login where username like'" + txtSearch.Text + "%'", sqlCon.connectionString);
            
            sda.Fill(dt);

            if (ranOnce == false)
            {
                gridMngEmployees.Columns.Add(chk);

            }
            ranOnce = true;

            gridMngEmployees.DataSource = dt;
        }

        private void gridMngEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)gridMngEmployees.Rows[gridMngEmployees.CurrentRow.Index].Cells[0];
            string temp = null;

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
            if(ch1.Value.ToString() == "True")
            {
                temp = gridMngEmployees.Rows[ch1.RowIndex].Cells[7].Value.ToString();
                deleteArrayPopulation(temp, ch1.RowIndex);
            }
            else if(ch1.Value.ToString() == "False")
            {
                totalChk--;
                checkArray[ch1.RowIndex] = 0;
            }
            btnDeleteEmp.Visible = true;
        }

        public void deleteArrayPopulation(string temp, int index)
        {
            int id = 0;
            id = Convert.ToInt32(temp);

            totalChk++;
            checkArray[index] = id;
        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Caution! This will permenantly delete " + totalChk + " row(s).\nDo you wish to proceed?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(d == DialogResult.OK)
            {
                if(sqlCon.delete(checkArray))
                {
                    MessageBox.Show("Successfully deleted " + totalChk + " row(s)!");
                    totalChk = 0;
                    resetArray(checkArray);
                }
                else
                {
                    MessageBox.Show("There was an error! sorry", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void resetArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }
    }
}
