using Opulos.Core.UI;
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
    public partial class AssignPackage : Form
    {
        public string connectionString = @"Data Source=gapt-inventory.database.windows.net;Initial Catalog = Inventory; Persist Security Info=True;User ID = TheFLippy; Password=Gapt1234";
        Random rnd = new Random();
        public AssignPackage()
        {
            InitializeComponent();
        }
        private string assigndriver(DataTable dtdriver)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            
            SqlDataAdapter sda = new SqlDataAdapter("SELECT name FROM login WHERE jobPosition = 'Driver'", connectionString);
            sda.Fill(dtdriver);

            return dtdriver.ToString();
        }

        private string assignpackage(DataTable dtpackage)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT packageNumber FROM package WHERE deleted = 0 AND delivered = 0 AND driver IS NULL", connectionString);
            sda.Fill(dtpackage);

            return dtpackage.ToString();
        }


        private void AssignPackage_Load(object sender, EventArgs e)
        {
            string buttonname = "btn";


            DataTable dtdriver = new DataTable();
            assigndriver(dtdriver);
            int count = dtdriver.Select().Length;
            //testing
            Console.WriteLine("dt count\t" + count);

            DataTable dtpackage = new DataTable();
            assignpackage(dtpackage);
            int count1 = dtpackage.Select().Length;
            //testing
            Console.WriteLine("dt count1 \t" + count1);

            //creating the accordian
            Accordion acc = new Accordion();
            acc.Parent = this.panel1;
            acc.CheckBoxMargin = new Padding(2);
            acc.ContentMargin = new Padding(15, 5, 15, 5);
            acc.ContentPadding = new Padding(1);
            acc.Insets = new Padding(5);
            acc.ControlBackColor = Color.White;
            acc.ContentBackColor = Color.CadetBlue;

           
             
            TableLayoutPanel tlp = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(5) };
            tlp.TabStop = true;

            for(int j = 0; j< count1; j++)
            {
                tlp.Controls.Add(new Label { Text = dtpackage.Rows[j][0].ToString(), TextAlign = ContentAlignment.BottomLeft }, 0, j);
                tlp.Controls.Add(new Button { Name = buttonname+j.ToString(), Text = "Remove" }, 1, j);
            }
                
                //tlp.Controls.Add(new Label { Text = "Package 2", TextAlign = ContentAlignment.BottomLeft }, 0, 1);
                //tlp.Controls.Add(new Button { Name = "btn2", Text = "Remove" }, 1, 1);
            
          

            for (int i = 0; i < count; i++)
            {
                string name = dtdriver.Rows[i][0].ToString();
                acc.Add(tlp, name);
               // acc.Add(new Button { Name = buttonname + i.ToString(), Text = "ADD" });
            }
            
            
            
           


           
           // acc.Add(new TextBox { Dock = DockStyle.Fill, Multiline = true, BackColor = Color.White }, "Memo", "Additional Client Info", 1, true, contentBackColor: Color.Transparent);
           // acc.Add(new Control(), "Other Info", "Miscellaneous information.");
            

          //  this.panel1.Controls.Add(acc);
          
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
