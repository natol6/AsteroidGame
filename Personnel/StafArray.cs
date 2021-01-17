using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

namespace Personnel
{
    class StafArray
    {
        private List<BaseEmployee> staff;
        private string FileName { get; set; }
        private string Company { get; set; }
        private readonly string title = $"{"№ п/п",5}    {"Фамилия:",-20}    {"Имя:",-20}    {"Отчество:",-20}\n\n";
        private readonly string employee = "{0,4}.    {1,-20}    {2,-20}    {3,-20}\n";
        public StafArray(string company) 
        {
            staff = new List<BaseEmployee>();
            Company = company;
            FileName = "CollectivesOfEnterprises//Staff_" + Company + ".json";
        }
        public StafArray()
        {
            staff = new List<BaseEmployee>();
            Company = "Example";
            FileName = "CollectivesOfEnterprises//Staff_" + Company + ".json";
        }
        public void Save()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(staff));
        }
        public void Load(string company)
        {
            staff = JsonConvert.DeserializeObject<List<BaseEmployee>>(File.ReadAllText("CollectivesOfEnterprises//Staff_" + Company + ".json"));
        }
        public void Add(BaseEmployee empl)
        {
            staff.Add(empl);
        }
        public void Remove(int index)
        {
            if (staff != null && index < staff.Count && index >= 0) staff.RemoveAt(index);
        }
        public int Count
        {
            get { return staff.Count; }
        }

        public void Sort()
        {
            staff.Sort();
        }
        public bool Exists(BaseEmployee empl)
        {
            return staff.Exists(x => x.Surname == empl.Surname && x.Name == empl.Name && x.MiddleName == empl.MiddleName && x.Position == empl.Position);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(title);
            for (int i = 0; i < staff.Count; i++)
            {
                if (staff[i] != null)
                {
                    sb.AppendFormat(employee, i + 1, staff[i].Surname, staff[i].Name, staff[i].MiddleName, staff[i].Position);
                }

            }
            return sb.ToString();
        }

    }
}
