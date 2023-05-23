using Domain.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Transcher.Classes;
using Transcher.Repositories;

namespace Transcher.Views
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window, INotifyPropertyChanged
    {
        private User _user;
        public User user
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }

        public Register()
        {
            DataContext = this;
            InitializeComponent();
            IUser userInterface = new UserRepository();
            user = new User(userInterface);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login loginWin = new Login();
            loginWin.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(user.Name == "" || inputEmail.Text == "" || passwordBox.Password == "")
            {
                MessageBox.Show("Vul aub alle velden in", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (passwordBox.Password != repeatPasswordBox.Password)
            {
                MessageBox.Show("De wachtwoorden komen niet overeen", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool check = user.SetupRegister(inputEmail.Text, passwordBox.Password, repeatPasswordBox.Password);

            if (!check)
            {
                MessageBox.Show("Email bestaat al, probeer een andere", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Dashboard dashWin = new(inputEmail.Text);
            dashWin.Show();
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
