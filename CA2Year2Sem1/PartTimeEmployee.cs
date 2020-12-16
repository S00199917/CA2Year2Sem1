using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2Year2Sem1
{
    class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public PartTimeEmployee(string firstName, string surname, decimal hourlyRate, double hoursWorked) : base(firstName, surname)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override decimal CalculateMonthlyPay()
        {
            return (decimal)((double)HourlyRate * HoursWorked);
        }
        public override string ToString()
        {
            return string.Format($"{Surname.ToUpper()}, {FirstName} - Part Time");
        }
    }
}
