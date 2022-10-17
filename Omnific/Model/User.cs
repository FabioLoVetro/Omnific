using System;

namespace Omnific.Model
{
    public class User
    {
        public int Id { get; set; }
        public string ApiKey { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType Type { get; }

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public User(string UserName, string Email, string Password)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
            this.Type = UserType.Viewer;
        }

        public void GenerateApiKey()
        {
            ApiKey = $"{new string(Enumerable.Repeat(chars, 8).Select(s => s[new Random().Next(s.Length)]).ToArray())}";
        }
    }
}
