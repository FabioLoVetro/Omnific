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
            //Arrange/Act
            var fantasyCharacter = new FantasyCharacter("Dracat",5,100, "Air", "Dracat: Dragon + Cat", "www.dragoncat.com", "12345678", "Fire");

            //Assert
            fantasyCharacter.Should().BeOfType<FantasyCharacter>();
            fantasyCharacter.Name.Should().Be("Dracat");
        }
    }
}

 