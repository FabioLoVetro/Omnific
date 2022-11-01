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
        public Log CreateNewLog(int IdUser)
        {
            var log = new Log(IdUser, DateTime.Now, DateTime.Now, true);
            _context.Add(log);
            _context.SaveChanges();

            return log;
        }
        /// <summary>
        /// Returns the list of the logs
        /// </summary>
        /// <returns></returns>
        public List<Log> GetAllLogs()
        {
            var log = _context.Logs.ToList();
            return log;
        }
    }
}
