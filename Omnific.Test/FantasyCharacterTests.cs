using NUnit.Framework;
using Omnific.Model;
using FluentAssertions;
namespace Omnific.Test
{
    public class FantasyCharacterTests
    {

        [Test]
        public void FantasyCharacter_Constructor_Test()
        {
            //Arrange/Act
            var fantasyCharacter = new FantasyCharacter("Magician",1.70,80, "Earth", "Magician", "www.omnific.com/fantasycharacter/1", "12345678", "Magic");

            //Assert
            fantasyCharacter.Should().NotBeNull();
            fantasyCharacter.Should().BeOfType<FantasyCharacter>();
            fantasyCharacter.Name.Should().Be("Magician");
            fantasyCharacter.Height.Should().Be(1.70);
            fantasyCharacter.Weight.Should().Be(80);
            fantasyCharacter.Habitat.Should().Be("Earth");
            fantasyCharacter.Description.Should().Be("Magician");
            fantasyCharacter.Picture.Should().Be("www.omnific.com/fantasycharacter/1");
            fantasyCharacter.APIKeyInventor.Should().Be("12345678");
            fantasyCharacter.Powers.Should().Be("Magic");
        }
    }
}

 