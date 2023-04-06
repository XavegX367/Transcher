using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Transcher.Classes;

namespace Transcher.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window, INotifyPropertyChanged
    {
        private User _user;
        public User loggedUser
        {
            get { return _user; }
            set { _user = value; }
        }


        public Dashboard(string email)
        {
            InitializeComponent();
            DataContext = this;
            loggedUser = new User();
            onBoot(email);
        }

        public void onBoot(string email)
        {
            loggedUser.SetUser(email);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Login loginWin = new();
            loginWin.Show();
        }

        private void btnUploadFile_click(object sender, RoutedEventArgs e)
        {
            FileUpload fileUpload = new FileUpload(loggedUser);
            fileUpload.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
