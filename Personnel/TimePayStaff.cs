using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Personnel
{
    class TimePayStaff: BaseEmployee
    {
        public TimePayStaff(string surname, string name, string middleName, string position) : base(surname, name, middleName, position)
        {

        }
        public override double AverageMonthlySalary()
        {
            return 20.8 * 8 * 100 * Company.FactorPay(Position);
        }
    }
}
