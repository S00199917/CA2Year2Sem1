using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2Year2Sem1
{
    class FullTimeEmployee : Employee
    {
        //Properties
        public decimal Salary { get; set; }

        //Adds the properties to the object
        public FullTimeEmployee(string firstName, string surname, decimal salary) : base(firstName, surname)
        {
            Salary = salary;
        }

        //Calculates the monthly pay of the object
        public override decimal CalculateMonthlyPay()
        {
            return (Salary / 12);
        }

        //Used for displaying the object on the list box
        public override string ToString()
        {
            return string.Format($"{Surname.ToUpper()}, {FirstName} - Full Time");
        }
    }
}
