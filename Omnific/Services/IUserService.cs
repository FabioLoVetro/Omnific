using Omnific.Model;

namespace Omnific.Services
{
    public interface IUserService
    {
        public User CreateNewUser(string username, string email, string password);
        public List<User> GetAllUsers();
    }
}
