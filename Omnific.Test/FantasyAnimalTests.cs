using NUnit.Framework;
using Omnific.Model;
using FluentAssertions;
namespace Omnific.Test
{
    public class FantasyAnimalTests
    {

        [Test]
        public void FantasyAnimal_Test()
        {
            //Arrange/Act
            var fantasyAnimal = new FantasyAnimal("Dracat", 5, 200, "Air/Earth", "Dracat: Dragon + Cat", "www.omnific.com/fantasyanimal/1", "12345678", "Fire", "Dragon", "Cat");

            //Assert
            fantasyAnimal.Should().NotBeNull();
            fantasyAnimal.Should().BeOfType<FantasyAnimal>();
            fantasyAnimal.Name.Should().Be("Dracat");
            fantasyAnimal.Height.Should().Be(5);
            fantasyAnimal.Weight.Should().Be(200);
            fantasyAnimal.Habitat.Should().Be("Air/Earth");
            fantasyAnimal.Description.Should().Be("Dracat: Dragon + Cat");
            fantasyAnimal.Picture.Should().Be("www.omnific.com/fantasyanimal/1");
            fantasyAnimal.APIKeyInventor.Should().Be("12345678");
            fantasyAnimal.Powers.Should().Be("Fire");
            fantasyAnimal.AnimalBaseAlpha.Should().Be("Dragon");
            fantasyAnimal.AnimalBaseBeta.Should().Be("Cat");
        }
    }
}

 