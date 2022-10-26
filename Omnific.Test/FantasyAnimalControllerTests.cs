using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Omnific.Controller;
using Omnific.Model;
using Omnific.Services;

namespace Omnific.Test
{
    public class FantasyAnimalControllerTests
    {
        private Mock<IFantasyAnimalService> _mockFantasyAnimalService;
        private FantasyAnimalController _fantasyAnimalController;
        private FantasyAnimal _fantasyAnimal;
        private List<FantasyAnimal> _animals;

        [SetUp]
        public void Setup()
        {
            _mockFantasyAnimalService = new Mock<IFantasyAnimalService>();
            _fantasyAnimalController = new FantasyAnimalController(_mockFantasyAnimalService.Object);
            _fantasyAnimal = new FantasyAnimal("Dracat", 5, 200, "Air/Earth", "Dracat: Dragon + Cat", "www.omnific.com/fantasyanimal/1", "12345678", "Fire", "Dragon", "Cat");
            _animals = new List<FantasyAnimal> { _fantasyAnimal };
        }

        [Test]
        public void CreateFantasyAnimal_Should_Return_A_FantasyAnimal()
        {
            //Arrage
            _mockFantasyAnimalService.Setup(b => b.CreateNewFantasyAnimal("", 0, 0, "", "", "", "", "", "", "")).Returns(_fantasyAnimal);
            //Act
            var newFantasyAnimal = _fantasyAnimalController.CreateFantasyAnimal("", 0, 0, "", "", "", "", "", "", "");
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(ActionResult<FantasyAnimal>));
            newFantasyAnimal.Value.Should().BeEquivalentTo(_fantasyAnimal);
        }
        [Test]
        public void GetAllFantasyAnimal()
        {
            //Arrage
            _mockFantasyAnimalService.Setup(b => b.GetAllFantasyAnimal()).Returns(_animals);
            //Act
            var newFantasyAnimal = _fantasyAnimalController.GetAllFantasyAnimal();
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(ActionResult<IEnumerable<FantasyAnimal>>));
            newFantasyAnimal.Value.Should().BeEquivalentTo(_animals);
        }
        [Test]
        public void GetFantasyAnimalById()
        {
            //Arrage
            _mockFantasyAnimalService.Setup(b => b.GetFantasyAnimalById(1)).Returns(_fantasyAnimal);
            //Act
            var newFantasyAnimal = _fantasyAnimalController.GetFantasyAnimalById(1);
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(ActionResult<FantasyAnimal>));
            newFantasyAnimal.Value.Should().BeEquivalentTo(_fantasyAnimal);
        }
        [Test]
        public void GetFantasyAnimalByAPIKeyInventor()
        {
            //Arrage
            _mockFantasyAnimalService.Setup(b => b.GetFantasyAnimalByAPIKeyInventor("")).Returns(_animals);
            //Act
            var newFantasyAnimal = _fantasyAnimalController.GetFantasyAnimalByAPIKeyInventor("");
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(ActionResult<IEnumerable<FantasyAnimal>>));
            newFantasyAnimal.Value.Should().BeEquivalentTo(_animals);
        }
        [Test]
        public void GetFantasyAnimalByName()
        {
            //Arrage
            _mockFantasyAnimalService.Setup(b => b.GetFantasyAnimalByName("")).Returns(_animals);
            //Act
            var newFantasyAnimal = _fantasyAnimalController.GetFantasyAnimalByName("");
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(ActionResult<IEnumerable<FantasyAnimal>>));
            newFantasyAnimal.Value.Should().BeEquivalentTo(_animals);
        }
        [Test]
        public void UpdateFantasyAnimalById()
        {
            //Arrage
            _mockFantasyAnimalService.Setup(b => b.UpdateFantasyAnimalById(1, "", 0, 0, "", "", "", "", "", "", "")).Returns(_fantasyAnimal);
            //Act
            var updatedFantasyAnimal = _fantasyAnimalController.UpdateFantasyAnimalById(1, "", 0, 0, "", "", "", "", "", "", "");
            //Assert
            updatedFantasyAnimal.Should().NotBeNull();
            updatedFantasyAnimal.Should().BeOfType(typeof(ActionResult<FantasyAnimal>));
            updatedFantasyAnimal.Value.Should().BeEquivalentTo(_fantasyAnimal);
        }
        [Test]
        public void DeleteFantasyAnimalById()
        {
            //Arrage
            _mockFantasyAnimalService.Setup(b => b.DeleteFantasyAnimalById(1)).Returns(_fantasyAnimal);
            //Act
            var deletedFantasyAnimal = _fantasyAnimalController.DeleteFantasyAnimalById(1);
            //Assert
            deletedFantasyAnimal.Should().NotBeNull();
            deletedFantasyAnimal.Should().BeOfType(typeof(ActionResult<FantasyAnimal>));
            deletedFantasyAnimal.Value.Should().BeEquivalentTo(_fantasyAnimal);
        }
    }
}