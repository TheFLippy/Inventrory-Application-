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
       // Form adding;
        ComboBox drivercmbx;
        DataTable dtdriver;
        DataTable dtpackage;
        int count;
        int index;
        int check = 0;
        int position;
        int pos = 0;
        string packid;

        Accordion acc;

        public string connectionString = @"Data Source=gapt-inventory.database.windows.net;Initial Catalog = Inventory; Persist Security Info=True;User ID = TheFLippy; Password=Gapt1234";
        //to store tlp
        List<TableLayoutPanel> tlplst = new List<TableLayoutPanel>();
        //to store to add tlp
        List<TableLayoutPanel> tlp1lst = new List<TableLayoutPanel>();

        //list to store accordions
        List<String> acclst = new List<string>();


        //to store labels
        List<Label> labellst = new List<Label>();
        //to store to add labels
        List<Label> addlabellst = new List<Label>();
        //to store to add button
        List<Button> addbuttonlst = new List<Button>();
        //to store remove buttons
        List<Button> buttonlst = new List<Button>();
        //checkbox list
        List<CheckBox> chklst = new List<CheckBox>();

        //queue to hold labels to remove 
        Queue<Label> labelque = new Queue<Label>();
        //stores the items to add 
        Queue<Label> addPackage = new Queue<Label>();

        Queue<string> que = new Queue<string>();

        DataTable packageid = new DataTable();

        public AssignPackage()
        {
            InitializeComponent();
        }

        private string assigndriver(DataTable dtdriver)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT username FROM login WHERE jobPosition = 'Driver'", connectionString);
            sda.Fill(dtdriver);

            return dtdriver.ToString();
        }

        private string assignpackage(DataTable dtpackage)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT  deliveryCity,id, packageNumber FROM package WHERE deleted = 0 AND delivered = 0 AND driver IS NULL", connectionString);
            sda.Fill(dtpackage);
            
            return dtpackage.ToString();
        }

        private void AssignPackage_Load(object sender, EventArgs e)
        {

            //area1
            string[] city = new string[] { "Qala", "Kercem" };
            //area2
            string[] city2 = new string[] { "Munxar", "Victoria" };
            //area 3
            string[] city3 = new string[] { "Xaghra" };


            dtdriver = new DataTable();
            assigndriver(dtdriver);
            count = dtdriver.Select().Length;
            //testing
            Console.WriteLine("dt count\t" + count);


            dtpackage = new DataTable();
            assignpackage(dtpackage);
            int count1 = dtpackage.Select().Length;
            //testing
            Console.WriteLine("dt count1 \t" + count1);

            int totalPackages = count1 / count;


           
            for (int i = 0; i < city.GetLength(0); i++)
            {
                for (int j = 0; j < count1; j++)
                {
                    if (dtpackage.Rows[j][0].ToString() == city[i])
                    {
                        que.Enqueue(dtpackage.Rows[j][1].ToString() + dtpackage.Rows[j][0].ToString());
                        Console.WriteLine("FOUND\t" + dtpackage.Rows[j][1].ToString() + dtpackage.Rows[j][0].ToString());
                    }
                }
            }


            for (int i = 0; i < city2.GetLength(0); i++)
            {
                for (int j = 0; j < count1; j++)
                {
                    if (dtpackage.Rows[j][0].ToString() == city2[i])
                    {
                        que.Enqueue(dtpackage.Rows[j][1].ToString() + dtpackage.Rows[j][0].ToString());
                        Console.WriteLine("FOUND\t" + dtpackage.Rows[j][0].ToString());
                    }
                }
            }


            for (int i = 0; i < city3.GetLength(0); i++)
            {
                for (int j = 0; j < count1; j++)
                {
                    if (dtpackage.Rows[j][0].ToString() == city3[i])
                    {
                        que.Enqueue(dtpackage.Rows[j][1].ToString() + dtpackage.Rows[j][0].ToString());
                        Console.WriteLine("FOUND\t" + dtpackage.Rows[j][1].ToString() + dtpackage.Rows[j][0].ToString());
                    }
                }
            }

            acc = new Accordion();
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

                TableLayoutPanel tlp = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(5)};
                string name = dtdriver.Rows[i][0].ToString();

                for (int j = 0; j < totalPackages; j++)
                {
                    tlp.Name = name;

                    Label lb = new Label();
                    lb.Text = que.Dequeue();
                    tlp.Controls.Add(lb, 0, j);
                    labellst.Add(lb);

                    Button remove = new Button();
                    remove.Text = "Remove";
                    buttonlst.Add(remove);
                    tlp.Controls.Add(remove, 1, j);
                    remove.Click += new EventHandler(this.remove_Click);
                    position = j;

                }
     
                tlplst.Add(tlp);
                acc.Add(tlp, name);
               // acc.Name = name;
                acclst.Add(acc.Name);
                pk++;

                if (pk == count + 1)
                {
                    if (que.Count != 0)
                    {
                       
                        for (int j = 0; j < que.Count; j++)
                        {
                            
                            //creating label
                            Label addlb = new Label();
                            addlb.Text = que.Dequeue();
                            //addlabellst.Add(addlb);
                            //addPackage.Enqueue(addlb);
                            labellst.Add(addlb);
                            tlp.Controls.Add(addlb, 0,position+1);

                            Button remove = new Button();
                            remove.Text = "Remove";
                            remove.Name = "rmv" + j.ToString();
                            buttonlst.Add(remove);
                            tlp.Controls.Add(remove, 1, position+1);
                            remove.Click += new EventHandler(this.remove_Click);

                            
                            pos = position;
                        }

                        
                    }
                }

            }

            
            Label l = new Label();
            l.Text = "To Add";
            l.AutoSize = false;
            l.TextAlign = ContentAlignment.TopCenter;
            adding.Controls.Add(l);

            Label lb1 = new Label();
            lb1.Visible = false;
            adding.Controls.Add(lb1);

            Label lb2 = new Label();
            lb2.Visible = false;
            adding.Controls.Add(lb2);

            adding.FlowDirection = FlowDirection.TopDown;
            drivercmbx = new ComboBox();
            drivercmbx.Text = "Select driver";
            for (int k = 0; k < count; k++)
            {
                drivercmbx.Items.Add(dtdriver.Rows[k][0].ToString());
            }
            flowLayoutPanel1.Controls.Add(drivercmbx);


            Button addbtn = new Button();
            addbtn.Text = "Add";
            addbtn.Click += new EventHandler(this.addbtn_Click);
            flowLayoutPanel1.Controls.Add(addbtn);
            flowLayoutPanel1.Show();


        }

        private void addbtn_Click(Object sender, EventArgs e)
        {
            check = 0;
            int c = 0;

            for(int x = 0; x < chklst.Count; x++)
            {
                if (chklst.ElementAt(x).Checked == false)
                {
                    c++;
                }

            }


            if (c == chklst.Count)
            {
                MessageBox.Show("Please choose a package");
                return;
            }

            for (int j = 0; j < count; j++)
            {
                if (drivercmbx.SelectedItem == dtdriver.Rows[j][0])
                {
                    index = j;
                }
            }


            for (int i = 0; i < chklst.Count; i++)
            {
                if (chklst.ElementAt(i).Checked)
                {
                    chklst.ElementAt(i).Visible = false;
                    chklst.ElementAt(i).Checked = false;
                    check++;

                }
            }
           

            for (int k = 0; k < check; k++)
            {
                Label label = new Label();
                label.Text = addPackage.Dequeue().Text.ToString();
                
                tlplst.ElementAt(index).Controls.Add(label, 0, pos+4);
                labellst.Add(label);

                Button bt = new Button();
                bt.Text = "Remove";
                buttonlst.Add(bt);
                //remove.Click += new EventHandler(this.remove_Click);
                bt.Click += new EventHandler(this.remove_Click);

                tlplst.ElementAt(index).Controls.Add(bt, 1, pos+4); 
                pos++;

            }
          

            check = 0;
            acc.Hide();
            acc.Show();

        }

        private void remove_Click(Object sender, EventArgs e)
        {
            
            for (int j = 0; j < buttonlst.Count; j++)
            {
                if (sender == buttonlst.ElementAt(j))
                {
                  
                   // labellst.ElementAt(j).Visible = false;
                    buttonlst.ElementAt(j).Visible = false;
                    for(int i = 0; i < tlplst.Count; i++)
                    {
                        foreach (Control c in tlplst.ElementAt(i).Controls)
                        {
                            if(c is Label)
                            {
                                if(c == labellst.ElementAt(j))
                                {
                                    tlplst.ElementAt(i).Controls.Remove(labellst.ElementAt(j));
                                }
                            }
                        }
                    }
                   


                    acc.Hide();
                    acc.Show();
                    //  labelque.Enqueue(labellst.ElementAt(j));
                    addPackage.Enqueue(labellst.ElementAt(j));
                    addpk(labellst.ElementAt(j));
                }
            }
        }
        
        private void addpk(Label lb)
        { 
                CheckBox ckb = new CheckBox();
                ckb.Text = lb.Text.ToString();
                ckb.AutoSize = true;
                chklst.Add(ckb);
                adding.Controls.Add(ckb);
                
        }

        private void AssignBtn_Click(object sender, EventArgs e)
        {
            int k = 0;
            int pkcount = 0;
            
            
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {
                for (int i = 0; i < tlplst.Count; i++)
                {
                    foreach (Control lb in tlplst.ElementAt(i).Controls)
                    {
                        if (lb is Label)
                        {
                            string drivername = tlplst.ElementAt(i).Name.ToString();
                            Console.WriteLine("DRIVER NAME: \t\t" + drivername);

                            for(int j =0; j < dtpackage.Rows.Count; j++)
                            {
                                if(lb.Text.Equals(dtpackage.Rows[j][1].ToString()+ dtpackage.Rows[j][0].ToString()))
                                {
                                   packid = dtpackage.Rows[j][2].ToString();
                                   break;
                                }
                            }

                            if (k <= dtpackage.Rows.Count)
                            {
                                var mycommand = new SqlCommand("UPDATE package SET driver = @drivername WHERE packageNumber = @id", conn);
                                mycommand.Parameters.AddWithValue("@drivername", drivername);
                                mycommand.Parameters.AddWithValue("@id", packid);
                                Console.WriteLine("dtpackage.Rows[k][1]: \t\t" + packid);
                                k++;
                                pkcount++;
                                
                                int result = mycommand.ExecuteNonQuery();
                                if (result != 0)
                                {
                                    Console.WriteLine("ROWS AFFECTED");
                                }
                                else
                                {
                                    Console.WriteLine("ROWS NOT AFFECTED");
                                }
                            }
                        }
                      
                    }
                }
                if(pkcount > 0)
                {
                    MessageBox.Show("The packages were assigned");
                }
                else
                {
                    MessageBox.Show("No packages were assigned");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();

          
        }

        private void AssignPackage_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to exit the application?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (d == DialogResult.OK)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
