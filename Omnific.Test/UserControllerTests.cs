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
        private User user;

        [SetUp]
        public void Setup()
        {
            _mockUserService = new Mock<IUserService>();
            _userController = new UserController(_mockUserService.Object);
            user = new User("Paz", "pazsoangara@gmail.com", "pazzy");
            user.Id = 1;
            user.GenerateApiKey();
        }

        [Test]
        public void CreateUser_Should_Return_A_User()
        {
            //Arrage

            _mockUserService.Setup(b => b.CreateNewUser("", "", "")).Returns(user);

            //Act
            var newUser = _userController.CreateUserController("", "", "");

            //Assert
            newUser.Should().BeOfType(typeof(ActionResult<User>));

            newUser.Value.Id.Should().Be(user.Id);
            newUser.Value.UserName.Should().Be("Paz");
            newUser.Value.Email.Should().Be("pazsoangara@gmail.com");
            newUser.Value.Password.Should().Be("pazzy");
        }



        [Test]
        public void CreateUser_Should_Return_A_User_With_API_Key()
        {
            //Arrange          
            _mockUserService.Setup(userService => userService.CreateNewUser("", "", "")).Returns(user);
            //Act
            var newUser = _userController.CreateUserController("", "", "");
            //Assert
            
            newUser.Value.ApiKey.Should().Be(user.ApiKey);
            newUser.Value.ApiKey.Should().NotBeNull();

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

        [Test]

        public void GetUserByIdController_Test()
        {
            _mockUserService.Setup(b => b.GetUserById(1)).Returns(user);
            user.Id.Should().Be(1);
            _mockUserService.Setup(b => b.GetUserById(1)).Returns(GetTestUsers().ElementAt(0));
            GetTestUsers().ElementAt(0).Id.Should().Be(1);
            _mockUserService.Setup(b => b.GetUserById(2)).Returns(GetTestUsers().ElementAt(1));
            GetTestUsers().ElementAt(1).Id.Should().Be(2);
            _mockUserService.Setup(b => b.GetUserById(3)).Returns(GetTestUsers().ElementAt(2));
            GetTestUsers().ElementAt(2).Id.Should().Be(3);               
        }

        [Test]
        public void GetUserByAPIKeyController_Test()
        {           
            _mockUserService.Setup(b => b.GetUserByApiKey("")).Returns(user);
            var ApiKeyUser = user.ApiKey;
            user.ApiKey.Should().Be(ApiKeyUser);

            _mockUserService.Setup(b => b.GetUserByApiKey("")).Returns(GetTestUsers().ElementAt(0));
            GetTestUsers().ElementAt(0).GenerateApiKey();
            ApiKeyUser = GetTestUsers().ElementAt(0).ApiKey;
            GetTestUsers().ElementAt(0).ApiKey.Should().Be(ApiKeyUser);

            _mockUserService.Setup(b => b.GetUserByApiKey("")).Returns(GetTestUsers().ElementAt(1));
            GetTestUsers().ElementAt(1).GenerateApiKey();
            ApiKeyUser = GetTestUsers().ElementAt(1).ApiKey;
            GetTestUsers().ElementAt(1).ApiKey.Should().Be(ApiKeyUser);

            _mockUserService.Setup(b => b.GetUserByApiKey("")).Returns(GetTestUsers().ElementAt(2));
            GetTestUsers().ElementAt(2).GenerateApiKey();
            ApiKeyUser = GetTestUsers().ElementAt(2).ApiKey;
            GetTestUsers().ElementAt(2).ApiKey.Should().Be(ApiKeyUser);

        }

        [Test]
        public void GetUserByNameController_Test()
        {
            _mockUserService.Setup(b => b.GetUserByUsername("")).Returns(user);
            var UserName = user.UserName;
            user.UserName.Should().Be(UserName);

            _mockUserService.Setup(b => b.GetUserByUsername("")).Returns(GetTestUsers().ElementAt(0));
            //GetTestUsers().ElementAt(0).GenerateApiKey();
            UserName = GetTestUsers().ElementAt(0).UserName;
            GetTestUsers().ElementAt(0).UserName.Should().Be(UserName);

            _mockUserService.Setup(b => b.GetUserByUsername("")).Returns(GetTestUsers().ElementAt(1));
            //GetTestUsers().ElementAt(1).GenerateApiKey();
            UserName = GetTestUsers().ElementAt(1).UserName;
            GetTestUsers().ElementAt(1).UserName.Should().Be(UserName);

            _mockUserService.Setup(b => b.GetUserByUsername("")).Returns(GetTestUsers().ElementAt(2));
            //GetTestUsers().ElementAt(2).GenerateApiKey();
            UserName = GetTestUsers().ElementAt(2).UserName;
            GetTestUsers().ElementAt(2).UserName.Should().Be(UserName);

        }
        [Test]
        public void GetUserByEmailController_Test()
        {
            _mockUserService.Setup(b => b.GetUserByEmail("")).Returns(user);
            var UserEmail = user.Email;
            user.Email.Should().Be(UserEmail);

            _mockUserService.Setup(b => b.GetUserByEmail("")).Returns(GetTestUsers().ElementAt(0));
           // GetTestUsers().ElementAt(0).GenerateApiKey();
            UserEmail = GetTestUsers().ElementAt(0).Email;
            GetTestUsers().ElementAt(0).Email.Should().Be(UserEmail);

            _mockUserService.Setup(b => b.GetUserByEmail("")).Returns(GetTestUsers().ElementAt(1));
           // GetTestUsers().ElementAt(1).GenerateApiKey();
            UserEmail = GetTestUsers().ElementAt(1).Email;
            GetTestUsers().ElementAt(1).Email.Should().Be(UserEmail);

            _mockUserService.Setup(b => b.GetUserByEmail("")).Returns(GetTestUsers().ElementAt(2));
           // GetTestUsers().ElementAt(2).GenerateApiKey();
            UserEmail = GetTestUsers().ElementAt(2).Email;
            GetTestUsers().ElementAt(2).Email.Should().Be(UserEmail);

        }
        [Test]
        public void DeleteUserById_Test()
        {
            _mockUserService.Setup(b => b.DeleteUserById(1)).Returns(user);
            user.Should().NotBeNull();  
        }

        [Test]
        public void UpdateUserById_Test()
        {
            _mockUserService.Setup(b => b.UpdateUserById(1,"","","")).Returns(user);
            user.Should().NotBeNull();
        }

        private static List<User> GetTestUsers()
        {
            var UserList= new List<User>
            {
                new User("User1","User1@gmail.com","PWUser1"),
                new User("User2","User2@gmail.com","PWUser2"),
                new User("User3","User3@gmail.com","PWUser3"),
            };
            UserList.ElementAt(0).Id=1;
            UserList.ElementAt(1).Id = 2;
            UserList.ElementAt(2).Id = 3;

           

            return UserList;
        }
    }
}