using NUnit.Framework;
using System;
using Omnific.Model;
using FluentAssertions;
namespace Omnific.Test
{
    public class UserTests
    {

        [Test]
        public void Given_A_User_GenerateApiKey_Should_Set_ApiKey_Property()
        {
            //Arrange
            var user1 = new User("Pali", "pali@gmail.com", "password");

            //Act
            user1.GenerateApiKey();

            //Assert
            user1.ApiKey.Should().NotBeNull();
        }
    }
}

 