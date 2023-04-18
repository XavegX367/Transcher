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

            //Name = System.Guid.NewGuid() + extension;

            //Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(tbFilePath.Text, destinationPath);

            _fileRepo.Upload(user, this);
        }
    }
}
