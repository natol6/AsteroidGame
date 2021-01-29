using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;


namespace Company_Lesson_5.Models
{
    class Depatment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
                
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
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public void Add(Employee empl)
        {
            Employees.Add(empl);
        }
        public void RemoveSelectedEmployee(Employee empl)
        {
            Employees.Remove(empl);
        }
        public override string ToString()
        {
            return $"{title}";
        }


    }
}
