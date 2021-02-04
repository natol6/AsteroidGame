using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Company_Lesson_5.Models
{
    class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string surname;
        public string Surname 
        {
            get => surname; 
            set
            {
                surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surname)));
            }
        }
        private string name;
        public string Name 
        {
            get => name; 
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        private string middlename;
        public string MiddleName 
        {
            get => middlename; 
            set
            {
                middlename = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MiddleName)));
            }
        }
        private string position;
        public string Position
        {
            get => position;
            set
            {
                position = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
            }
        }
        
        public override string ToString()
        {
            return $"{surname} {name} {middlename}";
        }

    }
}
