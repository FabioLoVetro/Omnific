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

        [HttpGet("/Id")]
        public ActionResult<User> GetUserByIdController(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpGet("/APIKey")]
        public ActionResult<User> GetUserByAPIKeyController(string APIKey)
        {
            return _userService.GetUserByApiKey(APIKey);
        }

        [HttpGet("/UserName")]
        public ActionResult<User> GetUserByUserNameController(string userName)
        {
            return _userService.GetUserByUsername(userName);
        }

        [HttpGet("/EMail")]
        public ActionResult<User> GetUserByEMailController(string eMail)
        {
            return _userService.GetUserByEmail(eMail);
        }

        [HttpDelete]
        public ActionResult<User> DeleteUserByIdController(int id)
        {
            return _userService.DeleteUserById(id);
        }

        [HttpPut]
        public ActionResult<User> UpdateUserByIdController(int idUserToUpdate, string newUserName, string newEMail, string newPassword)
        {
            return _userService.UpdateUserById(idUserToUpdate, newUserName, newEMail, newPassword);
        }
    }
}