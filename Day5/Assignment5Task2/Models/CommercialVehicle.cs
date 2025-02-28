using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5Task2.Repo;

namespace Assignment5Task2.Models
{
    internal class CommercialVehicle:VehicleInsurance
    {
        public CommercialVehicle(string VehincleInsuranceType, double VehicleInsuranceValue) : base(VehincleInsuranceType, VehicleInsuranceValue) { }
        public override double GetinsurancePremiumCalculation()
        {
            return VehicleInsurValue * 0.05;
        }
    }
}
