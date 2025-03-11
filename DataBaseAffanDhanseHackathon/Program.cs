using System.Data.SqlClient;
using AffanDhanseHackathon.Models;
using AffanDhanseHackathon.Repo;

namespace AffanDhanseHackathon
{
    internal class Program
    {
        private static int nextPolicyID = 4;
        private static IPolicyRepo policyRepo = new PolicyRepo();

        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine(".....................Welcome to Policy Management System............................");
                Console.WriteLine("\n1.Add Policy\n2.Update Policy\n3.Delete Policy\n4.View All Policies\n5.View Active Policies\n6.Search Policy By ID\n7.Exit");
                Console.WriteLine("\nSelect Your Option");
                int choice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Policy Holder Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Policy Type (Life, Health, Vehicle, Property): ");
                            PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);

                            DateTime startDate = DateTime.Now;
                            Console.Write("Enter End Date (yyyy-MM-dd): ");
                            DateTime endDate = DateTime.Parse(Console.ReadLine());

                            int policyID = nextPolicyID++; 

                            PolicyDetails newPolicy = new PolicyDetails(policyID, name, type, startDate, endDate);

                            policyRepo.AddPolicy(newPolicy);

                            Console.WriteLine($"Policy added successfully with ID {policyID}.");
                            break;
                        case 2:
                        //UpdatePolicyDetails(); 
                            Console.Write("Enter Policy ID to update: ");
                            int updatePolicyId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter New Policy Holder Name: ");
                            string updateName = Console.ReadLine();

                            Console.Write("Enter New Policy Type (Life, Health, Vehicle, Property): ");
                            PolicyType updateType = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);

                            DateTime updateStartDate = DateTime.Now;

                            Console.Write("Enter New End Date (yyyy-MM-dd): ");
                            DateTime updateEndDate = DateTime.Parse(Console.ReadLine());

                            PolicyDetails updatedPolicy = new PolicyDetails(updatePolicyId, updateName, updateType, updateStartDate, updateEndDate);

                            try
                            {
                                policyRepo.UpdatePolicy(updatePolicyId, updatedPolicy);
                                Console.WriteLine($"Policy with ID {updatePolicyId} updated successfully.");
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine($"Database Error: {ex.Message}");
                            }
                            catch (PolicyNotFoundException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                            break;
                        case 3:
                        //DeletePolicy(); 
                            Console.Write("Enter Policy ID to delete: ");
                            int deletePolicyId = Convert.ToInt32(Console.ReadLine());

                            try
                            {
                                policyRepo.DeletePolicy(deletePolicyId);
                                Console.WriteLine($"Policy with ID {deletePolicyId} deleted successfully.");
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine($"Database Error: {ex.Message}");
                            }
                            catch (PolicyNotFoundException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                            break;
                        case 4:
                            List<PolicyDetails> allPolicies = policyRepo.GetAllPolicy();
                            foreach(var item in allPolicies)
                            {
                                Console.Write(item);
                            }
                            break;
                        case 5:
                            //ViewActivePolicies(); 
                            break;
                        case 6:
                            //SearchPolicyByID(); 
                            break;
                        case 7:
                            exit = true;
                            Console.WriteLine("Exiting console...................");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                finally
                {
                    Console.WriteLine("\n..........Task successfully executed");
                }
            }
        }

        //static void AddPolicy()
        //{
        //    Console.Write("Enter Policy Holder Name:: ");
        //    string name = Console.ReadLine();

        //    Console.Write("Enter Policy Type::\nChoose one of the options :: Life, Health, Vehicle, Property: ");
        //    PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);

        //    //Console.Write("Enter Start Date (yyyy-MM-dd):: ");
        //    //DateTime startDate = DateTime.Parse(Console.ReadLine());
        //    DateTime startDate = DateTime.Now;

        //    Console.Write("Enter End Date (yyyy-MM-dd):: ");
        //    DateTime endDate = DateTime.Parse(Console.ReadLine());

        //    int policyID = nextPolicyID++;

        //    PolicyDetails newPolicy = new PolicyDetails(policyID, name, type, startDate, endDate);

        //    policyRepo.AddPolicy(newPolicy);

        //    Console.WriteLine($"Policy added successfully with ID {policyID}.");
        //}

        //static void ViewAllPolicies()
        //{
        //    var policies = policyRepo.GetAllPolicy();
        //    if (policies.Count == 0)
        //    {
        //        Console.WriteLine("No policies available.");
        //        return;
        //    }
        //    foreach (var policy in policies)
        //    {
        //        Console.WriteLine(policy);
        //    }
        //}

        //static void SearchPolicyByID()
        //{
        //    Console.Write("Enter Policy ID to search: ");
        //    int policyID = int.Parse(Console.ReadLine());

        //    var policy = policyRepo.SearchPolicyById(policyID);
        //    Console.WriteLine(policy);
        //}

        //static void UpdatePolicyDetails()
        //{
        //    var policies1 = policyRepo.GetAllPolicy();
        //    if (policies1 != null)
        //    {
        //        Console.Write("Enter Policy ID to update: ");
        //        int policyId = int.Parse(Console.ReadLine());

        //        Console.Write("Enter New Policy Holder Name: ");
        //        string name = Console.ReadLine();

        //        Console.Write("Enter New Policy Type (Life, Health, Vehicle, Property): ");
        //        PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);

        //        //Console.Write("Enter New Start Date (yyyy-MM-dd): ");
        //        //DateTime startDate = DateTime.Parse(Console.ReadLine());
        //        DateTime startDate = DateTime.Now;

        //        Console.Write("Enter New End Date (yyyy-MM-dd): ");
        //        DateTime endDate = DateTime.Parse(Console.ReadLine());

        //        PolicyDetails updatedPolicy = new PolicyDetails(policyId, name, type, startDate, endDate);

        //        policyRepo.UpdatePolicy(policyId, updatedPolicy);
        //        Console.WriteLine("Policy updated successfully.");
        //    }
        //    else
        //    {
        //        ViewActivePolicies();
        //    }
        //}

        //private static void DeletePolicy()
        //{
        //    Console.Write("Enter Policy ID to delete: ");
        //    int policyID = int.Parse(Console.ReadLine());
            
        //    policyRepo.DeletePolicy(policyID);
        //    Console.WriteLine("Policy deleted successfully.");
        //}

        //private static void ViewActivePolicies()
        //{
        //    var activePolicies = policyRepo.GetActivePolicy();
        //    if (activePolicies.Count == 0)
        //    {
        //        Console.WriteLine("No active policies.");
        //        return;
        //    }
        //    foreach (var policy in activePolicies)
        //    {
        //        Console.WriteLine(policy);
        //    }
        //}
    }
}
