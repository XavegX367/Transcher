using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcher.Classes;
using UnitTests.Mocks;

namespace UnitTests
{
    public class FilesTests
    {
        [Fact]
        public void UploadFile_ReturnsTrue()
        {
            var fileRepositoryMock = new Mock<FileMock>();
            Transcher.Classes.File file = new();
            file.SetRepository(fileRepositoryMock.Object);

            var userRepositoryMock = new Mock<UserMock>();
            User user = new User(userRepositoryMock.Object);

            user.Id = 1;

            bool result = file.CreateFile
            (
                "Nieuw document!",
                ".pdf",
                user

            );

            Assert.True(result);
        }

        [Fact]
        public void RetrieveFiles_ReturnsList()
        {
            var fileRepositoryMock = new Mock<FileMock>();
            Transcher.Classes.File file = new();
            file.SetRepository(fileRepositoryMock.Object);

            List<Transcher.Classes.File> files = new List<Transcher.Classes.File>();
            files = file.RetrieveFiles();

            Assert.Equal(3, files.Count);
        }
    }
}
