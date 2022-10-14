using NUnit.Framework;
using Omnific.Controller;
using Omnific.Services;
using Moq;

namespace Omnific.Test
{
    public class Tests
    {

        [Test]
        public void Create_User_Return_APIKey()
        {
            //Arrage
            UserController userController = new UserController();
            UserService userService = new UserService();
            Mock<IUserService> MockUserInterface = new Mock<IUserService>();
            //Act

            //Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}