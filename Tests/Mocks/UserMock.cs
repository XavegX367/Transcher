using Domain.Interfaces;
using System.Data;
using BCrypt.Net;
using Transcher.Classes;

namespace UnitTests.Mocks
{
    public class UserMock : IUser
    {
        public User GetUserByEmail(User user)
        {
            user.Name = "Joris";
            return user;
        }

        public DataTable Login(User user)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("password"));
            dt.Columns.Add(new DataColumn("storedHashInDatabase"));

            string password = "Test123!";
            password = password + "$Y.N3T~J*";
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPass = BCrypt.Net.BCrypt.HashPassword(password, salt);

            DataRow row1 = dt.NewRow();
            row1["password"] = user.GetPassword();
            row1["storedHashInDatabase"] = BCrypt.Net.BCrypt.HashPassword(hashedPass, salt);
            dt.Rows.Add(row1);

            return dt;
        }

        public bool Register(User user)
        {
            return true;
        }
    }
}
