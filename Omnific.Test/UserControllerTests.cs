using NUnit.Framework;
using Omnific.Model;
using Omnific.Controller;
using Omnific.Services;
using FluentAssertions;
using Moq;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

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
            User user = new User("Paz", "pazsoangara@gmail.com", "pazzy");
            _mockUserService.Setup(b => b.CreateNewUser("","","")).Returns(user);

            //Act
            var newUser = _userController.CreateUserController("", "", "");

            //Assert
            newUser.Should().BeOfType(typeof(ActionResult<User>));
        }

        [Test]
        public void CreateUser_Should_Return_A_User_With_API_Key()
        {
            //Arrange
            User user = new User("Paz", "pazsoangara@gmail.com", "pazzy");
            _mockUserService.Setup(userService => userService.CreateNewUser("", "", "")).Returns(user);

            //Act
            var newuser = _userController.CreateUserController("", "", "");

            //Assert
            newuser.Value.Id.Should().Be(user.Id);
            newuser.Value.ApiKey.Should().Be(user.ApiKey);
            newuser.Value.UserName.Should().Be("Paz");
            newuser.Value.Email.Should().Be("pazsoangara@gmail.com");
            newuser.Value.Password.Should().Be("pazzy");

        }

        [Test]
        public void GetUsers_Returns_AllUsers()
        {
            //Arange
            _mockUserService.Setup(b => b.GetAllUsers()).Returns(GetTestUsers());

            //Act
            var result = _userController.GetAllUsersController();

            //Assert
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<User>>));
            result.Value.ElementAt(0).UserName.Should().BeEquivalentTo(GetTestUsers().ElementAt(0).UserName);
            result.Value.ElementAt(0).Email.Should().BeEquivalentTo(GetTestUsers().ElementAt(0).Email);
            result.Value.ElementAt(0).Password.Should().BeEquivalentTo(GetTestUsers().ElementAt(0).Password);
            result.Value.ElementAt(1).UserName.Should().BeEquivalentTo(GetTestUsers().ElementAt(1).UserName);
            result.Value.ElementAt(1).Email.Should().BeEquivalentTo(GetTestUsers().ElementAt(1).Email);
            result.Value.ElementAt(1).Password.Should().BeEquivalentTo(GetTestUsers().ElementAt(1).Password);
            result.Value.ElementAt(2).UserName.Should().BeEquivalentTo(GetTestUsers().ElementAt(2).UserName);
            result.Value.ElementAt(2).Email.Should().BeEquivalentTo(GetTestUsers().ElementAt(2).Email);
            result.Value.ElementAt(2).Password.Should().BeEquivalentTo(GetTestUsers().ElementAt(2).Password);
            result.Value.Count().Should().Be(3);
        }

        private static List<User> GetTestUsers()
        {
            return new List<User>
            {
                new User("User1","User1@gmail.com","PWUser1"),
                new User("User2","User2@gmail.com","PWUser2"),
                new User("User3","User3@gmail.com","PWUser3"),
            };
        }
    }
}