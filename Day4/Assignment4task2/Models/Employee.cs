using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4task2.Models
{
    internal class Employee
    {
        public String Name { get; set; }
        public double Salary { get; set; }

         public  Employee(string name,  double salary)
        {
            Name = name;
            Salary = salary;
        }
         public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee Details are ::");
            Console.WriteLine($"Employee Name :: {Name}\t Employee Salary :: {Salary}\n");
        }

    }
}
