using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            bool check = UserRepo.Login(password, email);

            if (check)
            {
                return true;
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
