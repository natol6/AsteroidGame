using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Position
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public int TypeOfPositionId { get; set; }

        public Position(int id, string title, int typeOfPosition)
        {
            Id = id;
            Title = title;
            TypeOfPositionId = typeOfPosition;
        }
    }
}
