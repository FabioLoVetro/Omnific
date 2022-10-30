using Microsoft.AspNetCore.Identity;
using Omnific.Model;

namespace Omnific.Services
{
    public interface IUserService
    {
        public User CreateNewUser(string username,string email,byte[] passwordSalt,byte[] passwordHash);
        public User UpdateUserById(int idUserToUpdate, string newUserName, string newEMail, byte[] passwordSalt, byte[] passwordHash);
        public User GetUserById(int id);
        public User GetUserByApiKey(string ApiKey);
        public User GetUserByUsername(string username);
        public User GetUserByEmail(string email);
        public List<User> GetAllUsers();
        public User DeleteUserById(int id);
        public bool UserExistsById(int id);
        public bool UserExistsByUserName(string userName);
        public bool UserExistsByEMail(string eMail);
        public bool UserExistsByAPIKey(string APIKey);
    }
}