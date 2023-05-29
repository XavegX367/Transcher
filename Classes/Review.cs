using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Transcher.Classes
{
    public class Review: IReview
    {
        private IReview reviewRepository;

        public int Id { get; set; }

        private int UserId { get; set; }

        private int FileId { get; set; }

        public int _Rating { get; set; }

        public string Header{ get; set; }

        public string Comment { get; set; }

        private DateTime CreatedAt { get; set; }

        public void SetRepository(IReview reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public DateTime GetCreationDate()
        {
            return CreatedAt;
        }

        public int GetUserId()
        {
            return UserId;
        }

        public int GetFileId()
        {
            return FileId;
        }

        public bool CreateNewReview(Review review, Transcher.Classes.File file, User user)
        {
            CreatedAt = DateTime.Now;
            review.UserId = user.Id;
            review.FileId = file.Id;
            review._Rating = _Rating;
            review.Header = Header;
            review.Comment = Comment;
            review.CreatedAt = CreatedAt;

            return PublishReview(review);
        }

        public bool PublishReview(Review review)
        {
            bool result = reviewRepository.PublishReview(review);

            if (!result)
            {
                return false;
            }

            return true;
        }
    }
}
