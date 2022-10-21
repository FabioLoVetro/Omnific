using Microsoft.EntityFrameworkCore;
using Omnific.Model;

namespace Omnific.Services
{
    public class LogService : ILogService
    {
        /// <summary>
        /// The context to inject
        /// </summary>
        private readonly OmnificContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public LogService(OmnificContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create and return a new record of log for an user,
        /// null otherwise.
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="DateTimeIn"></param>
        /// <param name="DateTimeOut"></param>
        /// <param name="IsLoggedIn"></param>
        /// <returns></returns>
        public Log? CreateNewLog(string userName, string password)
        {
            foreach (var entity in _context.Logs)
                _context.Logs.Remove(entity);
            _context.SaveChanges();
            //try to retrive the user
            var userLoggedIn = _context.Users.FirstOrDefault(user => user.UserName == userName && user.Password == password);
            //if is null
            if (userLoggedIn == null) return null;
            
            var log = new Log(userLoggedIn.Id, DateTime.Now, DateTime.Now, true);
            _context.Add(log);
            _context.SaveChanges();
            return log;
        }
    }
}
