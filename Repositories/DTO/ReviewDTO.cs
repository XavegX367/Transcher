using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FileId { get; set; }

        public int Rating { get; set; }

        public string Header { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
