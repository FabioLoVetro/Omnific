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
        public void Create_New_User_Return_APIKey()
        {
            //Arrage
            _mockUserService.Setup(b => b.CreateNewUser()).Returns("APIcode");
            //Act
            var newUser = _userController.Create();
            //Assert.Pass();
            newUser.Should().BeOfType(typeof(ActionResult<User>));
            newUser.Value.Should().Be("APIcode");
        }
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}