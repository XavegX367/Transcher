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

namespace Transcher.Views
{
    /// <summary>
    /// Interaction logic for FileUpload.xaml
    /// </summary>
    public partial class FileUpload : Window
    {
        public User currentUser = new User();

        public FileUpload(User loggedUser)
        {
            InitializeComponent();
            onBoot(loggedUser);
        }

        public void onBoot(User loggedUser)
        {
            currentUser = loggedUser;
        }
    }
}
