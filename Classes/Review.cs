using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Transcher.Classes
{
    public class Review
    {
        private int Id { get; set; }

        private int UserId { get; set; }

        private int FileId { get; set; }

        public int _Rating { get; set; }

        private string Header{ get; set; }

        private string Comment { get; set; }

        private DateTime CreatedAt { get; set; }
    }
}
