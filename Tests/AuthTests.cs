using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Transcher.Classes;
using UnitTests.Mocks;
using Xunit;

namespace UnitTests
{
    public class AuthTests
    {

        [Fact]
        public void RegisterUser_ReturnsTrue()
        {
            var userRepositoryMock = new Mock<UserMock>();
            User user = new User(userRepositoryMock.Object);

            bool result = user.SetupRegister
            (
                "test123@gmail.com",
                "Test123!",
                "Test123!"
            );

            Assert.True(result);
        }
    }
}
