using Inventory.Forms;
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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageEmployees mng = new ManageEmployees();
            mng.Show();
        }

       
        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Package add = new Add_Package();
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Inventory inv = new View_Inventory();
            inv.Show();
        }

        private void btnVans_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageVans mngV = new ManageVans();
            mngV.Show();
        }
    }
}
