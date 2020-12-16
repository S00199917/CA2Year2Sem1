using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2Year2Sem1
{
    public abstract class Employee : IComparable
    {
        //Properties
        public string FirstName { get; set; }
        public string Surname { get; set; }

        //Assings the properties to the object
        public Employee(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        //Used to compare
        public int CompareTo(object obj)
        {
            int returnValue;
            //Get a reference to the next object in the list/array/collection
            Employee that = (Employee)obj;

            //Indicate what field I want to compare
            if (this.Surname == that.Surname)
                returnValue = this.FirstName.CompareTo(that.FirstName);
            else
                returnValue = this.Surname.CompareTo(that.Surname);

            //return
            return returnValue;
        }

        public abstract decimal CalculateMonthlyPay();
    }
}
