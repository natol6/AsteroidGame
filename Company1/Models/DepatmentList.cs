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
    class DepatmentList : BaseList<Depatment>
    {
        
        public DepatmentList(string company) : base(company)
        {
            FileName = "../../../Resourses/Depatments_" + Company + ".json";
        }
        public DepatmentList() : base()
        {
            FileName = "../../../Resourses/Depatments_" + Company + ".json";
        }

        public override void Load(string company)
        {
            list = JsonConvert.DeserializeObject<ObservableCollection<Depatment>>(File.ReadAllText("../../../Resourses/Depatments_" + Company + ".json"));
        }

        
    }
}
