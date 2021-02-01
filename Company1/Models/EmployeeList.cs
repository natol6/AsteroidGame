using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace Company1.Models
{
    class EmployeeList : BaseList<Employee>
    {

        public EmployeeList(string company) : base(company)
        {
            FileName = $"Resourses/Employees_{GetHashCode()}.json";
        }
        public EmployeeList() : base()
        {
            FileName = $"Resourses/Employees_{GetHashCode()}.json";
        }

        
                        
    }
}
