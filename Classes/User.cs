using Domain.Interfaces;
using System.Data;
using BCrypt.Net;

namespace Transcher.Classes
{
    public class User: IUser
    {
        private readonly IUser userRepository;

        public User(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public int Id { get; set; }

        private string Email { get; set; }

        private string Password { get; set; }

        public string Name { get; set; }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public string GetEmail()
        {
            return Email;
        }

        public string GetPassword()
        {
            return Password;
        }

        public bool SetupLogin(string email, string password)
        {
            Email = email;
            Password = password;

            DataTable dtData = Login(this);
            foreach (DataRow row in dtData.Rows)
            {
                string storedHashInDatabase = row["password"].ToString();
                password = password + "$Y.N3T~J*";
                bool doesPasswordMatch = BCrypt.Net.BCrypt.Verify(password, storedHashInDatabase);

                return doesPasswordMatch;
            }

            return false;
        }

        public bool SetupRegister(string email, string password, string confirmPassword)
        {
            Email = email;
            if (password != confirmPassword)
            {
                return false;
            }

            password = password + "$Y.N3T~J*";
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            Password = BCrypt.Net.BCrypt.HashPassword(password, salt);

            bool check = Register(this);

            return check;
        }

        public void SetUser()
        {
            User tempUser = new(userRepository);
            tempUser = GetUserByEmail(this);
            Id = tempUser.Id;
            Name = tempUser.Name;
            Email = tempUser.Email;
        }

        public bool Register(User user)
        {
            return userRepository.Register(user);
        }

        public User GetUserByEmail(User user)
        {
            return userRepository.GetUserByEmail(user);
        }

        public DataTable Login(User user)
        {
            return userRepository.Login(user);
        }
    }
}
