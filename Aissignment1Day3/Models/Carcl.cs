




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aissignment1Day3
{
    internal class Carcl
    {
        int carId;
        string carBrand;
        string carModel;
        int manufacturingYear;
        double carPrice;

        //public Getter and Setter
        public int CarId
        {
            get { return carId; }
            set { carId = value; }
        }
        public string CarBrand
        {
            get { return carBrand; }
            set { carBrand = value; }
        }
        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }
        public int ManufacturingYear
        {
            get { return manufacturingYear; }
            set { manufacturingYear = value; }
        }
        public double CarPrice
        {
            get { return carPrice; }
            set { carPrice = value; }
        }





        #region Task2
        public Carcl(int carId, string carBrand, string carModel, int manufacturingYear, double carPrice)
        {
            Console.WriteLine("Receiving Car Information");
            this.carId = carId;
            this.carBrand = carBrand;
            this.carModel = carModel;
            this.manufacturingYear = manufacturingYear;
            this.carPrice = carPrice;

        }
        public Carcl() : this(0, "Unknown", "Unknown", 2000, 0.0)
        {
            Console.WriteLine("default Car Details");
        }


        #endregion





        public void addCarDetails()
        {
            Console.WriteLine("Enter car Dtails:");
            Console.WriteLine("Enter car Id:");
            carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter car Brand:");
            carBrand = Console.ReadLine();

            Console.WriteLine("Enter car Model");
            carModel = Console.ReadLine();

            Console.WriteLine("Enter car Year");
            manufacturingYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter car Price");
            carPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Received Car Information");


        }

        public void displyCarDetails()
        {
            Console.WriteLine("Car Details");
            Console.WriteLine($"CarId:{carId}\nCar Brand:{carBrand}\nCar Model:{carModel}\nYear:{manufacturingYear}\nPrice:{carPrice}");
        }

    }

}



