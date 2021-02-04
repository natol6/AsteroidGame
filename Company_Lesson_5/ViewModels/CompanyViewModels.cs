using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Company_Lesson_5.Models;

namespace Company_Lesson_5.ViewModels
{
    class CompanyViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ObservableCollection<Depatment> Depatments { get; set; }
        
        private Depatment _SelectedDepatment;
        public Depatment SelectedDepatment
        {
            get => _SelectedDepatment;
            set
            {
                _SelectedDepatment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedDepatment"));

                SelectedEmployee = null;
            }
        }
        private Depatment _SelectedDepatmentForMove;
        public Depatment SelectedDepatmentForMove
        {
            get => _SelectedDepatmentForMove;
            set
            {
                _SelectedDepatmentForMove = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedDepatmentForMove"));

            }
        }
        private Employee _SelectedEmployee;

        public Employee SelectedEmployee
        {
            get => _SelectedEmployee;
            set
            {
                _SelectedEmployee = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedEmployee"));
            }
        }
        public CompanyViewModels()
        {
            var j = 1;
            var rnd = new Random();
            var depatments = Enumerable.Range(1, 10)
               .Select(i => new Depatment
               {
                   Title = $"Подразделение-{i}",
                   Employees = new(Enumerable.Range(1, 15)
                      .Select(k => new Employee
                      {
                          Surname = $"Фамилия-{j}",
                          Name = $"Имя-{j}",
                          MiddleName = $"Отчество-{j++}",
                          Position = $"Должность-{rnd.Next(1, 6)}"
                      }))
               });
              

            Depatments = new(depatments);
                       
            
        }
        public void AddNewDepatment()
        {
            var depatment = new Depatment
            {
                Title = $"Подразделение-{Depatments.Count + 1}"
            };
            Depatments.Add(depatment);
            SelectedDepatment = depatment;
        }

        public void RemoveSelectedDepatment()
        {
            if (SelectedDepatment is null) return;
            Depatments.Remove(SelectedDepatment);
            SelectedDepatment = null;
        }
        public void AddNewEmployee()
        {
            Random rnd = new Random();
            var empl = new Employee
            {
                Surname = $"Фамилия-{SelectedDepatment.Employees.Count + 1}",
                Name = $"Имя-{SelectedDepatment.Employees.Count + 1}",
                MiddleName = $"Отчество-{SelectedDepatment.Employees.Count + 1}",
                Position = $"Должность-{rnd.Next(1, 6)}"
            };
            SelectedDepatment.Add(empl);
            SelectedEmployee = empl;
        }

        public void RemoveSelectedEmployee()
        {
            if (SelectedEmployee is null) return;
            SelectedDepatment.RemoveSelectedEmployee(SelectedEmployee);
            SelectedEmployee = null;
        }
        public void Move()
        {
            if (SelectedEmployee is null) return;
            SelectedDepatmentForMove.Add(SelectedEmployee);
            SelectedDepatment.RemoveSelectedEmployee(SelectedEmployee);
            SelectedEmployee = null;
        }
    }
}
