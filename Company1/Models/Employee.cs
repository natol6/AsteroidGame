using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Company1
{
    class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string surname;
        public string Surname 
        {
            get { return surname; }
            set
            {
                surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surname)));
            }
        }
        private string name;
        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        private string middlename;
        public string MiddleName 
        {
            get { return middlename; }
            set
            {
                middlename = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MiddleName)));
            }
        }
        private int positionId;
        public int PositionId 
        {
            get { return positionId; }
            set
            {
                positionId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PositionId)));
            }
        }
        private int depatmentId;
        public int DepatmentId 
        {
            get { return depatmentId; }
            set
            {
                depatmentId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DepatmentId)));
            }
        }
        public Employee(string surname, string name, string middleName, int positionId, int depatmentId)
        {
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            PositionId = positionId;
            DepatmentId = depatmentId;
        }
        public override string ToString()
        {
            return $"{surname} {name} {middlename}";
        }

    }
}
