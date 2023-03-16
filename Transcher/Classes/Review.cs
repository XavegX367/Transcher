using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Transcher.Classes
{
    public class Review: INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private decimal rating;

        public decimal Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
