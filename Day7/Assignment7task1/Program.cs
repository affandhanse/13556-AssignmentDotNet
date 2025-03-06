using Assignment7task1.Models;

namespace Assignment7task1
{
    internal class Program
    {
        static void Main(string[] args)
            {
                Employee employee = new Employee(13569, "Atharva Chaudhari", 23, new DateTime(2018, 01, 19));
                employee.calculateExperience();
            }
    }
}
