using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7task1.Models
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmployeeAge { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime currentDate = DateTime.Now;
        int experience;
        int totalMonth;


        public Employee(int empId, string name, int age, DateTime dateTime)
        {
            this.EmpId = empId;
            this.EmpName = name;
            this.EmployeeAge = age;
            this.JoiningDate = dateTime;
        }

        public void calculateExperience()
        {
            int joinYear = JoiningDate.Year;
            int currentYear = currentDate.Year;
            experience = currentYear - joinYear;

            if (JoiningDate.Month > currentDate.Month)
            {
                experience--;
            }
            totalMonth = currentDate.Month - JoiningDate.Month;
            if (currentDate.Day < JoiningDate.Day)
            {
                totalMonth--;
            }


            if (totalMonth < 0)
            {
                totalMonth = 12 + totalMonth;
            }




            Console.WriteLine($"{experience} year and {totalMonth} months of experience ");



        }
    }
}
