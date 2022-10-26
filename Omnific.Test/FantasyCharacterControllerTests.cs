using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Omnific.Controller;
using Omnific.Model;
using Omnific.Services;

namespace Omnific.Test
{
    public class FantasyCharacterControllerTests
    {
        private Mock<IFantasyCharacterService> _mockFantasyCharacterService;
        private FantasyCharacterController _fantasyCharacterController;
        private FantasyCharacter _fantasyCharacter;
        private List<FantasyCharacter> _Characters;

        [SetUp]
        public void Setup()
        {
            _mockFantasyCharacterService = new Mock<IFantasyCharacterService>();
            _fantasyCharacterController = new FantasyCharacterController(_mockFantasyCharacterService.Object);
            _fantasyCharacter = new FantasyCharacter("Magician", 1.70, 80, "Earth", "Magician", "www.omnific.com/fantasycharacter/1", "12345678", "Magic");
            _Characters = new List<FantasyCharacter> { _fantasyCharacter };
        }

        [Test]
        public void CreateFantasyCharacter_Should_Return_A_FantasyCharacter()
        {
            //Arrage
            _mockFantasyCharacterService.Setup(b => b.CreateNewFantasyCharacter("", 0, 0, "", "", "", "","")).Returns(_fantasyCharacter);
            //Act
            var newFantasyCharacter = _fantasyCharacterController.CreateFantasyCharacter("", 0, 0, "", "", "", "","");
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(ActionResult<FantasyCharacter>));
            newFantasyCharacter.Value.Should().BeEquivalentTo(_fantasyCharacter);
        }
        [Test]
        public void GetAllFantasyCharacter()
        {
            //Arrage
            _mockFantasyCharacterService.Setup(b => b.GetAllFantasyCharacter()).Returns(_Characters);
            //Act
            var newFantasyCharacter = _fantasyCharacterController.GetAllFantasyCharacter();
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(ActionResult<IEnumerable<FantasyCharacter>>));
            newFantasyCharacter.Value.Should().BeEquivalentTo(_Characters);
        }
        [Test]
        public void GetFantasyCharacterById()
        {
            //Arrage
            _mockFantasyCharacterService.Setup(b => b.GetFantasyCharacterById(1)).Returns(_fantasyCharacter);
            //Act
            var newFantasyCharacter = _fantasyCharacterController.GetFantasyCharacterById(1);
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(ActionResult<FantasyCharacter>));
            newFantasyCharacter.Value.Should().BeEquivalentTo(_fantasyCharacter);
        }
        [Test]
        public void GetFantasyCharacterByAPIKeyInventor()
        {
            //Arrage
            _mockFantasyCharacterService.Setup(b => b.GetFantasyCharacterByAPIKeyInventor("")).Returns(_Characters);
            //Act
            var newFantasyCharacter = _fantasyCharacterController.GetFantasyCharacterByAPIKeyInventor("");
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(ActionResult<IEnumerable<FantasyCharacter>>));
            newFantasyCharacter.Value.Should().BeEquivalentTo(_Characters);
        }
        [Test]
        public void GetFantasyCharacterByName()
        {
            //Arrage
            _mockFantasyCharacterService.Setup(b => b.GetFantasyCharacterByName("")).Returns(_Characters);
            //Act
            var newFantasyCharacter = _fantasyCharacterController.GetFantasyCharacterByName("");
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(ActionResult<IEnumerable<FantasyCharacter>>));
            newFantasyCharacter.Value.Should().BeEquivalentTo(_Characters);
        }
        [Test]
        public void UpdateFantasyCharacterById()
        {
            //Arrage
            _mockFantasyCharacterService.Setup(b => b.UpdateFantasyCharacterById(1, "", 0, 0, "", "", "", "","")).Returns(_fantasyCharacter);
            //Act
            var updatedFantasyCharacter = _fantasyCharacterController.UpdateFantasyCharacterById(1, "", 0, 0, "", "", "", "","");
            //Assert
            updatedFantasyCharacter.Should().NotBeNull();
            updatedFantasyCharacter.Should().BeOfType(typeof(ActionResult<FantasyCharacter>));
            updatedFantasyCharacter.Value.Should().BeEquivalentTo(_fantasyCharacter);
        }
        [Test]
        public void DeleteFantasyCharacterById()
        {
            //Arrage
            _mockFantasyCharacterService.Setup(b => b.DeleteFantasyCharacterById(1)).Returns(_fantasyCharacter);
            //Act
            var deletedFantasyCharacter = _fantasyCharacterController.DeleteFantasyCharacterById(1);
            //Assert
            deletedFantasyCharacter.Should().NotBeNull();
            deletedFantasyCharacter.Should().BeOfType(typeof(ActionResult<FantasyCharacter>));
            deletedFantasyCharacter.Value.Should().BeEquivalentTo(_fantasyCharacter);
        }
    }
}