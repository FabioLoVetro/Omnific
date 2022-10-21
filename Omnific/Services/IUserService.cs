using Omnific.Model;

namespace Omnific.Services
{
    public interface IUserService
    {
        public User CreateNewUser(string username, string email, string password);
        public User? UpdateUserById(int id, string newUserName, string newEMail, string newPassword);
        public User? GetUserById(int id);
        public User? GetUserByApiKey(string ApiKey);
        public User? GetUserByUsername(string username);
        public User? GetUserByEmail(string email);
        public List<User> GetAllUsers();
        public User? DeleteUserById(int id);
    }
}