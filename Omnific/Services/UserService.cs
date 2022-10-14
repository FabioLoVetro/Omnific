using Microsoft.EntityFrameworkCore;
using Omnific.Model;

namespace Omnific.Services
{

    public class UserService : IUserService
    {
        private readonly OmnificContext _context;

        public UserService(OmnificContext context)
        {
            _context = context;
        }

        public User CreateNewUserService(string userName, string eMail, string password)
        {
            User user = new User(userName,eMail,password);

            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> GetAllUsersService()
        {
            var Users = _context.Users.ToList();
            return Users;

        }
    }
}
