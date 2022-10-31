using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Omnific.Model;
using Omnific.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnific.Test
{
    public class UserServiceTests
    {
        private OmnificContext _context;
        private UserService _userService;
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = new User("Fabio", "fabio@gmail.com", new byte[1], new byte[1]);
            _user.Id = 1;
            _user.ApiKey="12345678";

            //setup context
            _context = new OmnificContext(
                new DbContextOptionsBuilder<OmnificContext>()
                .UseInMemoryDatabase(databaseName: "OmnificDB").Options);

            //setup service
            _userService = new UserService(_context);
        }

        [Test]
        public void CreateNewUser_test()
        {
            //Arrage
            //Act
            var newUser = _userService.CreateNewUser("Fabio", "fabio@gmail.com", new byte[1], new byte[1]);
            //Assert
            newUser.Should().NotBeNull();
            newUser.Should().BeOfType(typeof(User));
            newUser.Id.Should().Be(1);
            newUser.UserName.Should().Be("Fabio");
            newUser.Email.Should().Be("fabio@gmail.com");
            newUser.PasswordSalt.Should().BeEquivalentTo(_user.PasswordSalt);
            newUser.PasswordHash.Should().BeEquivalentTo(_user.PasswordHash);
            newUser.UserType.Should().Be(UserType.Viewer);
            _context.Users.ToList().Count.Should().Be(1);
        }
        [Test]
        public void UpdateUserById_test()
        {
            //Arrage
            //Act
            var newUser = _userService.UpdateUserById(1,"Paz", "paz@gmail.com", new byte[1], new byte[1]);
            //Assert
            newUser.Should().NotBeNull();
            newUser.Should().BeOfType(typeof(User));
            newUser.Id.Should().Be(1);
            newUser.UserName.Should().Be("Paz");
            newUser.Email.Should().Be("paz@gmail.com");
            newUser.PasswordSalt.Should().BeEquivalentTo(_user.PasswordSalt);
            newUser.PasswordHash.Should().BeEquivalentTo(_user.PasswordHash);
            newUser.UserType.Should().Be(UserType.Viewer);
            _context.Users.ToList().Count.Should().Be(1);
        }
        [Test]
        public void GetUserById_test()
        {
            //Arrage
            //Act
            var newUser = _userService.GetUserById(1);
            //Assert
            newUser.Should().NotBeNull();
            newUser.Should().BeOfType(typeof(User));
            newUser.Id.Should().Be(1);
            newUser.UserName.Should().Be("Fabio");
            newUser.Email.Should().Be("fabio@gmail.com");
            newUser.PasswordSalt.Should().BeEquivalentTo(_user.PasswordSalt);
            newUser.PasswordHash.Should().BeEquivalentTo(_user.PasswordHash);
            newUser.UserType.Should().Be(UserType.Viewer);
            _context.Users.ToList().Count.Should().Be(1);
        }
        [Test]
        public void GetUserByApiKey_test()
        {
            /*
            //Arrage
            //Act
            var newUser = _userService.GetUserByApiKey(_user.ApiKey);
            //Assert
            newUser.Should().NotBeNull();
            newUser.Should().BeOfType(typeof(User));
            newUser.Id.Should().Be(1);
            newUser.UserName.Should().Be("Fabio");
            newUser.Email.Should().Be("fabio@gmail.com");
            newUser.PasswordSalt.Should().BeEquivalentTo(_user.PasswordSalt);
            newUser.PasswordHash.Should().BeEquivalentTo(_user.PasswordHash);
            newUser.UserType.Should().Be(UserType.Viewer);
            _context.Users.ToList().Count.Should().Be(1);
            */
        }
        [Test]
        public void GetUserByUsername_test()
        {
            //Arrage
            //Act
            //Assert
        }
        [Test]
        public void GetUserByEmail_test()
        {
            //Arrage
            //Act
            //Assert
        }
        [Test]
        public void GetAllUsers_test()
        {
            //Arrage
            //Act
            //Assert
        }
        [Test]
        public void DeleteUserById_test()
        {
            //Arrage
            //Act
            //Assert
        }
        [Test]
        public void UserExistsById_test()
        {
            //Arrage
            //Act
            //Assert
        }
        [Test]
        public void UserExistsByUserName_test()
        {
            //Arrage
            //Act
            //Assert
        }
        [Test]
        public void UserExistsByEMail_test()
        {
            //Arrage
            //Act
            //Assert
        }
        [Test]
        public void UserExistsByAPIKey_test()
        {
            //Arrage
            //Act
            //Assert
        }
    }
}