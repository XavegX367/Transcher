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

        public string Name { get; set; }

        public string Extension { get; set; }

        public int Downloads { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public int AmountOfReviews { get; set; }

        public IReadOnlyList<ReviewDTO> Reviews { get; set; }
    }
}
