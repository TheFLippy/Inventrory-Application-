using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory
{
    class db
    {
        string welcomeMsg;
        string privelage = null;




        #region Utility/Display functions
        public string connectionString = @"Data Source=gapt-inventory.database.windows.net;Initial Catalog = Inventory; Persist Security Info=True;User ID = TheFLippy; Password=Gapt1234";
        public void sqlConnect()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

        }
        public bool checkIfUserExists(string username)
        {

            //Create datatable to hold data retrieved from database
            DataTable dt = new DataTable();
            try
            {
                //Create connection
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                //Create adapter to hold the data
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='" + username + "'", connectionString);

                //Fill datatable with retrieved data
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }


            //Check if any login  a record, therefore record exists
            if (dt.Rows[0][0].ToString() == "1")
            {
                return true;
            }

            return false;
        }
        public string getJobPosition(string username)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand command = new SqlCommand("select * from login where username='" + username + "'", con);
                SqlDataReader read = command.ExecuteReader();
                privelage = null;


                while (read.Read())
                {
                    privelage = (string)read["jobPosition"];
                }


                read.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return privelage;
        }
        public string getWelcomeMessage(string username)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand command = new SqlCommand("select * from login where username='" + username + "'", con);
                SqlDataReader read = command.ExecuteReader();

                string name = null;
                string surname = null;
                string usr = null;

                while (read.Read())
                {
                    name = (string)read["name"];
                    surname = (string)read["surname"];
                    usr = (string)read["username"];
                }

                welcomeMsg = name + " " + surname + " (" + usr + ")";
                read.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return welcomeMsg;
        }
        #endregion

        #region Login SQL
        public bool login(string username, string password)
        {
            try
            {
                //Function that looks if user exists
                if (checkIfUserExists(username))
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();

                    //Construct query to get hash from the database
                    SqlCommand command = new SqlCommand("select * from login where username='" + username + "'", con);
                    SqlDataReader read = command.ExecuteReader();

                    //Reset data for logout to work
                    string loginHash = null;


                    //Read data from db
                    while (read.Read())
                    {
                        loginHash = (string)read["password"];
                    }

                    //close reader
                    read.Close();

                    //Pass both the entered password and hashed password, function hashes password and compares it to hash from database 
                    if (Hash.Confirm(password, loginHash))
                    {
                        return true;
                    }
                }

                //fails if username did not match

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }
            return false;
        }
        #endregion

        #region Employee SQL
        public bool insertEmp(string username, string password, string name, string surname, string group)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                if (!checkIfUserExists(username))
                {
                    string passwordHash = Hash.ComputeHash(password, null);
                    DataTable dt = new DataTable();

                    SqlDataAdapter sda = new SqlDataAdapter("select id from login order by id desc", connectionString);
                    sda.Fill(dt);

                    int id = Convert.ToInt32(dt.Rows[0][0]);
                    id += 1;

                    User addUser = new User(username, passwordHash, name, surname, group);

                    var myCommand = new SqlCommand("INSERT INTO login VALUES(@id, @username, @password, @name, @surname, GETDATE(), @group, default, GETDATE(), GETDATE(), 'false')", conn);
                    myCommand.Parameters.AddWithValue("@id", id);
                    myCommand.Parameters.AddWithValue("@username", addUser.Username);
                    myCommand.Parameters.AddWithValue("@password", addUser.Password);
                    myCommand.Parameters.AddWithValue("@name", addUser.Name);
                    myCommand.Parameters.AddWithValue("@surname", addUser.Surname);
                    myCommand.Parameters.AddWithValue("@group", addUser.jobPosition);

                    int result = myCommand.ExecuteNonQuery();
                    conn.Close();
                    if (result != 0)
                    {
                        string comment = "Added new employee id " + id;
                        addLogs(FormState.userName, comment);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return false;
        }
        public bool updateEmp(string username, string password, string name, string surname, string group, int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                string passwordHash = Hash.ComputeHash(password, null);

                User editUser = new User(username, passwordHash, name, surname, group);

                var myCommand = new SqlCommand("UPDATE login SET username = @username, password = @password, name = @name, surname = @surname, jobPosition = @group WHERE id='" + id + "'", conn);
                myCommand.Parameters.AddWithValue("@username", editUser.Username);
                myCommand.Parameters.AddWithValue("@password", editUser.Password);
                myCommand.Parameters.AddWithValue("@name", editUser.Name);
                myCommand.Parameters.AddWithValue("@surname", editUser.Surname);
                myCommand.Parameters.AddWithValue("@group", editUser.jobPosition);

                int result = myCommand.ExecuteNonQuery();

                if (result != 0)
                {
                    string comment = "Edite employee id " + id;
                    addLogs(FormState.userName, comment);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }


            return false;
        }
        public bool delete(int[] array)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != 0)
                    {
                        var myCommand = new SqlCommand("DELETE FROM login WHERE ID = @id", conn);
                        myCommand.Parameters.AddWithValue("@id", array[i]);

                        int result = myCommand.ExecuteNonQuery();

                        if (result == 0)
                        {
                            return false;
                        }
                        string comment = "Deleted package id " + array[i].ToString();
                        addLogs(FormState.userName, comment);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return true;
        }
        #endregion

        #region Package SQL
        public bool insertpack(float deliveryNumber, DateTime dueDate, float height, float length, float weight, float width, float returnNumber,
            string deliveryAddress1, string deliveryAddress2, string deliveryCity, string deliveryCountry,
            string deliveryName, string deliveryPostcode, string deliverySurname, string returnAddress1,
            string returnAddress2, string returnCity, string returnCountry, string returnName,
            string returnPostcode, string returnSurname, float packagenumber)
        {
            try
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

                var myCommand = new SqlCommand("INSERT INTO package VALUES(@id ,GETDATE(), GETDATE() ,NULL,'false','false', @deliveryNumber, @height, @length, @weight, @width, @returnNumber, @deliveryAddress1, @deliveryAddress2,@deliveryCity, @deliveryCountry, @deliveryName, @deliveryPostcode, @deliverySurname, @returnAddress1, @returnAddress2, @returnCity, @returnCountry, @returnName, @returnPostcode, @returnSurname, @packageNumber , NULL,'" + dueDate + "')", conn);
                myCommand.Parameters.AddWithValue("@id", id);
                myCommand.Parameters.AddWithValue("@deliveryNumber", addPack.deliverynumber);
                myCommand.Parameters.AddWithValue("@height", addPack.height);
                myCommand.Parameters.AddWithValue("@length", addPack.length);
                myCommand.Parameters.AddWithValue("@weight", addPack.weight);
                myCommand.Parameters.AddWithValue("@width", addPack.width);
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
                    string comment = "Added new package id " + id;
                    addLogs(FormState.userName, comment);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return false;
        }
        public bool updatepackage(int id, DateTime dueDate, float packagenumber, float weight, float height, float width, float length, string returnName, string returnSurname, float returnNumber, string returnAddress1, string returnAddress2, string returnCity, string returnPostcode, string returnCountry, string deliveryName, string deliverySurname, float deliveryNumber, string deliveryAddress1, string deliveryAddress2, string deliveryCity, string deliveryPostcode, string deliveryCountry)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                Package pk = new Package(deliveryNumber, height, length, weight, width, returnNumber, deliveryAddress1, deliveryAddress2, deliveryCity, deliveryCountry, deliveryName, deliveryPostcode, deliverySurname, returnAddress1, returnAddress2, returnCity, returnCountry, returnName, returnPostcode, returnSurname, packagenumber);

                var myCommand = new SqlCommand("UPDATE package SET deliveryNumber = @deliveryNumber, height = @height, length = @length, weight = @weight, width = @width , returnNumber = @returnNumber, deliveryAddress1 = @deliveryAddress1, deliveryCity = @deliveryCity, deliveryCountry = @deliveryCountry, deliveryName = @deliveryName , deliveryPostcode = @deliveryPostcode, deliverySurname = @deliverySurname, returnAddress1 = @returnAddress1, returnCity = @returnCity, returnCountry = @returnCountry, returnName = @returnName , returnPostcode = @returnPostcode, returnSurname = @returnSurname,packagenumber = @packagenumber, dueDate ='" + dueDate + "'  WHERE id='" + id + "'", conn);
                myCommand.Parameters.AddWithValue("@deliveryNumber", pk.deliverynumber);
                myCommand.Parameters.AddWithValue("@height", pk.height);
                myCommand.Parameters.AddWithValue("@length", pk.length);
                myCommand.Parameters.AddWithValue("@weight", pk.weight);
                myCommand.Parameters.AddWithValue("@width", pk.width);
                myCommand.Parameters.AddWithValue("@returnNumber", pk.returnnumber);
                myCommand.Parameters.AddWithValue("@deliveryAddress1", pk.deliveryaddress1);
                myCommand.Parameters.AddWithValue("@deliveryAddress2", pk.deliveryaddress2);
                myCommand.Parameters.AddWithValue("@deliveryCity", pk.deliverycity);
                myCommand.Parameters.AddWithValue("@deliveryCountry", pk.deliverycountry);
                myCommand.Parameters.AddWithValue("@deliveryName", pk.deliveryname);
                myCommand.Parameters.AddWithValue("@deliveryPostcode", pk.deliverypostcode);
                myCommand.Parameters.AddWithValue("@deliverySurname", pk.deliverysurname);
                myCommand.Parameters.AddWithValue("@returnAddress1", pk.returnaddress1);
                myCommand.Parameters.AddWithValue("@returnAddress2", pk.returnaddress2);
                myCommand.Parameters.AddWithValue("@returnCity", pk.returncity);
                myCommand.Parameters.AddWithValue("@returnCountry", pk.returncountry);
                myCommand.Parameters.AddWithValue("@returnName", pk.returnname);
                myCommand.Parameters.AddWithValue("@returnPostcode", pk.returnpostcode);
                myCommand.Parameters.AddWithValue("@returnSurname", pk.returnsurname);
                myCommand.Parameters.AddWithValue("@packageNumber", pk.packagenumber);



                int result = myCommand.ExecuteNonQuery();

                if (result != 0)
                {
                    string comment = "Edited package id " + id;
                    addLogs(FormState.userName, comment);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }


            return false;
        }
        public bool deletepackage(int[] array)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                for (int i = 0; i < array.Length; i++)
                {

                    if (array[i] != null)
                    {
                        var myCommand = new SqlCommand("UPDATE package SET deleted = 1 WHERE id =" + array[i].ToString(), conn);
                        int result = myCommand.ExecuteNonQuery();
                        string comment = "Deleted package id " + array[i].ToString();
                        addLogs(FormState.userName, comment);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return true;

        }
        #endregion

        #region Van SQL
        public bool deleteVan(int[] array)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != 0 && array[i] != null)
                    {
                        var myCommand = new SqlCommand("DELETE FROM van WHERE ID = @id", conn);
                        myCommand.Parameters.AddWithValue("@id", array[i]);

                        int result = myCommand.ExecuteNonQuery();

                        if (result == 0)
                        {
                            return false;
                        }
                        string comment = "Deleted van id " + array[i].ToString();
                        addLogs(FormState.userName, comment);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return true;
        }

        public bool insertvan(string noPlate, float volume, float weight, string make, string model, string engSize, int YoM)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();


                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP (1) id FROM package ORDER BY id DESC", connectionString);
                sda.Fill(dt);

                Van addVan = new Van(noPlate, volume, weight, "", 0, "Available", make, model, engSize, YoM);

                //for testing
                Console.WriteLine("to string: " + dt.Rows[0][0].ToString());
                Console.WriteLine("not to string: " + dt.Rows[0][0]);

                int id = Convert.ToInt32(dt.Rows[0][0]);
                //id += 1;

                //for testing
                Console.WriteLine("parsed" + id);

                var myCommand = new SqlCommand("INSERT INTO van VALUES(@noPlate,@volume,@weight, '', 0, 'Available', @make, @model, @engSize, @YoM, NULL)", conn);
                //myCommand.Parameters.AddWithValue("@id", id);
                myCommand.Parameters.AddWithValue("@noPlate", addVan.NoPlate);
                myCommand.Parameters.AddWithValue("@volume", addVan.Volume);
                myCommand.Parameters.AddWithValue("@weight", addVan.Weight);
                myCommand.Parameters.AddWithValue("@make", addVan.Make);
                myCommand.Parameters.AddWithValue("@model", addVan.Model);
                myCommand.Parameters.AddWithValue("@engSize", addVan.EngSize);
                myCommand.Parameters.AddWithValue("@yom", addVan.YOM);


                int result = myCommand.ExecuteNonQuery();

                if (result != 0)
                {
                    string comment = "Added new van " + addVan.NoPlate + " " + addVan.Model + " " + addVan.YOM;
                    addLogs(FormState.userName, comment);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return false;
        }
        public bool editvan(string noPlate, float volume, float weight, string location, int inUse, string state, string make, string model, string engSize, int YoM, int id, string driver)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                Van editVan = new Van(noPlate, volume, weight, location, inUse, state, make, model, engSize, YoM);

                var myCommand = new SqlCommand("UPDATE van SET noPlate = @noPlate, volume = @volume, weight = @weight, location = @location, inUse = @inUse, state = @state, make = @make, model = @model, engSize = @engSize, YoM = @YoM , driver = @driver WHERE id='" + id + "'", conn);
                myCommand.Parameters.AddWithValue("@noPlate", editVan.NoPlate);
                myCommand.Parameters.AddWithValue("@volume", editVan.Volume);
                myCommand.Parameters.AddWithValue("@weight", editVan.Weight);
                myCommand.Parameters.AddWithValue("@location", editVan.Location);
                myCommand.Parameters.AddWithValue("@inUse", editVan.InUse);
                myCommand.Parameters.AddWithValue("@state", editVan.State);
                myCommand.Parameters.AddWithValue("@make", editVan.Make);
                myCommand.Parameters.AddWithValue("@model", editVan.Model);
                myCommand.Parameters.AddWithValue("@engSize", editVan.EngSize);
                myCommand.Parameters.AddWithValue("@YoM", editVan.YOM);
                myCommand.Parameters.AddWithValue("@driver", driver);


                int result = myCommand.ExecuteNonQuery();

                if (result != 0)
                {
                    string comment = "Edited van id " + id + " to " + editVan.NoPlate + " " + editVan.Model + " " + editVan.YOM;
                    addLogs(FormState.userName, comment);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }


            return false;
        }
        #endregion

        #region Note SQL

        public List<int> noteID;

        public bool checkIfCanceled()
        {
            try
            {
                DataTable dt = new DataTable();
                //Create connection
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                //Create adapter to hold the data
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM PackageNote", connectionString);

                sda.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return false;
        }

        public List<string> returnNotes()
        {
            List<string> listOfNotes = new List<string>();
            string note = null;

            int tempID;
            noteID = new List<int>();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                //Construct query to get hash from the database
                SqlCommand command = new SqlCommand("select * from PackageNote", con);
                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    note += "Driver " + (string)read["username"] + " has canceled package no: " + read["packageNumber"] + " note: " + (string)read["note"] + "\n";

                    string comment = "Canceled package number " + read["packageNumber"] + " due to " + (string)read["note"];
                    addLogs((string)read["username"], comment);

                    tempID = Convert.ToInt32(read["packageNumber"]);
                    noteID.Add(tempID);

                    listOfNotes.Add(note);
                    note = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }


            return listOfNotes;
        }

        public void removeNotes()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                foreach (int i in noteID)
                {
                    var myCommand = new SqlCommand("DELETE FROM PackageNote WHERE packageNumber = @id", conn);
                    myCommand.Parameters.AddWithValue("@id", i);
                    myCommand.ExecuteNonQuery();

                    var myCommand2 = new SqlCommand("UPDATE package set driver = NULL WHERE packageNumber = @id2", conn);
                    myCommand2.Parameters.AddWithValue("@id2", i);
                    myCommand2.ExecuteNonQuery();

                    string comment = "Unassigned driver for package no: " + i;
                    addLogs(FormState.userName, comment);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

        }

        #endregion

        #region Logs/History SQL

        public bool addLogs(string userName, string comment)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                var myCommand = new SqlCommand("INSERT INTO logs VALUES('" + userName + "', GETDATE(), '" + comment + "')", conn);

                int result = myCommand.ExecuteNonQuery();
                conn.Close();

                if (result != 0)
                {

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred whilst trying to connect to the database. Please try again.");

            }

            return false;
        }

        #endregion
    }

}
