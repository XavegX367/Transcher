using Domain.Interfaces;
using System.Windows;
using Transcher.Classes;
using Transcher.Repositories;

namespace Transcher.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private User _login;
        public User loginUser
        {
            get { return _login; }
            set { _login = value; }
        }


        public Login()
        {
            InitializeComponent();
            IUser userInterface = new UserRepository();
            loginUser = new User(userInterface);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (inputEmail.Text != null && inputEmail.Text != "" && passwordBox.Password != null && passwordBox.Password != "")
            {
                bool check = loginUser.SetupLogin(inputEmail.Text, passwordBox.Password);

                if (!check)
                {
                    MessageBox.Show("Onjuist wachtwoord", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Dashboard dashWin = new Dashboard(inputEmail.Text);
                dashWin.Show();
                this.Close();
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register registerWin = new Register();
            registerWin.Show();
            this.Close();
        }
    }
}
