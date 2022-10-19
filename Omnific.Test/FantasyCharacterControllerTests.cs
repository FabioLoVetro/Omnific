using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Omnific.Controller;
using Omnific.Model;
using Omnific.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnific.Test
{
    public class FantasyCharacterControllerTests
    {
        private Mock<IFantasyCharacterService> _mockFantasyCharacterService;
        private FantasyCharacterController _fantasyCharacterController;

        [SetUp]
        public void Setup()
        {
            _mockFantasyCharacterService = new Mock<IFantasyCharacterService>();
            _fantasyCharacterController = new FantasyCharacterController(_mockFantasyCharacterService.Object);
        }

        [Test]
        public void CreateFantasyCharacter_Should_Return_A_FantasyCharacter()
        {
            //Arrage
            var fantasyCharacter = new FantasyCharacter("",0, 0, "", "", "", "","","");
            _mockFantasyCharacterService.Setup(b => b.CreateNewFantasyCharacter("", 0, 0, "", "", "", "", "","")).Returns(fantasyCharacter);

            //Act
            var newFantasyCharacter = _fantasyCharacterController.CreateFantasyCharacterController("", 0, 0, "", "", "", "", "","");

            //Assert
            newFantasyCharacter.Should().BeOfType(typeof(ActionResult<FantasyCharacter>));
        }
    }
}
