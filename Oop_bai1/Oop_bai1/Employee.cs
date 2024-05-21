using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop_bai1
{
    public abstract class Employee : IEmployee
    {
        protected string name;
        protected int paymentPerHour;

        public Employee(string name, int paymentPerHour)
        {
            this.name = name;
            this.paymentPerHour = paymentPerHour;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetPaymentPerHour(int paymentPerHour)
        {
            this.paymentPerHour = paymentPerHour;
        }

        public int GetPaymentPerHour()
        {
            return paymentPerHour;
        }

        public abstract int CalculateSalary();

        public override string ToString()
        {
            return $"Employee [name={name}, paymentPerHour={paymentPerHour}]";
        }
    }

}
