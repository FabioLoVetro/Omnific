using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omnific.Services;
using Omnific.Model;
using Microsoft.AspNetCore.Authorization;

namespace Omnific.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IAuthenticationService _authenticationService;

        public UserController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpPost("/User")]
        [AllowAnonymous]
        public ActionResult<User> CreateUser(string username, string email, string password)
        {
            if (_userService.UserExistsByUserName(username)) return Conflict("UserName already exist!");

            if (_userService.UserExistsByEMail(email)) return Conflict("EMail already exist!");

            _authenticationService.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            return _userService.CreateNewUser(username, email, passwordSalt, passwordHash);
        }

        [HttpGet("/User")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("/User/Id")]
        public ActionResult<User> GetUserById(int id)
        {
            if(!_userService.UserExistsById(id)) return NotFound();
            return _userService.GetUserById(id);
        }

        [HttpGet("/User/APIKey")]
        public ActionResult<User> GetUserByAPIKey(string APIKey)
        {
            if (!_userService.UserExistsByAPIKey(APIKey)) return NotFound();
            return _userService.GetUserByApiKey(APIKey);
        }

        [HttpGet("/User/UserName")]
        public ActionResult<User> GetUserByUserName(string userName)
        {
            if (!_userService.UserExistsByUserName(userName)) return NotFound();
            return _userService.GetUserByUsername(userName);
        }

        [HttpGet("/User/EMail")]
        public ActionResult<User> GetUserByEMail(string eMail)
        {
            if (!_userService.UserExistsByEMail(eMail)) return NotFound();
            return _userService.GetUserByEmail(eMail);
        }

        [HttpDelete("/User")]
        public ActionResult<User> DeleteUserById(int id)
        {
            if (!_userService.UserExistsById(id)) return NotFound();
            return _userService.DeleteUserById(id);
        }

        [HttpPut("/User")]
        public ActionResult<User> UpdateUserById(int idUserToUpdate, string newUserName, string newEMail, string newPassword)
        {
            if (!_userService.UserExistsById(idUserToUpdate)) return NotFound();
            _authenticationService.CreatePasswordHash(newPassword, out byte[] passwordSalt, out byte[] passwordHash);
            return _userService.UpdateUserById(idUserToUpdate, newUserName, newEMail, passwordSalt, passwordHash);
        }
    }
}