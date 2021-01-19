using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Position
    {
        public string Position_ { get; set; }
        public double FactorPay { get; set; }
        public Position(string position, double factorPay)
        {
            Position_ = position;
            FactorPay = factorPay;
        }
        
    }
}
