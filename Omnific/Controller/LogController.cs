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
        public ActionResult<Log> CreateNewLogInController(string userName, string password)
        {
            var actionResult = _logService.CreateNewLog(userName, password);
            if (actionResult == null)
            {
                return NotFound();
            }
            return actionResult;
        }
    }
}
