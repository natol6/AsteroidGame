using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Company
    {
        public string Title { get; set; }
        private EmployeeList employees;
        private PositionList positions;
        private DepatmentList depatments;
        public Company(string title)
        {
            Title = title;
            employees = new EmployeeList(title);
            positions = new PositionList(title);
        }
        public Company()
        {
            Title = "Example";
            employees = new EmployeeList(Title);
            positions = new PositionList(Title);
        }
        
        public void Save()
        {
            employees.Save();
            positions.Save();
            depatments.Save();

        }
        public void Load()
        {
            employees.Load(Title);
            positions.Load(Title);
            depatments.Load(Title);
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
        public void Generate_Company(int empl, int pos, int dep)
        {
            Random rnd = new Random();
            for (int i = 0; i < pos; i++)
            {
                positions.Add(new Position(i + 1, "Должность-" + i + 1));
            }
            for (int i = 0; i < dep; i++)
            {
                depatments.Add(new Depatment(i + 1, "Подразделение-" + i + 1));
            }
            for (int i = 0; i < empl; i++)
            {
                employees.Add(new Employee("Фамилия-" + i, "Имя-" + i, "Отчество-" + i, rnd.Next(1, pos + 1), rnd.Next(1, dep + 1)));
            }
        }
    }
}
