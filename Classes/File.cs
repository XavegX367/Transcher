using Data.DTO;
using System.Collections.Generic;
using Transcher.Repositories;

namespace Transcher.Classes
{
    public class File
    {
        FileRepository _fileRepo = new();
        FileDTO _fileDTO = new();
        UserDTO _userDTO = new();

        private int Id { get; set; }

        public string Name { get; private set; }

        private string Extension { get; set; }

        private string Downloads { get; set; }

        private IReadOnlyList<Review> Reviews { get; set; }

        public void SetData(int id, string name, string extension, string downloads, string path)
        {
            Id = id;
            Name = name;
            Extension = extension;
            Downloads = downloads;
        }

        public void CreateFile(string name, string extension)
        {
            Name = name;
            Extension = extension;
        }

        public int GetId()
        {
            return Id;
        }

        public void UploadFile(User user)
        {
            _userDTO.Id = user.Id;

            _fileRepo.Upload(_userDTO, _fileDTO);
        }
    }
}
