using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WebAPIService.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TypeOfPositionId { get; set; }
    }
}
