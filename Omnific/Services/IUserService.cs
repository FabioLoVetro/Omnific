using Omnific.Model;

namespace Omnific.Services
{
    public interface IUserService
    {
        public User CreateNewUserService(string username, string email, string password);
        public List<User> GetAllUsersService();
    }
}
