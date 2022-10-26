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

        [HttpPost("/User")]
        public ActionResult<User> CreateUser(string username, string email, string password)
        {
            return _userService.CreateNewUser(username, email, password);
        }

        [HttpGet("/User")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("/User/Id")]
        public ActionResult<User> GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpGet("/User/APIKey")]
        public ActionResult<User> GetUserByAPIKey(string APIKey)
        {
            return _userService.GetUserByApiKey(APIKey);
        }

        [HttpGet("/User/UserName")]
        public ActionResult<User> GetUserByUserName(string userName)
        {
            return _userService.GetUserByUsername(userName);
        }

        [HttpGet("/User/EMail")]
        public ActionResult<User> GetUserByEMail(string eMail)
        {
            return _userService.GetUserByEmail(eMail);
        }

        [HttpDelete("/User")]
        public ActionResult<User> DeleteUserById(int id)
        {
            return _userService.DeleteUserById(id);
        }

        [HttpPut("/User")]
        public ActionResult<User> UpdateUserById(int idUserToUpdate, string newUserName, string newEMail, string newPassword)
        {
            return _userService.UpdateUserById(idUserToUpdate, newUserName, newEMail, newPassword);
        }
    }
}