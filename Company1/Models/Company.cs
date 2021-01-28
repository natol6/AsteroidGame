using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company1
{
    class Company
    {
        public string Title { get; set; }
        private EmployeeList employees;
        public EmployeeList Employees { get { return employees; } }
        private PositionList positions;
        public PositionList Positions { get { return positions; } }
        private DepatmentList depatments;
        public DepatmentList Depatments { get { return depatments; } }
        private TypeOfPositionList typeOfPositions;
        public TypeOfPositionList TypeOfPositions { get { return typeOfPositions; } }
        public Company(string title)
        {
            Title = title;
            employees = new EmployeeList(title);
            positions = new PositionList(title);
            depatments = new DepatmentList(title);
            typeOfPositions = new TypeOfPositionList(title);
        }
        public Company()
        {
            Title = "Example";
            employees = new EmployeeList(Title);
            positions = new PositionList(Title);
            depatments = new DepatmentList(Title);
            typeOfPositions = new TypeOfPositionList(Title);
        }

        public void Save()
        {
            employees.Save();
            positions.Save();
            depatments.Save();
            typeOfPositions.Save();

        }
        public void Load()
        {
            employees.Load(Title);
            positions.Load(Title);
            depatments.Load(Title);
            typeOfPositions.Load(Title);
        }
        public void Add_Employee(Employee empl)
        {
            employees.Add(empl);
        }
        public void Add_Position(Position pos)
        {
            positions.Add(pos);
        }
        public void Add_Depatment(Depatment dep)
        {
            depatments.Add(dep);
        }
        public void Add_TypeOfPosition(TypeOfPosition tpos)
        {
            typeOfPositions.Add(tpos);
        }
        public void Remove_Employee(Employee empl)
        {
            employees.Remove(empl);
        }
        public void Remove_Position(Position pos)
        {
            positions.Remove(pos);
        }
        public void Remove_Depatment(Depatment dep)
        {
            depatments.Remove(dep);
        }
        public void Remove_TypeOfPosition(TypeOfPosition tpos)
        {
            typeOfPositions.Remove(tpos);
        }
        
        public bool Contains_Employee(Employee empl)
        {
            return employees.Contains(empl);
        }
        public bool Contains_Position(Position pos)
        {
            return positions.Contains(pos);
        }
        public bool Contains_Depatment(Depatment dep)
        {
            return depatments.Contains(dep);
        }
        public bool Contains_TypeOfPosition(TypeOfPosition tpos)
        {
            return typeOfPositions.Contains(tpos);
        }
        
        public bool Generate_Company(int empl, int dep)
        {
            if (dep < 2 || empl <= dep + 3) return false;
            else
            {
                Random rnd = new Random();
                typeOfPositions.Add(new TypeOfPosition(1, "Руководитель"));
                typeOfPositions.Add(new TypeOfPosition(2, "Начальник подразделения"));
                typeOfPositions.Add(new TypeOfPosition(3, "Работник"));
                positions.Add(new Position(1, "Директор", 1));
                employees.Add(new Employee("Фамилия-1", "Имя-1", "Отчество-1", 1, 0));
                positions.Add(new Position(2, "Главный бухгалтер", 1));
                employees.Add(new Employee("Фамилия-2", "Имя-2", "Отчество-2", 2, 0));
                positions.Add(new Position(3, "Заместитель директора", 1));
                employees.Add(new Employee("Фамилия-3", "Имя-3", "Отчество-3", 3, 0));
                depatments.Add(new Depatment(0, "Руководство"));
                for (int i = 1; i <= dep; i++)
                {
                    depatments.Add(new Depatment(i, "Подразделение-" + i));
                    positions.Add(new Position(i + 3, "Начальник подразделения-" + i, 2));
                    employees.Add(new Employee("Фамилия-" + i + 3, "Имя-" + i + 3, "Отчество-" + i + 3, i + 3, i));
                }
                int maxPos = empl - employees.Count;
                if (maxPos > 5) maxPos = 5;
                for (int i = 1; i <= maxPos; i++)
                {
                    positions.Add(new Position(i + 3 + dep, "Должность работника-" + i, 3));
                }
                for (int i = 0; i < empl; i++)
                {
                    employees.Add(new Employee("Фамилия-" + i, "Имя-" + i, "Отчество-" + i, 3 + dep + rnd.Next(1, maxPos + 1), rnd.Next(1, dep + 1)));
                }
                return true;
            }
        }
    }
}
