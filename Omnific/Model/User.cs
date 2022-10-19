using System;

namespace Omnific.Model
{
    /// <summary>
    /// Class User.
    /// Rapresent an User
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string ApiKey { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        /// <summary>
        /// List of fonts to generate the APIKey
        /// </summary>
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        public User(string UserName, string Email, string Password)
        {
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
            this.UserType = UserType.Viewer;
        }
        /// <summary>
        /// public void GenerateApiKey()
        /// Generate an APIKey for the user.
        /// An APIKey is a sequence of alphanumeric char with length 8
        /// </summary>
        public void GenerateApiKey()
        {
            ApiKey = $"{new string(Enumerable.Repeat(chars, 8).Select(s => s[new Random().Next(s.Length)]).ToArray())}";
        }
    }
}
