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

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='" + username + "'", connectionString);
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                return false;
            }

            string passwordHash = Hash.ComputeHash(password, null);

            User addUser = new User(username, passwordHash, name, surname, group);

            var myCommand = new SqlCommand("INSERT INTO login VALUES(@username, @password, @name, @surname, GETDATE(), @group)", conn);
            myCommand.Parameters.AddWithValue("@username", addUser.Username);
            myCommand.Parameters.AddWithValue("@password", addUser.Password);
            myCommand.Parameters.AddWithValue("@name", addUser.Name);
            myCommand.Parameters.AddWithValue("@surname", addUser.Surname);
            myCommand.Parameters.AddWithValue("@group", addUser.Group);

            int result = myCommand.ExecuteNonQuery();

            if (result != 0)
            {
                return true;
            }
            return false;
        }

       
        public bool insertpack( float deliveryNumber, float height, float length, float weight, float width, float returnNumber, 
            string deliveryAddress1, string deliveryAddress2, string deliveryCity, string deliveryCountry, 
            string deliveryName , string deliveryPostcode, string deliverySurname, string returnAddress1, 
            string returnAddress2, string returnCity, string returnCountry, string returnName,
            string returnPostcode, string returnSurname,float packagenumber)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();


            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP (1) id FROM package ORDER BY id DESC", connectionString);
            sda.Fill(dt);

            Package addPack = new Package(deliveryNumber, height, length, weight, width, returnNumber, deliveryAddress1, deliveryAddress2, deliveryCity, deliveryCountry, deliveryName, deliveryPostcode, deliverySurname, returnAddress1, returnAddress2, returnCity, returnCountry, returnName, returnPostcode, returnSurname, packagenumber);
            
            //for testing
            Console.WriteLine("to string: " + dt.Rows[0][0].ToString());
            Console.WriteLine("not tring: " + dt.Rows[0][0]);
            
            int id = Convert.ToInt32(dt.Rows[0][0]);
            id += 1;

            //for testing
            Console.WriteLine("parsed" + id);

            var myCommand = new SqlCommand("INSERT INTO package VALUES(@id ,GETDATE(),GETDATE(),NULL,'false','false', @deliveryNumber, @height, @length, @weight, @width, @returnNumber, @deliveryAddress1, @deliveryAddress2,@deliveryCity, @deliveryCountry, @deliveryName, @deliveryPostcode, @deliverySurname, @returnAddress1, @returnAddress2, @returnCity, @returnCountry, @returnName, @returnPostcode, @returnSurname, @packageNumber , 'Scamel')", conn);
            myCommand.Parameters.AddWithValue("@id", id);
            myCommand.Parameters.AddWithValue("@deliveryNumber", addPack.deliverynumber);
            myCommand.Parameters.AddWithValue("@height", addPack.height);
            myCommand.Parameters.AddWithValue("@length", addPack.length);
            myCommand.Parameters.AddWithValue("@weight", addPack.weight);
            myCommand.Parameters.AddWithValue("@width",  addPack.width);
            myCommand.Parameters.AddWithValue("@returnNumber", addPack.returnnumber);
            myCommand.Parameters.AddWithValue("@deliveryAddress1", addPack.deliveryaddress1);
            myCommand.Parameters.AddWithValue("@deliveryAddress2", addPack.deliveryaddress2);
            myCommand.Parameters.AddWithValue("@deliveryCity", addPack.deliverycity);
            myCommand.Parameters.AddWithValue("@deliveryCountry", addPack.deliverycountry);
            myCommand.Parameters.AddWithValue("@deliveryName", addPack.deliveryname);
            myCommand.Parameters.AddWithValue("@deliveryPostcode", addPack.deliverypostcode);
            myCommand.Parameters.AddWithValue("@deliverySurname", addPack.deliverysurname);
            myCommand.Parameters.AddWithValue("@returnAddress1", addPack.returnaddress1);
            myCommand.Parameters.AddWithValue("@returnAddress2", addPack.returnaddress2);
            myCommand.Parameters.AddWithValue("@returnCity", addPack.returncity);
            myCommand.Parameters.AddWithValue("@returnCountry", addPack.returncountry);
            myCommand.Parameters.AddWithValue("@returnName", addPack.returnname);
            myCommand.Parameters.AddWithValue("@returnPostcode", addPack.returnpostcode);
            myCommand.Parameters.AddWithValue("@returnSurname", addPack.returnsurname);
            myCommand.Parameters.AddWithValue("@packageNumber", addPack.packagenumber);

            int result = myCommand.ExecuteNonQuery();
           
            if (result != 0)
            {
                return true;
            }
            return false;
        }





        public bool update(string username, string password, string name, string surname, string group, int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string passwordHash = Hash.ComputeHash(password, null);

            User editUser = new User(username, passwordHash, name, surname, group);

            var myCommand = new SqlCommand("UPDATE login SET username = @username, password = @password, name = @name, surname = @surname WHERE id='" + id + "'", conn);
            myCommand.Parameters.AddWithValue("@username", editUser.Username);
            myCommand.Parameters.AddWithValue("@password", editUser.Password);
            myCommand.Parameters.AddWithValue("@name", editUser.Name);
            myCommand.Parameters.AddWithValue("@surname", editUser.Surname);
            //myCommand.Parameters.AddWithValue("@group", editUser.Group);

            int result = myCommand.ExecuteNonQuery();

            if (result != 0)
            {
                return true;
            }

            return false;
        }

        public bool delete(int[] array)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] != 0 && array[i] != null)
                {
                    var myCommand = new SqlCommand("DELETE FROM login WHERE ID = @id", conn);
                    myCommand.Parameters.AddWithValue("@id", array[i]);

                    int result = myCommand.ExecuteNonQuery();

                    if(result == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
