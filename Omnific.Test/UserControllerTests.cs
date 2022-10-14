using NUnit.Framework;
using Omnific.Model;
using Omnific.Controller;
using Omnific.Services;
using FluentAssertions;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Omnific.Test
{
    public class UserControllerTests
    {
        private Mock<IUserService> _mockUserService;
        private UserController _userController;

        [SetUp]
        public void Setup()
        {
            _mockUserService = new Mock<IUserService>();
            _userController = new UserController(_mockUserService.Object);
        }

        [Test]
        public void CreateUser_Should_Return_A_User()
        {
            //Arrage
            _mockUserService.Setup(b => b.CreateNewUser()).Returns(new User());

            //Act
            var newUser = _userController.CreateUser("Paz", "pazsonagara@gmail.com", "pazzy");

            //Assert
            newUser.Should().BeOfType(typeof(ActionResult<User>));
        }

        [Test]
        public void CreateUser_Should_Return_A_User_With_API_Key()
        {
            //Arrange
            User user = new User();
            user.UserName = "Paz";
            user.Email = "pazsoangara@gmail.com";
            user.Password = "pazzy";
            user.ApiKey = "someAPIKey";

            _mockUserService.Setup(us => us.CreateNewUser()).Returns(user);

            //Act
            var newuser = _userController.CreateUser("Paz", "pazsonagara@gmail.com", "pazzy");

            //Assert
            newuser.Value.ApiKey.Should().Be("someAPIKey");


        }
    }
}