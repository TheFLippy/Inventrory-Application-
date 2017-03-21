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
        public string connectionString = @"Data Source=gapt-inventory.database.windows.net;Initial Catalog = Inventory; Persist Security Info=True;User ID = TheFLippy; Password=Gapt1234";
        public void sqlConnect()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
        }
        public bool login(string username, string password)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='" + username + "'", connectionString);
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1")
            {
                SqlCommand command = new SqlCommand("select * from login where username='" + username + "'", con);
                SqlDataReader read = command.ExecuteReader();
                string loginHash = null;

                while (read.Read())
                {
                    loginHash = (string)read["password"];
                }

                read.Close();
                con.Close();

                if(Hash.Confirm(password, loginHash))
                {
                    return true;
                }
            }
            //fails if username did not match
            return false;
        }

        public bool insert(string username, string password, string name, string surname, string group)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            
            string passwordHash = Hash.ComputeHash(password, null);

            User addUser = new User(username, passwordHash, name, surname, group);

            var myCommand = new SqlCommand("INSERT INTO login VALUES(@username, @password, @name, @surname, GETDATE(), @group)", conn);
            myCommand.Parameters.AddWithValue("@username", addUser.Username);
            myCommand.Parameters.AddWithValue("@password", addUser.Password);
            myCommand.Parameters.AddWithValue("@name", addUser.Name);
            myCommand.Parameters.AddWithValue("@surname", addUser.Surname);
            myCommand.Parameters.AddWithValue("@group", addUser.Group);
            //myCommand.Parameters.AddWithValue("@salt", addUser.Salt);

            int result = myCommand.ExecuteNonQuery();

            if (result != 0)
            {
                return true;
            }
            return false;
        }

    }
}
