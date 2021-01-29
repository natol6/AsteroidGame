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
    class CompanyNameList : BaseList<string>
    {
                
        public CompanyNameList() : base()
        {
            FileName = "../../../Resourses/Companyes.json";
        }

        public void LoadCompanyName()
        {
            list = JsonConvert.DeserializeObject<ObservableCollection<string>>(File.ReadAllText("../../../Resourses/Companyes.json"));
        }
        public override void Load(string company)
        {
            throw new NotImplementedException();
        }

        
    }
}
