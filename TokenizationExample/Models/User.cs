namespace TokenizationExample.Models
{
    public class User
    {
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public User(string name, string username, string password)
        {
            this.name = name;
            this.username = username;
            this.password = password;
        }
    }
}
