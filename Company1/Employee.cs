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
        private string surname;
        public string Surname 
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        private string name;
        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string middlename;
        public string MiddleName 
        {
            get { return middlename; }
            set
            {
                middlename = value;
                OnPropertyChanged("MiddleName");
            }
        }
        private int positionId;
        public int PositionId 
        {
            get { return positionId; }
            set
            {
                positionId = value;
                OnPropertyChanged("PositionId");
            }
        }
        private int depatmentId;
        public int DepatmentId 
        {
            get { return depatmentId; }
            set
            {
                depatmentId = value;
                OnPropertyChanged("DepatmentId");
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
