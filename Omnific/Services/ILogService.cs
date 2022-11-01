using Omnific.Model;

namespace Omnific.Services
{
    public interface ILogService
    {
        public Log CreateNewLog(int IdUser);
        //public Log UpdateLogById(int id, Log log);
        //public Log GetLogById(int id);
        public List<Log> GetAllLogs();
    }
}