using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double ProductPrice { get; set; }

        public Product()
        {

        }
        public Product(int id, string name, string category, double price)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
            ProductPrice = price;
        }

    }
}