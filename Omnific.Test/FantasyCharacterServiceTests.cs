using FluentAssertions;
using NUnit.Framework;
using Omnific.Model;
using Omnific.Services;
using Microsoft.EntityFrameworkCore;

namespace Omnific.Test
{
    public class FantasyCharacterServiceTests
    {
        private OmnificContext _context;
        private FantasyCharacterService _fantasyCharacterService;
        private FantasyCharacter _fantasyCharacter;
        private FantasyCharacter _fantasyCharacterUpdated;
        private List<FantasyCharacter> _Characters;

        [SetUp]
        public void Setup()
        {
            _fantasyCharacter = new FantasyCharacter(
                "Magician", 1.70, 80, "Earth", "Magician", "www.omnific.com/fantasyCharacter/1", "12345678", "Spells");
            _fantasyCharacter.Id = 1;

            _fantasyCharacterUpdated = new FantasyCharacter(
                "Witch", 1.60, 60, "Air/Earth", "Witch", "www.omnific.com/fantasyCharacter/1", "12345678", "Potion");
            _fantasyCharacterUpdated.Id = 1;

            _Characters = new List<FantasyCharacter> { _fantasyCharacter };

            //setup context
            _context = new OmnificContext(
                new DbContextOptionsBuilder<OmnificContext>()
                .UseInMemoryDatabase(databaseName: "OmnificDB").Options);

            //setup service
            _fantasyCharacterService = new FantasyCharacterService(_context);

        }

        [Test]
        public void CreateFantasyCharacter_Should_Return_A_FantasyCharacter()
        {
            //Arrage
            //Act
            var newFantasyCharacter = _fantasyCharacterService.CreateNewFantasyCharacter("Magician", 1.70, 80, "Earth", "Magician", "www.omnific.com/fantasyCharacter/1", "12345678", "Spells");
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(FantasyCharacter));
            newFantasyCharacter.Should().BeEquivalentTo(_fantasyCharacter);
            _context.FantasyCharacters.ToList().Count.Should().Be(1);
        }

        [Test]
        public void GetAllFantasyCharacter()
        {
            //Arrage
            _context.Add(_fantasyCharacter);
            _context.SaveChanges();
            //Act
            var newFantasyCharacter = _fantasyCharacterService.GetAllFantasyCharacter();
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(List<FantasyCharacter>));
            newFantasyCharacter.Should().BeEquivalentTo(_Characters);
        }

        [Test]
        public void GetFantasyCharacterById_1()
        {
            //Arrage
            //Act
            var newFantasyCharacter = _fantasyCharacterService.GetFantasyCharacterById(1);
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(FantasyCharacter));
            newFantasyCharacter.Should().BeEquivalentTo(_fantasyCharacter);
        }

        [Test]
        public void GetFantasyCharacterById_2()
        {
            //Arrage
            //Act
            var newFantasyCharacter = _fantasyCharacterService.GetFantasyCharacterById(2);
            //Assert
            newFantasyCharacter.Should().BeNull();
        }

        [Test]
        public void GetFantasyCharacterByAPIKeyInventor_12345678()
        {
            //Arrage
            //Act
            var newFantasyCharacter = _fantasyCharacterService.GetFantasyCharacterByAPIKeyInventor("12345678");
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(List<FantasyCharacter>));
            newFantasyCharacter.Should().BeEquivalentTo(_Characters);
        }

        [Test]
        public void GetFantasyCharacterByAPIKeyInventor_99999999()
        {
            //Arrage
            //Act
            var newFantasyCharacter = _fantasyCharacterService.GetFantasyCharacterByAPIKeyInventor("99999999");
            //Assert
            newFantasyCharacter.Should().BeNullOrEmpty();
        }

        [Test]
        public void GetFantasyCharacterByName_Dracat()
        {
            //Arrage
            //Act
            var newFantasyCharacter = _fantasyCharacterService.GetFantasyCharacterByName("Magician");
            //Assert
            newFantasyCharacter.Should().NotBeNull();
            newFantasyCharacter.Should().BeOfType(typeof(List<FantasyCharacter>));
            newFantasyCharacter.Should().BeEquivalentTo(_Characters);
        }

        [Test]
        public void GetFantasyCharacterByName_AAA()
        {
            //Arrage
            //Act
            var newFantasyCharacter = _fantasyCharacterService.GetFantasyCharacterByName("AAA");
            //Assert
            newFantasyCharacter.Should().BeNullOrEmpty();
        }

        [Test]
        public void UpdateFantasyCharacterById()
        {
            //Arrage
            _context.FantasyCharacters.ToList().Count.Should().Be(1);
            _context.FantasyCharacters.ToList()[0].Should().BeEquivalentTo(_fantasyCharacter);
            //Act
            var updatedFantasyCharacter = _fantasyCharacterService.UpdateFantasyCharacterById(1, "Witch", 1.60, 60, "Air/Earth", "Witch", "www.omnific.com/fantasyCharacter/1", "12345678", "Potion");
            //Assert
            updatedFantasyCharacter.Should().NotBeNull();
            updatedFantasyCharacter.Should().BeOfType(typeof(FantasyCharacter));
            updatedFantasyCharacter.Should().BeEquivalentTo(_fantasyCharacterUpdated);
        }
        
        [Test]
        public void DeleteFantasyCharacterById()
        {
            //Arrage
            //Act
            var deletedFantasyCharacter = _fantasyCharacterService.DeleteFantasyCharacterById(1);
            //Assert
            deletedFantasyCharacter.Should().NotBeNull();
            deletedFantasyCharacter.Should().BeOfType(typeof(FantasyCharacter));
            deletedFantasyCharacter.Should().BeEquivalentTo(_fantasyCharacter);
            _context.FantasyCharacters.ToList().Should().HaveCount(0);
        }
    }
}