using Microsoft.Win32;
using System.Windows;
using System;
using System.IO;
using Transcher.Classes;

namespace Transcher.Views
{
    /// <summary>
    /// Interaction logic for FileUpload.xaml
    /// </summary>
    public partial class FileUpload : Window
    {
        public User currentUser = new();
        public Transcher.Classes.File file = new();

        public FileUpload(User loggedUser)
        {
            InitializeComponent();
            onBoot(loggedUser);
        }

        public void onBoot(User loggedUser)
        {
            currentUser = loggedUser;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                tbFilePath.Text = Path.GetFullPath(openFileDialog.FileName);

            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {

            if (tbFilePath.Text == "")
            {
                return;
            }
            //file.UploadFile(currentUser, );
        }
    }
}
