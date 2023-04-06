using System.Collections.Generic;
using Transcher.Repositories;

namespace Transcher.Classes
{
    public class File
    {
        FileRepository _fileRepo = new FileRepository();

        private int Id { get; set; }

        private string Name { get; set; }

        private string Extension { get; set; }

        private string SaveName { get; set; }

        private string Path { get; set; }

        private IReadOnlyList<Review> Reviews { get; set; }

        public void SetData(int id, string name, string extension, string saveName, string path)
        {
            Id = id;
            Name = name;
            Extension = extension;
            SaveName = saveName;
            Path = path;
        }

        public int GetId()
        {
            return Id;
        }

        public void UploadFile(User user, string extension, string saveName, string path)
        {
            Name = System.Guid.NewGuid() + extension;
            Extension = extension;
            SaveName = saveName;
            Path = path;

            _fileRepo.Upload(user, Name, Extension, SaveName, Path);
        }
    }
}
