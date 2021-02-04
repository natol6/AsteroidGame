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
    class TypeOfPositionList : BaseList<TypeOfPosition>
    {

        public TypeOfPositionList(string company) : base(company)
        {
            FileName = $"Resourses/TypeOfPositions_{GetHashCode()}.json";
        }
        public TypeOfPositionList() : base()
        {
            FileName = $"Resourses/TypeOfPositions_{GetHashCode()}.json";
        }

        
                
    }
}
