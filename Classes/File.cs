using Data.DTO;
using System.Collections.Generic;
using Transcher.Repositories;

namespace Transcher.Classes
{
    public class File
    {
        FileRepository _fileRepo = new();
        FileDTO _fileDTO = new();

        private int Id { get; set; }

        public string Name { get; private set; }

        private string Extension { get; set; }

        public int Downloads { get; private set; }

        private DateTime CreatedAt { get; set; }

        private int UserId { get; set; }

        public int AmountOfReviews { get; private set; }

        private IReadOnlyList<Review> Reviews { get; set; }

        public void SetData(int id, string name, string extension, int downloads)
        {
            Id = id;
            Name = name;
            Extension = extension;
            Downloads = downloads;

        }

        public void CreateFile(string name, string extension, User user)
        {
            Name = name;
            Extension = extension;
            Downloads = 0;
            CreatedAt = DateTime.Now;
            UserId = user.Id;
        }

        public int GetId()
        {
            return Id;
        }

        public bool UploadFile()
        {
            _fileDTO.Name = Name;
            _fileDTO.Extension = Extension;
            _fileDTO.Downloads = Downloads;
            _fileDTO.UserId = UserId;
            _fileDTO.CreatedAt = CreatedAt;

            _fileDTO = _fileRepo.Upload(_fileDTO);
            if(_fileDTO.Id != 0)
            {
                Id = _fileDTO.Id;
                return true;
            }

            return false;
        }

        public List<File> RetrieveFiles()
        {
            List<File> files = new List<File>();

            foreach (FileDTO file in _fileRepo.RetrieveFiles()) {
                File retrieved = new();
                retrieved.Id = file.Id;
                retrieved.Name = file.Name;
                retrieved.Extension = file.Extension;
                retrieved.Downloads = file.Downloads;
                retrieved.CreatedAt = file.CreatedAt;
                retrieved.UserId = file.UserId;
                retrieved.AmountOfReviews = file.AmountOfReviews;

                files.Add(retrieved);
            }

            return files;
        }
    }
}
