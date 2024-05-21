using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop_bai1
{
    public class FullTimeEmployee : Employee
    {
        private const int WORKING_HOURS = 8;

        public FullTimeEmployee(string name, int paymentPerHour)
            : base(name, paymentPerHour)
        {
        }

        public override int CalculateSalary()
        {
            return WORKING_HOURS * paymentPerHour;
        }

        public override string ToString()
        {
            return $"FullTimeEmployee [name={name}, paymentPerHour={paymentPerHour}, salary={CalculateSalary()}]";
        }
    }

}
