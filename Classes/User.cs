using System.Data;
using Transcher.Repositories;

namespace Transcher.Classes
{
    public class User
    {
        UserRepository _userRepo = new UserRepository();

        public int Id { get; set; }

        private string Email { get; set; }

        private string Password { get; set; }

        public string Name { get; set; }

        public bool Login(string email, string password)
        {
            Email = email;
            Password = password;

            DataTable dtData = _userRepo.Login(this);

            return false;
        }

        public bool Register(string email, string password, string confirmPassword)
        {
            Email = email;
            if(password != confirmPassword)
            {
                return false;
            }

            password = password + "$Y.N3T~J*";
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            Password = BCrypt.Net.BCrypt.HashPassword(password, salt);

            bool check = _userRepo.Register(this);

            return check;
        }

        public void SetUser(string formEmail)
        {
            DataTable dtData = _userRepo.GetUserByEmail(formEmail);
            foreach (DataRow row in dtData.Rows)
            {
                Id = (int)row["id"];
                Email = (string)row["email"];
                Name = (string)row["name"];
            }
        }
    }
}
