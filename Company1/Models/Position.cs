﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Company1.Models
{
    class Position : INotifyPropertyChanged
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
        private int typeOfPositionId;
        public int TypeOfPositionId
        {
            get => typeOfPositionId; 
            set
            {
                typeOfPositionId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TypeOfPositionId)));
            }
        }

        public Position(int id, string title, int typeOfPosition)
        {
            Id = id;
            Title = title;
            TypeOfPositionId = typeOfPosition;
        }
        public override string ToString()
        {
            return $"{title}";
        }

    }
}
