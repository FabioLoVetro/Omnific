using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omnific.Model;
using Omnific.Services;

namespace Omnific.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class LogController : ControllerBase
    {
        private ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public ActionResult<Log> CreateNewLogInController(int IdUser)
        {
            var actionResult = _logService.CreateNewLog(IdUser);

            return actionResult;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Log>> GetAllLogsController()
        {
            var actionResult = _logService.GetAllLogs();

            return actionResult;
        }
    }
}
