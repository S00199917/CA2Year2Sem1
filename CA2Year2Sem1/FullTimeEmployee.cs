using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2Year2Sem1
{
    class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public FullTimeEmployee(string firstName, string surname, decimal salary) : base(firstName, surname)
        {
            Salary = salary;
        }

        public override decimal CalculateMonthlyPay()
        {
            return (Salary / 12);
        }

        public override string ToString()
        {
            return string.Format($"{Surname.ToUpper()}, {FirstName} - Full Time");
        }
    }
}
