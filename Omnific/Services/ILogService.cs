using Omnific.Model;

namespace Omnific.Services
{
    public interface ILogService
    {
        public Log? CreateNewLog(string userName, string password);
        //public Log UpdateLogById(int id, Log log);
        //public Log GetLogById(int id);
        //public List<Log> GetAllLogs();
    }
}