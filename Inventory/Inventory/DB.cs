using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Inventory
{
    class db
    {
        //public string connectionString = @"Data Source=gapt-inventory.database.windows.net;Initial Catalog = Inventory; Persist Security Info=True;User ID = TheFLippy; Password=Gapt1234";
        public string connectionString = @"Data Source=gapt-inventory.database.windows.net;Initial Catalog = Inventory; Persist Security Info=True;User ID = TheFLippy; Password=Gapt1234"; 
        public void sqlConnect()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public bool login(string username, string password)
        {
            sqlConnect();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='" + username + "' AND password='" + password + "'", connectionString);
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                return true;
            }

            return false;
        }

        public void insert(string username, string password, string email)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string query = "INSERT INTO login (username, password, email) VALUES ('" + username + "', '" + password + "', '" + email + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
        
    }
}
