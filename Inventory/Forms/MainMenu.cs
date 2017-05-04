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

        //Holding forms in order to check if they have been opened
        Login login;
        Add_Package addPckg;
        ManageEmployees mng;
        View_Inventory viewInv;
        ManageVans mngVans;

        public MainMenu(string privelage)
        {
            InitializeComponent();

            lblWelcomeMsg.Text = "Logged in as " + privelage;

            switch (privelage)
            {
                case "Admin":
                    btnManageEmployees.Show();
                    break;

                case "Clerk":
                    btnManageEmployees.Hide();
                    break;

                case "Driver":
                    btnManageEmployees.Hide();
                    break;
            }
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to logout?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (d == DialogResult.OK)
            {
                if (login == null)
                {
                    login = new Login();
                    login.FormClosed += login_FormClosed;
                }

                login.Show(this);
                Hide();
            }            
        }
        void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            login = null;
            //Show();
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            if(mng == null)
            {
                mng = new ManageEmployees();
                mng.FormClosed += mng_FormClosed;
            }

            mng.Show(this);
            Hide();
        }
        //Event handler that closes form without needing to recreate
        void mng_FormClosed(object sender, FormClosedEventArgs e)
        {
            mng = null;
            Show();
        }
       
/*        private void btnAddPackage_Click(object sender, EventArgs e)
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
        }*/

        private void btnViewIntentory_Click(object sender, EventArgs e)
        {
            if(viewInv == null)
            {
                viewInv = new View_Inventory();
                viewInv.FormClosed += viewInv_FormClosed;
            }

            viewInv.Show(this);
            Hide();
        }

        void viewInv_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewInv = null;
            Show();
        }


        private void btnManageVans_Click(object sender, EventArgs e)
        {
            if (mngVans == null)
            {
                mngVans = new ManageVans();
                mngVans.FormClosed += viewInv_FormClosed;
            }

            mngVans.Show(this);
            Hide();
        }
        void mngVans_FormClosed(object sender, FormClosedEventArgs e)
        {
            mngVans = null;
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AssignPackage ap = new AssignPackage();
            ap.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
