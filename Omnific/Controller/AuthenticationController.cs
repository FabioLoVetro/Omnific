using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omnific.Model;
using Omnific.Services;

namespace Omnific.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private IUserService _userService;

        public AuthenticationController(IAuthenticationService authenticationService,IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<string> Login(string userName, string password)
        {
            if (!_userService.UserExistsByUserName(userName))
                return NotFound("User Not Found!");

            var user = _userService.GetUserByUsername(userName);

            if (!_authenticationService.VerifyPasswordHash(user,password)) 
                return BadRequest("Wrong password!");

            var token = _authenticationService.Login(user);

            return token;
        }
    }
}
