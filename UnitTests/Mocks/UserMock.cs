using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcher.Classes;

namespace UnitTests.Mocks
{
    public class UserMock : IUser
    {
        public User GetUserByEmail(User user)
        {
            throw new NotImplementedException();
        }

        public DataTable Login(User user)
        {
            throw new NotImplementedException();
        }

        public bool Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
