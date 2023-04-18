using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class FileDTO
    {
        public int Id { get; set; }

        public string Name { get; private set; }

        public string Extension { get; set; }

        public string Downloads { get; set; }

        public IReadOnlyList<ReviewDTO> Reviews { get; set; }
    }
}
