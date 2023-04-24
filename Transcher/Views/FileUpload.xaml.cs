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
            file.CreateFile(tbName.Text, tbExtension.Text, currentUser);
            bool status = file.UploadFile();

            if (!status) { 
                MessageBox.Show("Er is iets misgegaan, probeer het opnieuw.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            MessageBox.Show("Bestand is succesvol geupload.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
