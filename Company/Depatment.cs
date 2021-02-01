using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Depatment
    {
        public int Id { get; init; }
        public string Title { get; init; }
        
        public Depatment(int id, string title)
        {
            Id = id;
            Title = title;
            
        }
    }
}
