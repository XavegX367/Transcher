using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Transcher.Classes;
using Transcher.Repositories;

namespace Transcher.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UserRepository UserRepo = new UserRepository();
        private User _login;
        public User loginUser
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged(); }
        }


        public Login()
        {
            InitializeComponent();
            DataContext = this;
            loginUser = new User();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (loginUser.Email != null && loginUser.Email != "" && passwordBox.Password != null && passwordBox.Password != "")
            {
                bool check = UserRepo.Login(passwordBox.Password, loginUser.Email);   

                if (check)
                {
                    Dashboard dashWin = new Dashboard(loginUser.Email);
                    dashWin.Show();
                    this.Close();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
