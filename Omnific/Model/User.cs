using System;

namespace Omnific.Model
{
    public class User
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public User(string username, string email, string password)
        {
            this.ApiKey = $"{new string(Enumerable.Repeat(chars, 8).Select(s => s[new Random().Next(s.Length)]).ToArray())}";
            this.UserName = username;
            this.Email = email;
            this.Password = password;
            this.Type = Type.Viewer;
        }

        public int Id { get;}
        public string ApiKey { get;}
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Type Type { get;}
    }
}
