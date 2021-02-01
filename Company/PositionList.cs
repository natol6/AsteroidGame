using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Company
{
    class PositionList : BaseList<Position>
    {
        private readonly string title = $"{"№ п/п",5}    {"Id:",-5}    {"Должность:",-20}    {"Id типа должности:",-5}\n\n";
        private readonly string position = "{0,4}.    {1,-5}    {2,-20}    {3,-5}\n";
        public PositionList(string company) : base(company)
        {
            FileName = "../../../Resourses/Positions_" + Company + ".json";
        }
        public PositionList() : base()
        {
            FileName = "../../../Resourses/Positions_" + Company + ".json";
        }

        public override void Load(string company)
        {
            list = JsonConvert.DeserializeObject<List<Position>>(File.ReadAllText("../../../Resourses/Positions_" + Company + ".json"));
        }

        public override bool Exists(Position obj)
        {
            return list.Exists(x => x.Id == obj.Id && x.Title == obj.Title && x.TypeOfPositionId == obj.TypeOfPositionId);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(title);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    sb.AppendFormat(position, i + 1, list[i].Id, list[i].Title, list[i].TypeOfPositionId);
                }

            }
            return sb.ToString();
        }
    }
}
