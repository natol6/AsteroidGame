using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace Company1
{
    class PositionList : BaseList<Position>
    {
        
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
            list = JsonConvert.DeserializeObject<ObservableCollection<Position>>(File.ReadAllText("../../../Resourses/Positions_" + Company + ".json"));
        }
               
    }
}
