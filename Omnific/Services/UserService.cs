using Microsoft.AspNetCore.Identity;
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
        /// <param name="passwordSalt"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public User CreateNewUser(string userName, string eMail, byte[] passwordSalt, byte[] passwordHash)
        {
            var user = new User(userName, eMail, passwordSalt, passwordHash);

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
        public User DeleteUserById(int id)
        {
            var user = GetUserById(id);
            _context.Remove(user);
            _context.SaveChanges();
            return user;
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
        public User GetUserByApiKey(string ApiKey)
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
        public User GetUserByEmail(string email)
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
        public User GetUserById(int id)
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
        public User GetUserByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(user => user.UserName == username);
            return user;
        }

        /// <summary>
        /// public User UpdateUserById(int id, User user)
        /// returns the user updated by id</summary>
        /// <param name="idUserToUpdate"></param>
        /// <param name="newUserName"></param>
        /// <param name="newEMail"></param>
        /// <param name="passwordSalt"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public User UpdateUserById(int idUserToUpdate, string newUserName, string newEMail, byte[] passwordSalt, byte[] passwordHash)
        { 
            var user = this.GetUserById(idUserToUpdate);
            user.UserName = newUserName;
            user.Email = newEMail;
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            _context.SaveChanges();

            return user;
        }
        /// <summary>
        /// Checks if exists an user with the id
        /// passed as parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UserExistsById(int id)
        {
            return _context.Users.Any(user => user.Id == id);
        }
        /// <summary>
        /// Checks if exists an user with the userName
        /// passed as parameter
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UserExistsByUserName(string userName)
        {
            return _context.Users.Any(user => user.UserName == userName);
        }
        /// <summary>
        /// Checks if exists an user with the email
        /// passed as parameter
        /// </summary>
        /// <param name="eMail"></param>
        /// <returns></returns>
        public bool UserExistsByEMail(string eMail)
        {
            return _context.Users.Any(user => user.Email == eMail);
        }
        /// <summary>
        /// Checks if exists an user with the APIKey
        /// passed as parameter
        /// </summary>
        /// <param name="APIKey"></param>
        /// <returns></returns>
        public bool UserExistsByAPIKey(string APIKey)
        {
            return _context.Users.Any(user => user.ApiKey == APIKey);
        }
    }
}
