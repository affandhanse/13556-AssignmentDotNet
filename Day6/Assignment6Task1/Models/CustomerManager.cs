using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6Task1.Models
{
    internal class CustomerManager
    {
            public static void Add(Queue<string> CustomerLine, string customerName)
            {
                CustomerLine.Enqueue(customerName);
                Console.WriteLine($"{customerName} has been added.");
            }

            public static void ServeCus(Queue<string> CustomerLine)
            {
                if (CustomerLine.Count > 0)
                {
                    string served = CustomerLine.Dequeue();
                    Console.WriteLine($"{served} - has been served.");
                }
                else
                {
                    Console.WriteLine("No customer in line.");
                }
            }

            public static string NextCus(Queue<string> CustomerLine)
            {
                if (CustomerLine.Count > 0)
                {
                    return $"Next customer is: {CustomerLine.Peek()}";
                }
                else
                {
                    return "No customer in line.";
                }
            }
        }
    }
