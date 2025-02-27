using Assignment4task2.Models;

namespace Assignment4task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee newEmp = new Employee("affan", 20000);
            newEmp.DisplayDetails();

            Manager newManager = new Manager("Atharv", 2500000, 200000);
            newManager.DisplayDetails();


            Employee newEmp2 = new Manager("Pranit", 200000, 10000);
            newEmp2.DisplayDetails();

            //Manager newManager2 = (Manager)new Employee("Pratik", 200000);
            //newManager2.DisplayDetails();
        }

    }
}
