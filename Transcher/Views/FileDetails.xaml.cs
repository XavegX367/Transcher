using Domain.Interfaces;
using Mysqlx.Expr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for FileDetails.xaml
    /// </summary>
    /// 
    public partial class FileDetails : Window, INotifyPropertyChanged
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

        private Review _review;
        public Review review
        { 
            get { return _review; } 
            set { _review = value; }
        }

        List<Review> reviews = new List<Review>();

        public FileDetails(Transcher.Classes.File file, User loggedUser)
        {
            InitializeComponent();
            DataContext = this;
            currentFile = file;
            currentUser = loggedUser;
            IReview reviewInterface = new ReviewRepository();
            review = new Review();
            review.SetRepository(reviewInterface);
            OnBoot();
        }

        public void OnBoot()
        {
            currentFile.GetReviews();
        }

        private void btnSubmitReview_Click(object sender, RoutedEventArgs e)
        {
            List<string> errors = new();
            if(review.Header == "" || review.Header == null)
            {
                errors.Add("Title can't be empty");
            }

            if(review.Comment == "" || review.Comment == null)
            {
                errors.Add("Message can't be empty");
            }

            if (review._Rating <= 0 || review._Rating > 5)
            {
                errors.Add("Rating must be between 0 and 5 without decimals");
            }

            if (errors.Count > 0)
            {
                string errorMessage = string.Join("\n", errors);
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool result = review.CreateNewReview(review, currentFile, currentUser);

            if (result)
            {
                //reviews.Add(review);
                //currentFile.AppendReview(review);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dashboard dashWin = new Dashboard(currentUser);
            dashWin.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
