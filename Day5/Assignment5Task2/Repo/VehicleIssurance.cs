using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Task2.Repo
{
    abstract class VehicleInsurance
    {
        public string VehicleInsurType { get; set; }

        public double VehicleInsurValue { get; set; }

        public VehicleInsurance(string vehicleInsurType, double vehicleInsurValue)
        {
            if (vehicleInsurValue <= 0)
            {
                throw new ArgumentException("Insured value should be greater than 0");
            }

            this.VehicleInsurType = vehicleInsurType;
            this.VehicleInsurValue = vehicleInsurValue;
        }

        public abstract double GetinsurancePremiumCalculation();
    }
}
