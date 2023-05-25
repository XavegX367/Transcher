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
            throw new NotImplementedException();
        }

        public Transcher.Classes.File Upload(Transcher.Classes.File file)
        {
            throw new NotImplementedException();
        }
    }
}
