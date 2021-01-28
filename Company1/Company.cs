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
        public void Remove_Employee(int index)
        {
            employees.Remove(index);
        }
        public void Remove_Position(int index)
        {
            positions.Remove(index);
        }
        public void Remove_Depatment(int index)
        {
            depatments.Remove(index);
        }
        public void Remove_TypeOfPosition(int index)
        {
            typeOfPositions.Remove(index);
        }
        public void Sort_Employee()
        {
            employees.Sort();
        }
        public void Sort_Position()
        {
            positions.Sort();
        }
        public void Sort_Depatment()
        {
            depatments.Sort();
        }
        public void Sort_TypeOfPosition()
        {
            typeOfPositions.Sort();
        }
        public bool Exists_Employee(Employee empl)
        {
            return employees.Exists(empl);
        }
        public bool Exists_Position(Position pos)
        {
            return positions.Exists(pos);
        }
        public bool Exists_Depatment(Depatment dep)
        {
            return depatments.Exists(dep);
        }
        public bool Exists_TypeOfPosition(TypeOfPosition tpos)
        {
            return typeOfPositions.Exists(tpos);
        }
        public string ToString_Employee()
        {
            return employees.ToString();
        }
        public string ToString_Position()
        {
            return positions.ToString();
        }
        public string ToString_Depatment()
        {
            return depatments.ToString();
        }
        public string ToString_TypeOfPosition()
        {
            return typeOfPositions.ToString();
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
                    employees.Add(new Employee("Фамилия-" + i + 3, "Имя-" + i + 3, "Отчество-" + i + 3, 2, i));
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
