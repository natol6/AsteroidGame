using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Company1
{
    class EmployeeList : BaseList<Employee>
    {
        private readonly string title = $"{"№ п/п",5}    {"Фамилия:",-20}    {"Имя:",-20}    {"Отчество:",-20}    {"Должность:",-20}    {"Подразделение:",-20}\n\n";
        private readonly string employee = "{0,4}.    {1,-20}    {2,-20}    {3,-20}    {4,-20}    {5,-20}\n";
        public EmployeeList(string company) : base(company)
        {
            FileName = "../../../Resourses/Employees_" + Company + ".json";
        }
        public EmployeeList() : base()
        {
            FileName = "../../../Resourses/Employees_" + Company + ".json";
        }

        public override void Load(string company)
        {
            list = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText("../../../Resourses/Employees_" + Company + ".json"));
        }

        public override bool Exists(Employee obj)
        {
            return list.Exists(x => x.Surname == obj.Surname && x.Name == obj.Name && x.MiddleName == obj.MiddleName && x.PositionId == obj.PositionId && x.DepatmentId == obj.DepatmentId);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(title);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    sb.AppendFormat(employee, i + 1, list[i].Surname, list[i].Name, list[i].MiddleName, list[i].PositionId, list[i].DepatmentId);
                }

            }
            return sb.ToString();
        }
    }
}
