
using System.Threading.Channels;

namespace Assignement1Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            string studentName;
            int studentAge;
            double percentage;

            //student name
            Console.WriteLine("Enter the Student Name::");
            studentName = Console.ReadLine();

            //student age
            Console.WriteLine("Enter the Student Age::");
            bool result = int.TryParse(Console.ReadLine(), out studentAge);
            while (result != true)
            {

                Console.WriteLine("enter valid age");
                result = int.TryParse(Console.ReadLine(), out studentAge);
            
                if (result == true) break;
            }
            //student percentage
            Console.WriteLine("Enter the Student Percentage::");
            percentage = Convert.ToDouble(Console.ReadLine());

            //output student detail
            Console.WriteLine($"Student name is :: {studentName} Student age is :: {studentAge} student percentage is :: {percentage}");


            //student email address
            string studentEmail;
            Console.WriteLine("Enter Student Email Address::");
            studentEmail = Console.ReadLine();
            
            while(studentEmail == "")
            {
                Console.WriteLine("Enter a valid Email Id ::");
                studentEmail = Console.ReadLine();
                if (studentEmail != "") break;
            }

            //patient discharge date
            DateTime? dischargeDate = null; ;
            Console.WriteLine("Enter Discharge date::");
            dischargeDate = DateTime.Parse(Console.ReadLine());

            if (dischargeDate.HasValue)
            {
                Console.WriteLine($"Your Patient is Discharged on :: {dischargeDate} ");
            }
            else
            {
                Console.WriteLine("Patient is not Discharged");
            }
        }
    }
}
