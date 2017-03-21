namespace Inventory
{
    public class User
    {
        public User(string username, string password, string name, string surname, string group)
        {
            //this.id = id;
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.Group = group;
            //this.Salt = salt;
        }

        //public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        //public string Salt { get; set; }

    }
}