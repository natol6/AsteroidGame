using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Company1.Models
{
    class TypeOfPosition : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int id;
        public int Id 
        {
            get => id; 
            set 
            { 
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            } 
        }
        private string title;
        public string Title 
        {
            get => title; 
            set
            {
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            } 
        }

        public TypeOfPosition(int id, string title)
        {
            Id = id;
            Title = title;

        }
        
        public override string ToString()
        {
            return $"{title}";
        }

    }
}
