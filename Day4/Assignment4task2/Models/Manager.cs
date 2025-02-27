﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4task2.Models
{
    internal class Manager:Employee
    {
        public double Bonus { get; set; }

        public  Manager(string name, double salary, double bonus) : base(name, salary)
        {
            Bonus = bonus;
        }

        public override void  DisplayDetails()
        {
            Console.WriteLine($"Manager Details are ::");
            Console.WriteLine($"Manager Name :: {Name}\t Manager Salary :: {Salary}");
            Console.WriteLine($"Manager Bonus is :: {Bonus}\n");
        }
    }
}
