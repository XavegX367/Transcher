using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcher.Classes;

namespace Domain.Interfaces
{
    public class FileReviewComparer : IComparer<Transcher.Classes.File>
    {
        public int Compare(Transcher.Classes.File? x, Transcher.Classes.File? y)
        {
            if (x == null && y == null || x == y)
            {
                return 0;
            }

            int total = 0;

            foreach (var item in x.Reviews)
            {
                total += item._Rating;
            }

            int resultx = total / x.Reviews.Count;

            total = 0;

            foreach (var item in y.Reviews)
            {
                total += item._Rating;
            }

            int resulty = total / y.Reviews.Count;


            if (resultx < resulty)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
