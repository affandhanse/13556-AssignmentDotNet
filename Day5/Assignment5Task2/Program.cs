using Assignment5Task2.Models;
using Assignment5Task2.Repo;

namespace Assignment5Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Select Vehicle Type::\n 1: Two-Wheeler\n 2: Four-Wheeler\n 3: Commercial\n ");
                int choice = int.Parse(Console.ReadLine());

                Console.Write("Enter Insured Value:: ");
                double insuredValue = double.Parse(Console.ReadLine());

                VehicleInsurance policy;

                switch (choice)
                {
                    case 1:
                        policy = new TwoWheeler("Two-Wheeler", insuredValue);
                        break;
                    case 2:
                        policy = new FourWheeler("Four-Wheeler", insuredValue);
                        break;
                    case 3:
                        policy = new CommercialVehicle("Commercial", insuredValue);
                        break;
                    default:
                        throw new ArgumentException("Invalid vehicle type selected.");
                }

                Console.WriteLine($"\nVehicle Type: {policy.VehicleInsurType}");
                Console.WriteLine($"Insured Value: {policy.VehicleInsurValue}");
                Console.WriteLine($"Calculated Premium: {policy.GetinsurancePremiumCalculation()}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Error: Please enter a valid numeric value.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Insurance premium calculation process completed.");
            }
        }
    }
}
