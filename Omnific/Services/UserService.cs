using Omnific.Model;

namespace Omnific.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public User CreateNewUser()
        {
            return new User();
        }
    }
}
