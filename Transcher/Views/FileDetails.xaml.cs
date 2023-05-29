using Mysqlx.Expr;
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
    /// Interaction logic for FileDetails.xaml
    /// </summary>
    /// 
    public partial class FileDetails : Window
    {
        private User _currentUser;
        public User currentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        private Transcher.Classes.File _currentFile;
        public Transcher.Classes.File currentFile
        {
            get { return _currentFile; }
            set { _currentFile = value; }
        }

        public FileDetails(Transcher.Classes.File file, User loggedUser)
        {
            InitializeComponent();
            currentFile = file;
            currentUser = loggedUser;
        }

        private void btnSubmitReview_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dashboard dashWin = new Dashboard(currentUser);
            dashWin.Show();
        }
    }
}
