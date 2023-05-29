using Microsoft.Win32;
using System.Windows;
using System;
using System.IO;
using Transcher.Classes;
using Domain.Interfaces;
using Transcher.Repositories;

namespace Transcher.Views
{
    /// <summary>
    /// Interaction logic for FileUpload.xaml
    /// </summary>
    public partial class FileUpload : Window
    {
        private User _currentUser;
        public User currentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        private Transcher.Classes.File _file;

        public Transcher.Classes.File file 
        { 
            get { return _file; } 
            set { _file = value; } 
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();

        public FileUpload(User loggedUser)
        {
            InitializeComponent();
            IUser userInterface = new UserRepository();
            currentUser = new User(userInterface);
            IFile fileInterface = new FileRepository();
            file = new Classes.File();
            file.SetRepository(fileInterface);
            onBoot(loggedUser);
        }

        public void onBoot(User loggedUser)
        {
            currentUser = loggedUser;
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            bool result = file.CreateFile(tbName.Text, tbExtension.Text, currentUser);

            if (!result) { 
                MessageBox.Show("Er is iets misgegaan, probeer het opnieuw.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            MessageBox.Show("Bestand is succesvol geupload.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dashboard dashWin = new Dashboard(currentUser);
            dashWin.Show();
        }
    }
}
