using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4task1.Models
{
    internal class Users
    {
        static int num = 0;
        public Users()
        {
            num = num + 1;
            Console.WriteLine($"User has logged In.........");
        }
        public static void UserCount()
        {
            Console.WriteLine($"User Count is :: {num}");
        }
    }
}
