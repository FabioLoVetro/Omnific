using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omnific.Services;
using Omnific.Model;

namespace Omnific.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> CreateUserController(string username, string email, string password)
        {
            return _userService.CreateNewUser(username, email, password);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsersController()
        {
            return _userService.GetAllUsers();
        }
    }
}
