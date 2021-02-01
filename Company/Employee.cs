using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    class Employee
    {
        public string Surname { get; init; }
        public string Name { get; init; }
        public string MiddleName { get; init; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public Employee(string surname, string name, string middleName, int positionId, int depatmentId)
        {
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            PositionId = positionId;
            DepartmentId = depatmentId;
        }
    }
}
