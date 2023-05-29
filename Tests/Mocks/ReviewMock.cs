using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcher.Classes;

namespace UnitTests.Mocks
{
    public class ReviewMock : IReview
    {
        public bool PublishReview(Review review)
        {
            if(review.Header != "Test onderwerp" || review.Comment != "Super mooi bestand!" || review._Rating != 3 || review.GetUserId() != 1 || review.GetFileId() != 5)
            {
                return false;
            }

            return true;
        }
    }
}
