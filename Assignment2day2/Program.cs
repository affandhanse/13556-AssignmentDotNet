namespace Assignment2day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //salary calculation Question 1.

            #region Salary
            double salary;
            int rating;
            double tax;

            Console.WriteLine("Enter the employee salary : ");
            salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter employee rating...");
            rating = Convert.ToInt32(Console.ReadLine());

            tax = salary * 0.10;
            double netSalary = salary - tax;
            Console.WriteLine($"Employee salary is :: {netSalary}");

            if (rating >= 8)
            {
                netSalary = netSalary + netSalary * 0.20;
                Console.WriteLine($"Employee salary with bonus:: {netSalary}");
            }
            else if (rating >= 5 && rating < 8)
            {
                netSalary = netSalary + netSalary * 0.10;
                Console.WriteLine($"Employee salary with bonus:: {netSalary}");
            }
            else
            {
                Console.WriteLine($"No bonus salary is {netSalary} ");
            }
            #endregion


            //ticket booking Question 2
            #region ticket booking
            int number;
            Console.WriteLine("Menu select the type of ticket::\n1.General\t 200rs\n2.Sleeper\t 500rs\n3.AC\t\t1000rs\n4. Exit \n Choose one option.");
            number = Convert.ToInt32(Console.ReadLine());
            int generalTicketNum = 0;
            int ACTicketNum = 0;
            int sleeperTicketNum = 0;

            while (number != 4)
            {
                switch (number)
                {
                    case 1:
                        Console.WriteLine("you have selected one general ticket.");
                        generalTicketNum += 1;
                        break;
                    case 2:
                        Console.WriteLine("you have selected one sleeper ticket.");
                        sleeperTicketNum += 1;
                        break;
                    case 3:
                        Console.WriteLine("you have selected one AC ticket.");
                        ACTicketNum += 1;
                        break;
                    default:
                        Console.WriteLine("You have choosen a invaled choose kindly choose again............... ");
                        break;
                }
                Console.WriteLine("Menu select the type of ticket::\n1.General\t 200rs\n2.Sleeper\t 500rs\n3.AC\t\t1000rs\n4. Exit \n Choose one option.");
                number = Convert.ToInt32(Console.ReadLine());
            }
            double totalPrice = (generalTicketNum * 200) + (sleeperTicketNum * 500) + (ACTicketNum * 1000);
            Console.WriteLine($"You have choosen Total general tickets:: {generalTicketNum}");
            Console.WriteLine($"You have choosen Total sleeper tickets:: {sleeperTicketNum}");
            Console.WriteLine($"You have choosen Total AC tickets:: {ACTicketNum}\n");
            Console.WriteLine($"Your Total Amount is :: {totalPrice}");

            #endregion


            //Question 3 Wallet 
            #region Wallet

            double[,] userData =
            {
                { 101, 500.75 },
                { 102, 1200.50 },
                { 103, 300.00 },
                { 104, 750.25 },
                { 105, 950.00 }
            };

            bool validUser = true;
            int userId;

            Console.WriteLine("Welcome to the Online Shopping Wallet System!");

            Console.WriteLine("Enter User Id::");
            userId = Convert.ToInt32(Console.ReadLine());
            while (validUser)
            {
                for (int i = 0;i< userData.GetLength(0); i++)
                {
                    if(userData[i,0] == userId)
                    {
                        validUser = false;
                        Console.WriteLine($"Wallet Balance:{userData[i,1]}");
                        break;
                    }
                }
                if (validUser)
                {
                    Console.WriteLine("Invalid user.");
                    break;
                }
             
            }

            #endregion
        }
    }
}
