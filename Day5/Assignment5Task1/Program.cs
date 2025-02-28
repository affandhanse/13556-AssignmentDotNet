using System.Security.Cryptography.X509Certificates;
using Assignment5Task1.Models;
using Assignment5Task1.Repo;

namespace Assignment5Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Acoount Holder Name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter account number");
            long userAccNum = Convert.ToInt64(Console.ReadLine());


            IbankRepo repo = new BankRepo();
            AccountDetails account3 = new AccountDetails()
            {
                AccNum = userAccNum,
                Name = userName
            };


            bool result = repo.AddAccount(account3);
            if (result)
            {
                Console.WriteLine("Account Added Successfully");
            }
            List<AccountDetails> allAccounts = repo.GetAccountDetails();

            foreach(AccountDetails account in allAccounts)
            {
                Console.WriteLine($"All account details\n Account name:: {account.Name}\t Account Number ::{account.AccNum}");
            }
        }
    }
}
