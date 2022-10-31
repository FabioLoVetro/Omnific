using System;

namespace Omnific.Model
{
    /// <summary>
    /// Class User.
    /// Rapresent an User
    /// </summary>
    public class User
    {
        public int Id { get; set; } = 0;
        public string ApiKey { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public UserType UserType { get; set; } = UserType.Viewer;
        /// <summary>
        /// List of fonts to generate the APIKey
        /// </summary>
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="email"></param>
        /// <param name="passwordSalt"></param>
        /// <param name="passwordHash"></param>
        public User(string userName, string email, byte[] passwordSalt, byte[] passwordHash)
        {
            this.UserName = userName;
            this.Email = email;
            this.PasswordSalt = passwordSalt;
            this.PasswordHash = passwordHash;
            this.GenerateApiKey();
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
        /// <summary>
        /// public bool IsUserAdministrator()
        /// returns true if the user is an administrator,
        /// false otherwise
        /// </summary>
        /// <returns></returns>
        public bool IsUserAdministrator()
        {
            return this.UserType == UserType.Administrator;
        }

        /// <summary>
        /// public bool IsUserInventor()
        /// returns true if the user loggedin is an inventor,
        /// false otherwise
        /// </summary>
        /// <returns></returns>
        public bool IsUserInventor()
        {
            return this.UserType == UserType.Inventor;
        }
    }
}
