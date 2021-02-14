using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Company_Lesson_7.Models;
using System.Windows;
using System.Collections;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Company_Lesson_7.ViewModels;
using System.Collections.Specialized;

namespace Company_Lesson_7.ViewModels
{
    class CompanyViewModels : INotifyPropertyChanged
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

        public ObservableCollection<Position> Positions { get; set; } = new ObservableCollection<Position>();

        public ObservableCollection<Depatment> Depatments { get; set; } = new ObservableCollection<Depatment>();

        public ObservableCollection<TypeOfPosition> TypeOfPositions { get; set; } = new ObservableCollection<TypeOfPosition>();
        public ObservableCollection<string> CompanyNames { get; set; } = new ObservableCollection<string>();

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedEmployee)));
            }
        }
        private Position _selectedPosition;
        public Position SelectedPosition
        {
            get => _selectedPosition;
            set
            {
                _selectedPosition = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPosition)));
            }
        }
        private Depatment _selectedDepatment;
        public Depatment SelectedDepatment
        {
            get => _selectedDepatment;
            set
            {
                _selectedDepatment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedDepatment)));
            }
        }
        private TypeOfPosition _selectedTypeOfPosition;
        public TypeOfPosition SelectedTypeOfPosition
        {
            get => _selectedTypeOfPosition;
            set
            {
                _selectedTypeOfPosition = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTypeOfPosition)));
            }
        }
        private string _selectedCompanyName;
        public string SelectedCompanyName
        {
            get => _selectedCompanyName;
            set
            {
                _selectedCompanyName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCompanyName)));
            }
        }
        DB_Connect_API dbconnect = new DB_Connect_API();
        public CompanyViewModels()
        {
            Title = "Предприятие не создано или не загружено";
            CompanyNames.Add("Example");
            Employees.CollectionChanged += UpdateEmployee;
            Depatments.CollectionChanged += UpdateDepatment;
            Positions.CollectionChanged += UpdatePosition;
            TypeOfPositions.CollectionChanged += UpdateTypeOfPosition;
        }
        
        public void LoadCompany()
        {
            //if (SelectedCompanyName == null) return;
            Clear();
            //Rename();
            SelectedCompanyName = "Example";
            Title = SelectedCompanyName;
            var typeofpositions = dbconnect.DbGetTypeOfPosition();
            foreach (TypeOfPosition top in typeofpositions)
                TypeOfPositions.Add(top);
            var positions = dbconnect.DbGetPosition();
            foreach (Position pos in positions)
                Positions.Add(pos);
            var depatments = dbconnect.DbGetDepatment();
            foreach (Depatment dep in depatments)
                Depatments.Add(dep);
            var employees = dbconnect.DbGetEmployee();
            foreach (Employee empl in employees)
                Employees.Add(empl);

        }
        public void Clear()
        {
            Employees.Clear();
            Positions.Clear();
            Depatments.Clear();
            TypeOfPositions.Clear();
        }
        public void CreateExample()
        {
            int dep = 8;
            int empl = 100;
            SelectedCompanyName = "Example";
            Clear();
            Title = SelectedCompanyName;
            //dbconnect.CreateDbAndConStrBuild(SelectedCompanyName);
            Random rnd = new Random();
            TypeOfPositions.Add(dbconnect.AddBdTypeOfPosition(new TypeOfPosition { Title = "Руководитель" }));
            TypeOfPositions.Add(dbconnect.AddBdTypeOfPosition(new TypeOfPosition { Title = "Начальник подразделения" }));
            TypeOfPositions.Add(dbconnect.AddBdTypeOfPosition(new TypeOfPosition { Title = "Работник" }));
            Positions.Add(dbconnect.AddBdPosition(new Position { Title = "Директор", TypeOfPositionId = 1 }));
            Employees.Add(dbconnect.AddBdEmployee(new Employee { Surname = "Фамилия-1", Name = "Имя-1", MiddleName = "Отчество-1", PositionId = 1, DepatmentId = 1 }));
            Positions.Add(dbconnect.AddBdPosition(new Position { Title = "Главный бухгалтер", TypeOfPositionId = 1 }));
            Employees.Add(dbconnect.AddBdEmployee(new Employee { Surname = "Фамилия-2", Name = "Имя-2", MiddleName= "Отчество-2", PositionId = 2, DepatmentId = 1 }));
            Positions.Add(dbconnect.AddBdPosition(new Position { Title = "Заместитель директора", TypeOfPositionId = 1 }));
            Employees.Add(dbconnect.AddBdEmployee(new Employee { Surname = "Фамилия-3", Name = "Имя-3", MiddleName = "Отчество-3", PositionId = 3, DepatmentId = 1 }));
            Depatments.Add(dbconnect.AddBdDepatment(new Depatment { Title = "Руководство" }));
            for (int i = 1; i <= dep; i++)
            {
                Depatments.Add(dbconnect.AddBdDepatment(new Depatment { Title = "Подразделение-" + i }));
                Positions.Add(dbconnect.AddBdPosition(new Position { Title = "Начальник подразделения-" + i, TypeOfPositionId = 2 }));
                Employees.Add(dbconnect.AddBdEmployee(new Employee { Surname = "Фамилия-" + i + 3, Name = "Имя-" + i + 3, MiddleName = "Отчество-" + i + 3, PositionId = i + 3, DepatmentId = i + 1 }));
            }
            int maxPos = empl - 3 - dep;
            if (maxPos > 5) maxPos = 5;
            for (int i = 1; i <= maxPos; i++)
            {
                Positions.Add(dbconnect.AddBdPosition(new Position { Title = "Должность работника-" + i, TypeOfPositionId = 3 }));
            }
            
            for (int i = 3 + dep + 1; i <= empl; i++)
            {
                Employees.Add(dbconnect.AddBdEmployee(new Employee { Surname = "Фамилия-" + i, Name = "Имя-" + i, MiddleName = "Отчество-" + i, PositionId = 3 + dep + rnd.Next(1, maxPos + 1), DepatmentId = rnd.Next(1, dep + 1) + 1 }));
            }


        }
        public void AddTypeOfPosition()
        {
            SelectedTypeOfPosition = null;
            TypeOfPositions.Add(dbconnect.AddBdTypeOfPosition(new TypeOfPosition { Title = "??? Тип персонала ???" }));
            SelectedTypeOfPosition = TypeOfPositions.OrderBy(t => t.Id).LastOrDefault();

        }
        public void UpdateTypeOfPosition(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Replace)
            {
                TypeOfPosition new_top = e.NewItems[0] as TypeOfPosition;
                dbconnect.UpdateBdTypeOfPosition(new_top);
            }
            
        }
        public void DeleteTypeOfPosition()
        {
            if (Positions.Count(x => x.TypeOfPositionId == SelectedTypeOfPosition.Id) > 0)
            {
                MessageBox.Show("Для удаления типа должности удалите или измените тип всех должностей, имеющих данный тип в таблице 'Должности'.");
                return;
            }
            dbconnect.DeleteBdTypeOfPosition(SelectedTypeOfPosition.Id);
            TypeOfPositions.Remove(SelectedTypeOfPosition);
            SelectedTypeOfPosition = null;

        }
        public void AddDepatment()
        {
            SelectedDepatment = null;
            Depatments.Add(dbconnect.AddBdDepatment(new Depatment { Title = "??? Подразделение ???" }));
            SelectedDepatment = Depatments.OrderBy(d => d.Id).LastOrDefault();

        }
        public void UpdateDepatment(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                Depatment new_dep = e.NewItems[0] as Depatment;
                dbconnect.UpdateBdDepatment(new_dep);
            }

        }
        public void DeleteDepatment()
        {
            if (Employees.Count(x => x.DepatmentId == SelectedDepatment.Id) > 0)
            {
                MessageBox.Show("Для удаления подразделения удалите или измените подразделение у всех сотрудников, работающих в данном подразделении в таблице 'Сотрудники'.");
                return;
            }
            dbconnect.DeleteBdDepatment(SelectedDepatment.Id);
            Depatments.Remove(SelectedDepatment);
            SelectedDepatment = null;
        }
        public void AddPosition()
        {
            if (TypeOfPositions.Count == 0)
            {
                MessageBox.Show("Для добавления новой должности предварительно заполните таблицу 'Типы должностей'.");
                return;
            }
            SelectedPosition = null;
            Positions.Add(dbconnect.AddBdPosition(new Position { Title = "??? Должность ???", TypeOfPositionId = 1 }));
            SelectedPosition = Positions.OrderBy(p => p.Id).LastOrDefault();

        }
        public void UpdatePosition(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                Position new_pos = e.NewItems[0] as Position;
                dbconnect.UpdateBdPosition(new_pos);
            }

        }
        public void DeletePosition()
        {
            if (Employees.Count(x => x.PositionId == SelectedPosition.Id) > 0)
            {
                MessageBox.Show("Для удаления должности удалите или измените должности у всех сотрудников, имеющих данную должность в таблице 'Сотрудники'.");
                return;
            }
            dbconnect.DeleteBdPosition(SelectedPosition.Id);
            Positions.Remove(SelectedPosition);
            SelectedPosition = null;
        }
        public void AddEmployee()
        {
            if (Positions.Count == 0 || Depatments.Count == 0)
            {
                MessageBox.Show("Для добавления нового сотрудника предварительно заполните таблицы 'Должности' и 'Подразделения'.");
                return;
            }
            SelectedEmployee = null;
            Employees.Add(dbconnect.AddBdEmployee(new Employee { Surname = "??? Фамилия ???", Name = "??? Имя ???", MiddleName = "??? Отчество ???", PositionId = 1, DepatmentId = 1 }));
            SelectedEmployee = Employees.OrderBy(e => e.Id).LastOrDefault();

        }
        public void UpdateEmployee(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                Employee new_empl = e.NewItems[0] as Employee;
                dbconnect.UpdateBdEmployee(new_empl);
            }

        }
        public void DeleteEmployee()
        {
            dbconnect.DeleteBdEmployee(SelectedEmployee.Id);
            Employees.Remove(SelectedEmployee);
            SelectedEmployee = null;
        }
    }
}
