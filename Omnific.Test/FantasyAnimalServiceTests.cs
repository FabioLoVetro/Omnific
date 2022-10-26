using FluentAssertions;
using NUnit.Framework;
using Omnific.Model;
using Omnific.Services;
using Microsoft.EntityFrameworkCore;

namespace Omnific.Test
{
    public class FantasyAnimalServiceTests
    {
        private OmnificContext _context;
        private FantasyAnimalService _fantasyAnimalService;
        private FantasyAnimal _fantasyAnimal;
        private FantasyAnimal _fantasyAnimalUpdated;
        private List<FantasyAnimal> _animals;

        [SetUp]
        public void Setup()
        {
            _fantasyAnimal = new FantasyAnimal(
                "Dracat", 5, 200, "Air/Earth", "Dracat: Dragon + Cat", 
                "www.omnific.com/fantasyanimal/1", "12345678", "Fire", "Dragon", "Cat");
            _fantasyAnimal.Id = 1;

            _fantasyAnimalUpdated = new FantasyAnimal(
                "Eaglecat", 5, 200, "Air/Earth", "Eaglecat: Eagle + Cat", 
                "www.omnific.com/fantasyanimal/1", "12345678", "Eagle eye", "Eagle", "Cat");
            _fantasyAnimalUpdated.Id = 1;

            _animals = new List<FantasyAnimal> { _fantasyAnimal };

            //setup context
            _context = new OmnificContext(
                new DbContextOptionsBuilder<OmnificContext>()
                .UseInMemoryDatabase(databaseName: "OmnificDB").Options);

            //setup service
            _fantasyAnimalService = new FantasyAnimalService(_context);

        }

        [Test]
        public void CreateFantasyAnimal_Should_Return_A_FantasyAnimal()
        {
            //Arrage
            //Act
            var newFantasyAnimal = _fantasyAnimalService.CreateNewFantasyAnimal("Dracat", 5, 200, "Air/Earth", "Dracat: Dragon + Cat", "www.omnific.com/fantasyanimal/1", "12345678", "Fire", "Dragon", "Cat");
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(FantasyAnimal));
            newFantasyAnimal.Should().BeEquivalentTo(_fantasyAnimal);
            _context.FantasyAnimals.ToList().Count.Should().Be(1);
        }
        
        [Test]
        public void GetAllFantasyAnimal()
        {
            //Arrage
            _context.Add(_fantasyAnimal);
            _context.SaveChanges();
            //Act
            var newFantasyAnimal = _fantasyAnimalService.GetAllFantasyAnimal();
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(List<FantasyAnimal>));
            newFantasyAnimal.Should().BeEquivalentTo(_animals);
        }

        [Test]
        public void GetFantasyAnimalById_1()
        {
            //Arrage
            //Act
            var newFantasyAnimal = _fantasyAnimalService.GetFantasyAnimalById(1);
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(FantasyAnimal));
            newFantasyAnimal.Should().BeEquivalentTo(_fantasyAnimal);
        }

        [Test]
        public void GetFantasyAnimalById_2()
        {
            //Arrage
            //Act
            var newFantasyAnimal = _fantasyAnimalService.GetFantasyAnimalById(2);
            //Assert
            newFantasyAnimal.Should().BeNull();
        }

        [Test]
        public void GetFantasyAnimalByAPIKeyInventor_12345678()
        {
            //Arrage
            //Act
            var newFantasyAnimal = _fantasyAnimalService.GetFantasyAnimalByAPIKeyInventor("12345678");
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(List<FantasyAnimal>));
            newFantasyAnimal.Should().BeEquivalentTo(_animals);
        }

        [Test]
        public void GetFantasyAnimalByAPIKeyInventor_99999999()
        {
            //Arrage
            //Act
            var newFantasyAnimal = _fantasyAnimalService.GetFantasyAnimalByAPIKeyInventor("99999999");
            //Assert
            newFantasyAnimal.Should().BeNullOrEmpty();
        }

        [Test]
        public void GetFantasyAnimalByName_Dracat()
        {
            //Arrage
            //Act
            var newFantasyAnimal = _fantasyAnimalService.GetFantasyAnimalByName("Dracat");
            //Assert
            newFantasyAnimal.Should().NotBeNull();
            newFantasyAnimal.Should().BeOfType(typeof(List<FantasyAnimal>));
            newFantasyAnimal.Should().BeEquivalentTo(_animals);
        }

        [Test]
        public void GetFantasyAnimalByName_AAA()
        {
            //Arrage
            //Act
            var newFantasyAnimal = _fantasyAnimalService.GetFantasyAnimalByName("AAA");
            //Assert
            newFantasyAnimal.Should().BeNullOrEmpty();
        }

        [Test]
        public void UpdateFantasyAnimalById()
        {
            //Arrage
            //Act
            var updatedFantasyAnimal = _fantasyAnimalService.UpdateFantasyAnimalById(1, "Eaglecat", 5, 200, "Air/Earth", "Eaglecat: Eagle + Cat", "www.omnific.com/fantasyanimal/1", "12345678", "Eagle eye", "Eagle", "Cat");
            //Assert
            updatedFantasyAnimal.Should().NotBeNull();
            updatedFantasyAnimal.Should().BeOfType(typeof(FantasyAnimal));
            updatedFantasyAnimal.Should().BeEquivalentTo(_fantasyAnimalUpdated);
        }

        [Test]
        public void DeleteFantasyAnimalById()
        {
            //Arrage
            //Act
            var deletedFantasyAnimal = _fantasyAnimalService.DeleteFantasyAnimalById(1);
            //Assert
            deletedFantasyAnimal.Should().NotBeNull();
            deletedFantasyAnimal.Should().BeOfType(typeof(FantasyAnimal));
            deletedFantasyAnimal.Should().BeEquivalentTo(_fantasyAnimal);
            _context.FantasyAnimals.ToList().Should().HaveCount(0);
        }
    }
}