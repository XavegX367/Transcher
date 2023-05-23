using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcher.Classes;

namespace Domain.Interfaces
{
    public interface IUser
    {
        bool Register(User user);

        User GetUserByEmail(User user);
        
        DataTable Login(User user);
    }
}
