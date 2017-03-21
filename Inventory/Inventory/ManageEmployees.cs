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


        private void ManageEmployees_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            db sqlCon = new db();
            sqlCon.sqlConnect();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("select * from login where username like'" + txtSearch.Text + "%'", sqlCon.connectionString);

            sda.Fill(dt);
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            gridMngEmployees.Columns.Add(chk);
            gridMngEmployees.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this.Hide();
            AddEmployee add = new AddEmployee();
            add.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.Show();
        }
    }
}
