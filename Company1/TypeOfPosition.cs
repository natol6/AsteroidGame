using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Company1
{
    class TypeOfPosition : INotifyPropertyChanged
    {
        private int id;
        public int Id 
        {
            get { return id; }
            set 
            { 
                id = value;
                OnPropertyChanged("Id");
            } 
        }
        private string title;
        public string Title 
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            } 
        }

        public TypeOfPosition(int id, string title)
        {
            Id = id;
            Title = title;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
