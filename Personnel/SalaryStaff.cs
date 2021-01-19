using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class SalaryStaff: BaseEmployee
    {
        public SalaryStaff(string surname, string name, string middleName, string position) : base(surname, name, middleName, position)
        {

        }
        public override double AverageMonthlySalary()
        {
            return 20000 * Company.FactorPay(Position);
        }
    }
}
