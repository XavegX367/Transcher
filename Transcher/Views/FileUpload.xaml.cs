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
        OpenFileDialog openFileDialog = new OpenFileDialog();

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
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                tbFilePath.Text = Path.GetFullPath(openFileDialog.FileName);

                string fileName = openFileDialog.FileName;
                while (fileName.Contains("\\")){
                    fileName = fileName.Substring(fileName.IndexOf("\\") + 1);
                }

                file.CreateFile(Path.GetFullPath(openFileDialog.FileName), fileName);
            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {

            if (tbFilePath.Text == "")
            {
                return;
            }

            file.UploadFile(currentUser);
        }
    }
}
