using Data.DTO;
using System.Data;
using Transcher.Repositories;

namespace Transcher.Classes
{
    public class User
    {
        UserRepository _userRepo = new UserRepository();
        UserDTO _userDTO = new UserDTO();

        public int Id { get; set; }

        private string Email { get; set; }

        private string Password { get; set; }

        public string Name { get; set; }

        public bool Login(string email, string password)
        {
            _userDTO.Email = email;
            _userDTO.Password = password;

            DataTable dtData = _userRepo.Login(_userDTO);
            foreach (DataRow row in dtData.Rows)
            {
                string storedHashInDatabase = row["password"].ToString();
                password = password + "$Y.N3T~J*";
                bool doesPasswordMatch = BCrypt.Net.BCrypt.Verify(password, storedHashInDatabase);

                return doesPasswordMatch;
            }

            return false;
        }

        public bool Register(string email, string password, string confirmPassword)
        {
            _userDTO.Email = email;
            if (password != confirmPassword)
            {
                return false;
            }

            password = password + "$Y.N3T~J*";
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            Password = BCrypt.Net.BCrypt.HashPassword(password, salt);

            bool check = _userRepo.Register(_userDTO);

            return check;
        }

        public void SetUser(string formEmail)
        {
            _userDTO.Email = formEmail;
            _userDTO = _userRepo.GetUserByEmail(_userDTO);
            Id = _userDTO.Id;
            Name = _userDTO.Name;
            Email = _userDTO.Email;
        }
    }
}
