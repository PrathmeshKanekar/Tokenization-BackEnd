namespace TokenizationExample.Models
{
    public class LoginResult
    {
        public string status { get; set; }

        public string token { get; set; }

        public User user { get; set; }
    }
}
