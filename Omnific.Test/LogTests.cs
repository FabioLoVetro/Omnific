using NUnit.Framework;
using System;
using Omnific.Model;
using FluentAssertions;
namespace Omnific.Test
{
    public class LogTests
    {
        private Log log;
        private Log logout;
        private User user;
        DateTime dateIn,dateInO;
        DateTime dateOut,dateOutO;

        [SetUp]

        public void SetUp()
        {
            user = new User("Pali", "pali@gmail.com", "password");
            user.Id = 1;
            log = new Log(1, DateTime.Now, DateTime.Now, true);
            log.Id = 1;
            dateIn = log.DateTimeIn;
            dateOut = log.DateTimeOut;
            logout = new Log(1, new DateTime(2022, 10, 26, 16, 12, 00), new DateTime(2022, 10, 26, 17, 00, 00), false);
            logout.Id = 2;
            dateInO = logout.DateTimeIn;
            dateOutO = logout.DateTimeOut;
        }
        [Test]
        public void Log_LoggedIn_Test()
        {
            log.Should().NotBeNull();
            log.Id.Should().Be(1);
            log.IdUser.Should().Be(user.Id);
            log.DateTimeIn.Should().Be(dateIn); 
            log.DateTimeOut.Should().Be(dateOut);   
            log.IsLoggedIn.Should().BeTrue();   
        }

        [Test]
        public void Log_LoggedOut_Test()
        {
            logout.Should().NotBeNull();
            logout.Id.Should().Be(2);
            logout.IdUser.Should().Be(user.Id);
            logout.DateTimeIn.Should().Be(dateInO);
            logout.DateTimeOut.Should().Be(dateOutO);
            logout.IsLoggedIn.Should().BeFalse();
        }
    }
}

