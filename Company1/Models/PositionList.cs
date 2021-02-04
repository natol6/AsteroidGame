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
    class PositionList : BaseList<Position>
    {

        public PositionList(string company) : base(company)
        {
            FileName = $"Resourses/Positions_{GetHashCode()}.json";
        }
        public PositionList() : base()
        {
            FileName = $"Resourses/Positions_{GetHashCode()}.json";
        }

        
               
    }
}
