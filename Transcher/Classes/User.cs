using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using Transcher.Repositories;

namespace Transcher.Classes
{
    public class User: INotifyPropertyChanged
    {
        UserRepository UserRepo = new UserRepository();

        private int id { get; set; }

        private string email { get; set; }

        private string name { get; set; }

        public bool login(string email, string password)
        {
            DataTable dtData = UserRepo.Login(password, email);

            foreach (DataRow row in dtData.Rows)
            {
                string storedHashInDatabase = row["password"].ToString();
                password = password + "$Y.N3T~J*";
                bool doesPasswordMatch = BCrypt.Net.BCrypt.Verify(password, storedHashInDatabase);

                return doesPasswordMatch;
            }

            return false;
        }

        public bool register(string name, string email, string password, string confirmPassword)
        {
            if(password != confirmPassword)
            {
                return false;
            }

            password = password + "$Y.N3T~J*";
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string encrypted = BCrypt.Net.BCrypt.HashPassword(password, salt);

            bool check = UserRepo.Register(name, encrypted, email);

            return check;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
