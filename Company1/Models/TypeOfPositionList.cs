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
    class TypeOfPositionList : BaseList<TypeOfPosition>
    {
        
        public TypeOfPositionList(string company) : base(company)
        {
            FileName = "../../../Resourses/TypeOfPositions_" + Company + ".json";
        }
        public TypeOfPositionList() : base()
        {
            FileName = "../../../Resourses/TypeOfPositions_" + Company + ".json";
        }

        public override void Load(string company)
        {
            list = JsonConvert.DeserializeObject<ObservableCollection<TypeOfPosition>>(File.ReadAllText("../../../Resourses/TypeOfPositions_" + Company + ".json"));
        }
                
    }
}
