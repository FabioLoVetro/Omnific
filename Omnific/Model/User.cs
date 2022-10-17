using System;

namespace Omnific.Model
{
    public class User
    {
        public int Id { get; set; }
        public string ApiKey { get; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Type Type { get; }

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public User(string UserName, string Email, string Password)
        {
            this.ApiKey = $"{new string(Enumerable.Repeat(chars, 8).Select(s => s[new Random().Next(s.Length)]).ToArray())}";
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
            this.Type = Type.Viewer;
        }
    }
}
