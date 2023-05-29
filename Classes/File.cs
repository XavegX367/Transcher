using Domain.Interfaces;
using System.Collections.Generic;

namespace Transcher.Classes
{
    public class File: IFile
    {
        private IFile? fileRepository;

        public int Id { get; set; }

        public string Name { get; private set; }

        public string Extension { get; set; }

        public int Downloads { get; private set; }

        private DateTime CreatedAt { get; set; }

        private int UserId { get; set; }

        public int AmountOfReviews { get; private set; }

        private List<Review> _reviews;
        public IReadOnlyList<Review> Reviews
        {
            get { return _reviews.AsReadOnly(); }
        }

        public DateTime GetCreationDate()
        {
            return CreatedAt;
        }

        public int GetUserId()
        {
            return UserId;
        }

        public void SetRepository(IFile fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public void SetData(int id, string name, string extension, int downloads, DateTime createdAt, int userId, int amountOfReviews)
        {
            Id = id;
            Name = name;
            Extension = extension;
            Downloads = downloads;
            CreatedAt = createdAt;
            UserId = userId;
            AmountOfReviews = amountOfReviews;
        }

        public bool CreateFile(string name, string extension, User user)
        {
            Name = name;
            Extension = extension;
            Downloads = 0;
            CreatedAt = DateTime.Now;
            UserId = user.Id;

            bool result = Upload(this);

            return result;
        }

        public bool Upload(File file)
        {
            bool result = fileRepository.Upload(file);

            return result;
        }

        public List<File> RetrieveFiles()
        {
            return fileRepository.RetrieveFiles();
        }

        public void GetReviews()
        {
        }

        public void AppendReview(Review review)
        {
            Reviews.Append(review);
        }
    }
}
