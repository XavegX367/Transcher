using System.Collections.Generic;
using Transcher.Repositories;

namespace Transcher.Classes
{
    public class File
    {
        FileRepository _fileRepo = new FileRepository();

        private int Id { get; set; }

        public string Name { get; private set; }

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

        public void CreateFile(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public int GetId()
        {
            return Id;
        }

        public void UploadFile(User user)
        {
            
            //Name = System.Guid.NewGuid() + extension;

            _fileRepo.Upload(user, Name, Extension, SaveName, Path);
        }
    }
}
