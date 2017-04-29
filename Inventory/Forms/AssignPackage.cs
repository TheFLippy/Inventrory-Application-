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

            SqlDataAdapter sda = new SqlDataAdapter("SELECT  deliveryCity FROM package WHERE deleted = 0 AND delivered = 0 AND driver IS NULL", connectionString);
            sda.Fill(dtpackage);

            return dtpackage.ToString();
        }


        private void AssignPackage_Load(object sender, EventArgs e)
        {
            //add.Visible = false;
            string buttonName = "btn";
            //area1
            string[] city = new string[] { "Qala", "Kercem" };
            //area2
            string[] city2 = new string[] { "Munxar" };


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

            int totalPackages = count1 / count;


            Queue<string> que = new Queue<string>();
            for (int i = 0; i < city.GetLength(0); i++)
            {
                for (int j = 0; j < count1; j++)
                {
                    if (dtpackage.Rows[j][0].ToString() == city[i])
                    {
                        que.Enqueue(dtpackage.Rows[j][0].ToString());
                        Console.WriteLine("FOUND\t" + dtpackage.Rows[j][0].ToString());
                    }
                }
            }


            for (int i = 0; i < city2.GetLength(0); i++)
            {
                for (int j = 0; j < count1; j++)
                {
                    if (dtpackage.Rows[j][0].ToString() == city2[i])
                    {
                        que.Enqueue(dtpackage.Rows[j][0].ToString());
                        Console.WriteLine("FOUND\t" + dtpackage.Rows[j][0].ToString());
                    }
                }
            }


            Accordion acc = new Accordion();
            acc.Parent = this.panel1;
            acc.CheckBoxMargin = new Padding(2);
            acc.ContentMargin = new Padding(15, 5, 15, 5);
            acc.ContentPadding = new Padding(1);
            acc.Insets = new Padding(5);
            acc.ControlBackColor = Color.White;
            acc.ContentBackColor = Color.CadetBlue;

            int pk = 1;

            for (int i = 0; i < count; i++)
            {

                TableLayoutPanel tlp = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(5) };
                string name = dtdriver.Rows[i][0].ToString();

                for (int j = 0; j < totalPackages; j++)
                {
                    
                    tlp.Controls.Add(new Label { Text = que.Dequeue(), TextAlign = ContentAlignment.BottomLeft }, 0, j);
                    //  tlp.Controls.Add(new Button { Name = "remove", Text = "Remove" }, 1, j);
                    Button remove = new Button();
                    //remove.Location = new Point(1, j);
                    remove.Text = "Remove";
                    tlp.Controls.Add(remove,1,j);
                    remove.Click += new EventHandler(this.remove_Click);


                }

                Button add = new Button();
                add.Text = "ADD";
                tlp.Controls.Add(add,1,count+1);
                add.Click += new EventHandler(this.add_Click);
                acc.Name = 1.ToString() + i.ToString();
                acc.Add(tlp, name);
                pk++;

                if(pk == count+1)
                {
                    if(que.Count != 0)
                    {
                        name = "TO ADD";
                        TableLayoutPanel tlp1 = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(5) };
                        for (int j = 0; j <que.Count; j++)
                        {
                            tlp1.Controls.Add(new Label { Text = que.Dequeue(), TextAlign = ContentAlignment.BottomLeft }, 0, j);
                            tlp1.Controls.Add(new Button { Name = buttonName + j.ToString(), Text = "Remove" }, 1, j);
                        }
                        acc.Add(tlp1, name);
                    }
                }
                
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_Click(Object sender , EventArgs e)
        {
            Console.WriteLine("Button Works");
        }

        private void remove_Click(Object sender , EventArgs e)
        {
            Console.WriteLine("Button remove Works");
        }
     
    }
}
