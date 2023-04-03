using System.Windows;
using Transcher.Classes;

namespace Transcher.Views
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private User _user;
        public User user
        {
            get { return _user; }
            set { _user = value; }
        }

        public Register()
        {
            InitializeComponent();
            user = new User();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login loginWin = new Login();
            loginWin.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(inputName.Text == "" || inputEmail.Text == "" || passwordBox.Password == "")
            {
                MessageBox.Show("Vul aub alle velden in", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (passwordBox.Password != repeatPasswordBox.Password)
            {
                MessageBox.Show("De wachtwoorden komen niet overeen", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool check = user.Register(inputName.Text, inputEmail.Text, passwordBox.Password, repeatPasswordBox.Password);

            if (!check)
            {
                MessageBox.Show("Email bestaat al, probeer een andere", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Dashboard dashWin = new(inputEmail.Text);
            dashWin.Show();
            this.Close();
        }
    }
}
