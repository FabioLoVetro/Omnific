using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omnific.Services;
using Omnific.Model;
using Microsoft.AspNetCore.Authorization;

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
        public ActionResult<User> CreateUserController(string username, string email, string password)
        {
            return _userService.CreateNewUser(username, email, password);
        }

        [HttpGet("/User")]
        public ActionResult<IEnumerable<User>> GetAllUsersController()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("/User/Id")]
        public ActionResult<User> GetUserByIdController(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpGet("/User/APIKey")]
        public ActionResult<User> GetUserByAPIKeyController(string APIKey)
        {
            return _userService.GetUserByApiKey(APIKey);
        }

        [HttpGet("/User/UserName")]
        public ActionResult<User> GetUserByUserNameController(string userName)
        {
            return _userService.GetUserByUsername(userName);
        }

        [HttpGet("/User/EMail")]
        public ActionResult<User> GetUserByEMailController(string eMail)
        {
            return _userService.GetUserByEmail(eMail);
        }

        [HttpDelete("/User")]
        public ActionResult<User> DeleteUserByIdController(int id)
        {
            return _userService.DeleteUserById(id);
        }

        [HttpPut("/User")]
        public ActionResult<User> UpdateUserByIdController(int idUserToUpdate, string newUserName, string newEMail, string newPassword)
        {
            return _userService.UpdateUserById(idUserToUpdate, newUserName, newEMail, newPassword);
        }
    }
}