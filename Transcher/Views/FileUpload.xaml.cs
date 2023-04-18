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

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            file.UploadFile(currentUser);
        }
    }
}
