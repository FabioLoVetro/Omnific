using NUnit.Framework;
using System;
using Omnific.Model;
using FluentAssertions;
namespace Omnific.Test
{
    public class UserTests
    {
        private User user;

        [SetUp]

        public void SetUp()
        {
            user = new User("Pali", "pali@gmail.com", new byte[1], new byte[1]);
        }
        [Test]
        public void UserTest_Should_Return_A_User_With_The_Right_Parameters()
        {
            user.Should().NotBeNull();
            user.UserName.Should().Be("Pali");
            user.Email.Should().Be("pali@gmail.com");
            user.PasswordSalt.Should().BeEquivalentTo(new byte[1]);
            user.PasswordHash.Should().BeEquivalentTo(new byte[1]);
            user.UserType.Should().Be(UserType.Viewer);
        }

        [Test]
        public void Given_A_User_GenerateApiKey_Should_Set_ApiKey_Property()
        {
            user.GenerateApiKey();
            user.ApiKey.Should().NotBeNull();
            var APIKeyUser = user.ApiKey;
            user.ApiKey.Should().Be(APIKeyUser);
            user.ApiKey.Length.Should().Be(8);
        }
        

        [Test]
        public void IsUserAdministrator_Returns_True()
        {
            user.UserType = UserType.Administrator;
            user.IsUserAdministrator().Should().BeTrue();
        }
        [Test]
        public void IsUserAdministrator_Returns_False()
        {
            user.IsUserAdministrator().Should().BeFalse();
        }

        [Test]
        public void IsUserInventor_Returns_True()
        {
            user.UserType = UserType.Inventor;
            user.IsUserInventor().Should().BeTrue();
        }

        [Test]
        public void IsUserInventor_Returns_False()
        {
            user.IsUserInventor().Should().BeFalse();
        }

    }
}

