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

        public User CreateNewUser(string userName, string eMail, string password)
        {
            var user = new User(userName, eMail, password);
            user.GenerateApiKey();

            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }
    }
}
