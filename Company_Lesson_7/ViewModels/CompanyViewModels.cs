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
        DB_Connect dbconnect = new DB_Connect();
        public CompanyViewModels()
        {
            Title = "Предприятие не создано или не загружено";
            CompanyNames.Add("Example");
        }

        /*public void SaveCompany()
        {
            Employees.Save();
            Positions.Save();
            Depatments.Save();
            TypeOfPositions.Save();
            if (!CompanyNames.Contains(Title)) CompanyNames.Add(Title);
            CompanyNames.Save();


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

        }*/
        public void LoadCompany()
        {
            //if (SelectedCompanyName == null) return;
            Clear();
            //Rename();
            SelectedCompanyName = "Example";
            Title = SelectedCompanyName;
            foreach (TypeOfPosition top in dbconnect.DbGetTypeOfPosition())
                TypeOfPositions.Add(top);
            foreach (Position pos in dbconnect.DbGetPosition())
                Positions.Add(pos);
            foreach (Depatment dep in dbconnect.DbGetDepatment())
                Depatments.Add(dep);
            foreach (Employee empl in dbconnect.DbGetEmployee())
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
            TypeOfPositions.Add(dbconnect.AddBdTypeOfPosition("Руководитель"));
            TypeOfPositions.Add(dbconnect.AddBdTypeOfPosition("Начальник подразделения"));
            TypeOfPositions.Add(dbconnect.AddBdTypeOfPosition("Работник"));
            Positions.Add(dbconnect.AddBdPosition("Директор", 1));
            Employees.Add(dbconnect.AddBdEmployee("Фамилия-1", "Имя-1", "Отчество-1", 1, 1));
            Positions.Add(dbconnect.AddBdPosition("Главный бухгалтер", 1));
            Employees.Add(dbconnect.AddBdEmployee("Фамилия-2", "Имя-2", "Отчество-2", 2, 1));
            Positions.Add(dbconnect.AddBdPosition("Заместитель директора", 1));
            Employees.Add(dbconnect.AddBdEmployee("Фамилия-3", "Имя-3", "Отчество-3", 3, 1));
            Depatments.Add(dbconnect.AddBdDepatment("Руководство"));
            for (int i = 1; i <= dep; i++)
            {
                Depatments.Add(dbconnect.AddBdDepatment("Подразделение-" + i));
                Positions.Add(dbconnect.AddBdPosition("Начальник подразделения-" + i, 2));
                Employees.Add(dbconnect.AddBdEmployee("Фамилия-" + i + 3, "Имя-" + i + 3, "Отчество-" + i + 3, i + 3, i + 1));
            }
            int maxPos = empl - 3 - dep;
            if (maxPos > 5) maxPos = 5;
            for (int i = 1; i <= maxPos; i++)
            {
                Positions.Add(dbconnect.AddBdPosition("Должность работника-" + i, 3));
            }
            
            for (int i = 3 + dep + 1; i <= empl; i++)
            {
                Employees.Add(dbconnect.AddBdEmployee("Фамилия-" + i, "Имя-" + i, "Отчество-" + i, 3 + dep + rnd.Next(1, maxPos + 1), rnd.Next(1, dep + 1) + 1));
            }
            
            
        }
        public void AddTypeOfPosition()
        {
            TypeOfPositions.Add(dbconnect.AddBdTypeOfPosition("??? Тип персонала ???"));
            SelectedTypeOfPosition = TypeOfPositions[TypeOfPositions.Count - 1];

        }
        public void DeleteTypeOfPosition()
        {
            if(Positions.Count(x => x.TypeOfPositionId == SelectedTypeOfPosition.Id) > 0)
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
            Depatments.Add(dbconnect.AddBdDepatment("??? Подразделение ???"));
            SelectedDepatment = Depatments[Depatments.Count - 1];

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
            if(TypeOfPositions.Count == 0)
            {
                MessageBox.Show("Для добавления новой должности предварительно заполните таблицу 'Типы должностей'.");
                return;
            }
            Positions.Add(dbconnect.AddBdPosition("??? Должность ???", 1)); //надо скорректировать
            SelectedPosition = Positions[Positions.Count - 1];

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
            Employees.Add(dbconnect.AddBdEmployee("??? Фамилия ???", "??? Имя ???", "??? Отчество ???", 1, 1)); //надо скорректировать
            SelectedEmployee = Employees[Employees.Count - 1];

        }
        public void DeleteEmployee()
        {
            dbconnect.DeleteBdEmployee(SelectedEmployee.Id);
            Employees.Remove(SelectedEmployee);
            SelectedEmployee = null;
        }
    }
}
