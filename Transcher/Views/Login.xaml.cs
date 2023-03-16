using System;
using System.Collections.Generic;
using System.Linq;
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
        UserRepository User = new UserRepository();

        public string AccountEmail { get; set; }
        // TODO: Find fix for sending password to user repository
        public string AccountPassword { get; set; }


        public Login()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (AccountEmail != null && AccountEmail != "" && AccountPassword != null && AccountPassword != "")
            {
                User.Login(AccountPassword, AccountEmail);   
            }
        }
    }
}
