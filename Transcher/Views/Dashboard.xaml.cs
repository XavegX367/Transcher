using Domain.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Transcher.Classes;
using Transcher.Repositories;

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

        private File _fileClass;

        public File fileClass
        {
            get { return _fileClass; }
            set { _fileClass = value; }
        }

        private List<File> _files;

        public List<File> Files
        {
            get { return _files; }
            set { _files = value; }
        }

        private File _selectedFile;

        public File SelectedFile
        {
            get { return _selectedFile; }
            set { _selectedFile = value; }
        }

        public IFile fileInterface;

        public Dashboard(string email)
        {
            InitializeComponent();
            DataContext = this;
            IUser userInterface = new UserRepository();
            loggedUser = new User(userInterface);
            IFile fileInterface = new FileRepository();
            fileClass = new File();
            fileClass.SetRepository(fileInterface);
            onBoot(email);
        }

        public void onBoot(string email)
        {
            loggedUser.SetUser(email);
            Files = _fileClass.RetrieveFiles();

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

        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Open a new window where an overview + download button will be shown pass seleced file "SelectedFile"
        }
    }
}
