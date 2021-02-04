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
    class DepatmentList : BaseList<Depatment>
    {

        public DepatmentList(string company) : base(company)
        {
            FileName = $"Resourses/Depatments_{GetHashCode()}.json";
        }
        public DepatmentList() : base()
        {
            FileName = $"Resourses/Depatments_{GetHashCode()}.json";
        }
        




    }
}
