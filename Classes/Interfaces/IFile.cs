using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcher.Classes;

namespace Domain.Interfaces
{
    public interface IFile
    {
        Transcher.Classes.File Upload(Transcher.Classes.File file);

        List<Transcher.Classes.File> RetrieveFiles();
    }
}
