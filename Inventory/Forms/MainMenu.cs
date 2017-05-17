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
        #region Main Menu Variables


        db sqlCon;
        Login login;
        ManageEmployees mng;
        View_Inventory viewInv;
        ManageVans mngVans;
        AssignPackage assPckg;

        bool exit = false;

        #endregion
        public MainMenu(string privelage, string welcomeMsg)
        {
            InitializeComponent();

            picNotification.Visible = false;
            lblNotification.Visible = false;

            #region Notificatons
            sqlCon = new db();

            if(sqlCon.checkIfCanceled())
            {
                lblNotification.Visible = true;
                lblNotification.Text = "You have new notifications";
                picNotification.Visible = true;

            }
            #endregion

            FormState.PreviousPage = this;

            lblWelcomeMsg.Text = welcomeMsg + "\nLogged in as " + privelage;

            switch (privelage)
            {
                case "Admin":
                    btnManageEmployees.Show();
                    btnManageVans.Show();
                    break;

                case "Clerk":
                    btnManageEmployees.Hide();
                    btnManageVans.Hide();
                    btnViewInventory.Location = new Point (188, 239);
                    btnDeliveries.Location = new Point(433, 239);
                    break;

                case "Driver":
                    btnManageEmployees.Hide();
                    btnManageVans.Hide();
                    btnViewInventory.Location = new Point(188, 229);
                    btnDeliveries.Location = new Point(433, 229);
                    break;
            }
        }

        #region Logout form navigation
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
            System.Windows.Forms.Application.Exit();
        }
        #endregion

        #region Employee form navigation
        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            if(mng == null)
            {
                mng = new ManageEmployees();
                mng.FormClosing += MainMenu_FormClosing;
                mng.FormClosed += MainMenu_FormClosed;
            }

            mng.Show(this);
            Hide();
        }
        #endregion

        # region Inventory form navigation
        private void btnViewIntentory_Click(object sender, EventArgs e)
        {
            if(viewInv == null)
            {
                viewInv = new View_Inventory();
                viewInv.FormClosing += MainMenu_FormClosing;
                viewInv.FormClosed += MainMenu_FormClosed;
            }

            viewInv.Show(this);
            Hide();
        }
        void viewInv_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewInv = null;
            Show();
        }
        #endregion

        #region Van form nagivation
        private void btnManageVans_Click(object sender, EventArgs e)
        {
            if (mngVans == null)
            {
                mngVans = new ManageVans();
                mngVans.FormClosing += MainMenu_FormClosing;
                mngVans.FormClosed += MainMenu_FormClosed;
            }

            mngVans.Show(this);
            Hide();
        }
        void mngVans_FormClosed(object sender, FormClosedEventArgs e)
        {
            mngVans = null;
            Show();
        }
        #endregion

        #region  Assign Package form navigation
        private void btnDeliveries_Click(object sender, EventArgs e)
        {
            assPckg = null;

            if (assPckg == null)
            {
                assPckg = new AssignPackage();
                assPckg.FormClosing += MainMenu_FormClosing;
                assPckg.FormClosed += MainMenu_FormClosed;
            }

            assPckg.Show(this);
            Hide(); 
        }
        void assPckg_FormClosed(object sender, FormClosedEventArgs e)
        {
            assPckg = null;
            Show();
        }
        #endregion

        #region Navigation Management Event Handlers
        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            var d = DialogResult;

            if(!exit)
            {
                d = MessageBox.Show("Are you sure you want to exit the application?","Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (d == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    exit = true;
                }
            }
        }
        #endregion

        private void lblNotification_Click(object sender, EventArgs e)
        {
            List<string> listNotif = sqlCon.returnNotes();
            string finalNote = null;

            foreach(string note in listNotif)
            {
                finalNote += note;
            }

            DialogResult d = MessageBox.Show("The following packages have been canceled:\n\n" + finalNote, "Notification", MessageBoxButtons.OKCancel);
            if(d == DialogResult.OK)
            {
                lblNotification.Visible = false;
                picNotification.Visible = false;
                try
                {
                    sqlCon.removeNotes();
                    MessageBox.Show("The packages have been unassigned.");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            } 
        }
    }

    public static class FormState
    {
        public static Form PreviousPage;
        public static string userName;
    }
}
