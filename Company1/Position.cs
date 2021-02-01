using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Company1
{
    class Position : INotifyPropertyChanged
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
        private int typeOfPositionId;
        public int TypeOfPositionId
        {
            get { return typeOfPositionId; }
            set
            {
                typeOfPositionId = value;
                OnPropertyChanged("TypeOfPositionId");
            }
        }

        public Position(int id, string title, int typeOfPosition)
        {
            Id = id;
            Title = title;
            TypeOfPositionId = typeOfPosition;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
