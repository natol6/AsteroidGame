using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Company
{
    class DepatmentList : BaseList<Depatment>
    {
        private readonly string title = $"{"№ п/п",5}    {"Id:",-5}    {"Подразделение:",-20}\n\n";
        private readonly string depatment = "{0,4}.    {1,-5}    {1,-20}\n";
        public DepatmentList(string company): base(company)
        {
            FileName = "../../../Resourses/Depatments_" + Company + ".json";
        }
        public DepatmentList(): base()
        {
            FileName = "../../../Resourses/Depatments_" + Company + ".json";
        }

        public override void Load(string company)
        {
            list = JsonConvert.DeserializeObject<List<Depatment>>(File.ReadAllText("../../../Resourses/Depatments_" + Company + ".json"));
        }

        public override bool Exists(Depatment obj)
        {
            return list.Exists(x => x.Id == obj.Id && x.Title == obj.Title);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(title);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    sb.AppendFormat(depatment, i + 1, list[i].Id, list[i].Title);
                }

            }
            return sb.ToString();
        }
    }
    
}
