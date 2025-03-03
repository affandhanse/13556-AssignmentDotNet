using System;
using System.Collections.Generic;
using Assignment6Task1.Models;

namespace Assignment6Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> CustomerLine = new Queue<string>();
            CustomerLine.Enqueue("Pranit");
            CustomerLine.Enqueue("Atharva");
            CustomerLine.Enqueue("Pratik");
            CustomerLine.Enqueue("Sanchita");

            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();
            CustomerManager.Add(CustomerLine, customerName);

            Console.WriteLine("Do you want to serve a customer? (yes/no)");
            string serveResponse = Console.ReadLine();
            if (serveResponse.ToLower() == "yes")
            {
                CustomerManager.ServeCus(CustomerLine);
            }

            Console.WriteLine(CustomerManager.NextCus(CustomerLine));
        }
    }
}
