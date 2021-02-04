using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Company1.Models;
using System.Windows;

namespace Company1.ViewModels
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
        public EmployeeList Employees { get; set; }

        public PositionList Positions { get; set; }

        public DepatmentList Depatments { get; set; }

        public TypeOfPositionList TypeOfPositions { get; set; }
        public CompanyNameList CompanyNames { get; set; } = new CompanyNameList();

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
        public CompanyViewModels()
        {
            CompanyNames.Load();
            Title = "Предприятие не создано или не загружено";
            Employees = new EmployeeList(Title);
            Positions = new PositionList(Title);
            Depatments = new DepatmentList(Title);
            TypeOfPositions = new TypeOfPositionList(Title);
            
        }

        public void SaveCompany()
        {
            Employees.Save();
            Positions.Save();
            Depatments.Save();
            TypeOfPositions.Save();
            if (!CompanyNames.Contains(Title)) CompanyNames.Add(Title);
            CompanyNames.Save();


        }
        public void Clear()
        {
            Employees.Clear();
            Positions.Clear();
            Depatments.Clear();
            TypeOfPositions.Clear();
        }
        public void Rename()
        {
            Title = SelectedCompanyName;
            Employees.Company = Title;
            Depatments.Company = Title;
            Positions.Company = Title;
            TypeOfPositions.Company = Title;
        }
        public void RenameThis()
        {
            SelectedCompanyName = null;
            CompanyNameDialog cnd = new CompanyNameDialog();
            cnd.ShowDialog();
            if (SelectedCompanyName == null) return;
            if (CompanyNames.Contains(SelectedCompanyName))
            {
                MessageBox.Show("Компания с таким наименованием есть в базе.");
                return;
            }
            Rename();
        }
        public void LoadCompany()
        {
            if (SelectedCompanyName == null) return;
            Clear();
            Rename();
            Employees.Load();
            Positions.Load();
            Depatments.Load();
            TypeOfPositions.Load();
        }
        public void DeleteCompany()
        {
            Clear();
            SelectedCompanyName = "Предприятие не создано или не загружено";
            Rename();
        }
        
        public void CreateNew()
        {
            SelectedCompanyName = null;
            CompanyNameDialog cnd = new CompanyNameDialog();
            cnd.ShowDialog();
            if (SelectedCompanyName == null) return;
            if (CompanyNames.Contains(SelectedCompanyName))
            {
                MessageBox.Show("Компания с таким наименованием создана ранее. Загрузите ее для работы.");
                return;
            }
            Clear();
            Rename();

        }

        public void CreateExample()
        {
            int dep = 8;
            int empl = 100;
            SelectedCompanyName = "Example";
            Clear();
            Rename();
            Random rnd = new Random();
            TypeOfPositions.Add(new TypeOfPosition(1, "Руководитель"));
            TypeOfPositions.Add(new TypeOfPosition(2, "Начальник подразделения"));
            TypeOfPositions.Add(new TypeOfPosition(3, "Работник"));
            Positions.Add(new Position(1, "Директор", 1));
            Employees.Add(new Employee("Фамилия-1", "Имя-1", "Отчество-1", 1, 0));
            Positions.Add(new Position(2, "Главный бухгалтер", 1));
            Employees.Add(new Employee("Фамилия-2", "Имя-2", "Отчество-2", 2, 0));
            Positions.Add(new Position(3, "Заместитель директора", 1));
            Employees.Add(new Employee("Фамилия-3", "Имя-3", "Отчество-3", 3, 0));
            Depatments.Add(new Depatment(0, "Руководство"));
            for (int i = 1; i <= dep; i++)
            {
                Depatments.Add(new Depatment(i, "Подразделение-" + i));
                Positions.Add(new Position(i + 3, "Начальник подразделения-" + i, 2));
                Employees.Add(new Employee("Фамилия-" + i + 3, "Имя-" + i + 3, "Отчество-" + i + 3, i + 3, i));
            }
            int maxPos = empl - 3 - dep;
            if (maxPos > 5) maxPos = 5;
            for (int i = 1; i <= maxPos; i++)
            {
                Positions.Add(new Position(i + 3 + dep, "Должность работника-" + i, 3));
            }
            
            for (int i = 3 + dep + 1; i <= empl; i++)
            {
                Employees.Add(new Employee("Фамилия-" + i, "Имя-" + i, "Отчество-" + i, 3 + dep + rnd.Next(1, maxPos + 1), rnd.Next(1, dep + 1)));
            }
            
            
        }
        public void AddDepatment()
        {
            var depatment = new Depatment(Depatments.Max(x => x.Id) + 1, "Введите наименование");
            Depatments.Add(depatment);
            SelectedDepatment = depatment;

        }
        public void DeleteDepatment()
        {
            if (SelectedDepatment is null) return;
            Depatments.Remove(SelectedDepatment);
            SelectedDepatment = null;
        }
    }
}
