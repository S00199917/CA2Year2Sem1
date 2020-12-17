using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2Year2Sem1
{
    class PartTimeEmployee : Employee
    {
        //Properties
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        //Adds the properties to the object
        public PartTimeEmployee(string firstName, string surname, decimal hourlyRate, double hoursWorked) : base(firstName, surname)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        //Calculates the monthly pay of the employee
        public override decimal CalculateMonthlyPay()
        {
            return (decimal)((double)HourlyRate * HoursWorked);
        }

        //Used for displaying the object on the list box
        public override string ToString()
        {
            return string.Format($"{Surname.ToUpper()}, {FirstName} - Part Time");
        }
    }
}
