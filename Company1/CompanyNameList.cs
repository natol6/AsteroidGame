using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

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
            list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("../../../Resourses/Companyes.json"));
        }
        public override void Load(string company)
        {
            throw new NotImplementedException();
        }

        public override bool Exists(string str)
        {
            return list.Exists(x => x == str);
        }
    }
}
