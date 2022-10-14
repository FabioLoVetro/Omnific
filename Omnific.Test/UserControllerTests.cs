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
        public void CreateNewUser_Should_Return_A_User()
        {
            //Arrage
            _mockUserService.Setup(b => b.CreateNewUser()).Returns(new User());

            //Act
            var newUser = _userController.Create();

            //Assert.Pass();
            newUser.Should().BeOfType(typeof(ActionResult<User>));
            //newUser.Value.Should().Be("APIkey");
        }
    }
}