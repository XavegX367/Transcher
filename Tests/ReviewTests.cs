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
    public class ReviewTests
    {
        [Fact]
        public void CreateReview_ReturnsTrue()
        {
            var reviewRepositoryMock = new Mock<ReviewMock>();
            Review review = new();
            review.SetRepository(reviewRepositoryMock.Object);

            var userRepositoryMock = new Mock<UserMock>();
            User user = new User(userRepositoryMock.Object);

            user.Id = 1;

            var fileRepositoryMock = new Mock<FileMock>();
            Transcher.Classes.File file = new Transcher.Classes.File();

            file.Id = 5;

            review.Header = "Test onderwerp";
            review.Comment = "Super mooi bestand!";
            review._Rating = 3;

            bool result = review.CreateNewReview
            (
                review,
                file,
                user
            );

            Assert.True(result);
        }

        [Fact]
        public void CreateReview_ReturnsFalse()
        {
            var reviewRepositoryMock = new Mock<ReviewMock>();
            Review review = new();
            review.SetRepository(reviewRepositoryMock.Object);

            var userRepositoryMock = new Mock<UserMock>();
            User user = new User(userRepositoryMock.Object);

            user.Id = 2;

            var fileRepositoryMock = new Mock<FileMock>();
            Transcher.Classes.File file = new Transcher.Classes.File();

            file.Id = 3;

            review.Header = "Test onderwerp";
            review.Comment = "Super mooi bestand!";
            review._Rating = 1;

            bool result = review.CreateNewReview
            (
                review,
                file,
                user
            );

            Assert.False(result);
        }
    }
}
