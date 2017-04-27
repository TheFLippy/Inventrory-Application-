namespace Inventory
{
    public class User
    {
        public User(string username, string password, string name, string surname, string group)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.jobPosition = group;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string jobPosition { get; set; }

    }
}
