using Microsoft.EntityFrameworkCore;
using Omnific.Model;

namespace Omnific.Services
{

    public class UserService : IUserService
    {
        /// <summary>
        /// The context to inject
        /// </summary>
        private readonly OmnificContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserService(OmnificContext context)
        {
            _context = context;
        }

        /// <summary>
        /// public User CreateNewUser(string userName, string eMail, string password)
        /// create a new user and add it in the database
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="eMail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User CreateNewUser(string userName, string eMail, string password)
        {
            var user = new User(userName, eMail, password);
            user.GenerateApiKey();

            _context.Add(user);
            _context.SaveChanges();

            return user;
        }

        /// <summary>
        /// public User DeleteUserById(int id)
        /// return the user deleted by id,
        /// null if is not possible delete the user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        /// <summary>
        public User? DeleteUserById(int id)
        {
            if (this.UserExists(id))
            {
                var user = GetUserById(id);
                _context.Remove(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        /// <summary>
        /// public List<User> GetAllUsers()
        /// retrieves all the users in a list
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        /// <summary>
        /// public User GetUserByApiKey(string ApiKey)
        /// returns the user by APIKey
        /// </summary>
        /// <param name="ApiKey"></param>
        /// <returns></returns>
        public User? GetUserByApiKey(string ApiKey)
        {
            var user = _context.Users.FirstOrDefault(user => user.ApiKey == ApiKey);
            return user;
        }

        /// <summary>
        /// public User GetUserByEmail(string email)
        /// returns the user by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User? GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(user => user.Email == email);
            return user;
        }

        /// <summary>
        /// public User GetUserById(int id)
        /// returns the user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User? GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        /// <summary>
        /// public User GetUserByUsername(string username)
        /// returns the user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User? GetUserByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(user => user.UserName == username);
            return user;
        }

        /// <summary>
        /// public User UpdateUserById(int id, User user)
        /// returns the user updated by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public User? UpdateUserById(int id, string newUserName, string newEMail, string newPassword)
        {
            if (this.UserExists(id))
            {
                var u = this.GetUserById(id);
                u.UserName = newUserName;
                u.Email = newEMail;
                u.Password = newPassword;
                _context.SaveChanges();
                return u;
            }
            return null;
        }
        /// <summary>
        /// Checks if exists an user with the id
        /// passed as parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UserExists(int id)
        {
            return _context.Users.Any(b => b.Id == id);
        }
    }
}
