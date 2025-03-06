using Task2.Models;
namespace Assignment7task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Product product1= new Product();
            //List<Product> products = new List<Product>();
            List<Product> Products = new List<Product>()
        {
            new Product(1,"TV","Electronic",30000.50d),
            new Product(2,"T-Shirt","Cloth",2000.20d),
            new Product(3,"SIM-Card","Electronic",500.75d),
            new Product(4,"Milk","Grocery",22.65d),
            new Product(5,"IPhone","Electronic",150000.40d)
        };

            #region Task 2
            //var updateCategory =
            //    from product in Products
            //    where product.Category== "Electronic" && product.ProductPrice>1000
            //    select product;
            //foreach (var item in updateCategory)
            //{

            //    Console.WriteLine($"Product Id::{item.ProductId}\tProduct name::{item.ProductName}\tProduct Price::{item.ProductPrice} ");

            //}

            //var methodSyntax = Products.Where(p => p.Category == "Electronic" && p.ProductPrice < 1000);
            //foreach (var item in methodSyntax)
            //{

            //    Console.WriteLine($"Product Id::{item.ProductId}\tProduct name::{item.ProductName}\tProduct Price::{item.ProductPrice} ");
            //}
            #endregion
            #region Task 3
            //var mostExpensive=from product in Products
            //                  orderby product.ProductPrice descending
            //                  select product ;


            var mostExpensive = Products.OrderByDescending(p => p.ProductPrice).Take(1);

            foreach (var item in mostExpensive)
            {

                Console.WriteLine($"Product Id::{item.ProductId}\tProduct name::{item.ProductName}\tProduct Price::{item.ProductPrice} ");

            }

            #endregion
        }
    }
}