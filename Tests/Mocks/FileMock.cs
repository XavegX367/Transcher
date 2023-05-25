using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    public class FileMock : IFile
    {
        public List<Transcher.Classes.File> RetrieveFiles()
        {
            Transcher.Classes.File file1 = new Transcher.Classes.File();
            Transcher.Classes.File file2 = new Transcher.Classes.File();
            Transcher.Classes.File file3 = new Transcher.Classes.File();

            List<Transcher.Classes.File> files = new List<Transcher.Classes.File>();
            files.Add(file1);
            files.Add(file2);
            files.Add(file3);

            return files;
        }

        public bool Upload(Transcher.Classes.File file)
        {
            if (file != null)
            {
                return true;
            }

            return false;
        }
    }
}
