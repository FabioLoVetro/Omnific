using NUnit.Framework;
using System;
using Omnific.Model;
using FluentAssertions;
namespace Omnific.Test
{
    public class FantasyCharacterTests
    {

        [Test]
        public void Given_A_User_GenerateApiKey_Should_Set_ApiKey_Property()
        {
            //Arrange
            var fantasyCharacter = new FantasyCharacter("Dracat",5,100, "Air/Earth", "Dracat: Dragon + Cat", "Dragon", "Cat","www.dragoncat.com","Fire");

            //Act
            

            //Assert
            fantasyCharacter.Should().BeOfType<FantasyCharacter>();
        }
    }
}

 