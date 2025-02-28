using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5Task1.ExceptionFiles;
using Assignment5Task1.Models;

namespace Assignment5Task1.Repo
{
    internal class BankRepo : IbankRepo
    {
        List<AccountDetails> accounts = new List<AccountDetails> { new AccountDetails { Name = "Affan", AccNum = 9967113376 }, new AccountDetails { Name = "Atharva", AccNum = 9877635242 } };

        public AccountDetails SearchAccountNumber(long number)
        {
            return accounts.Find(num => num.AccNum == number);
        }
        public bool AddAccount(AccountDetails account)
        {
            try
            {
                if (account.AccNum > 999999999)
                {
                    AccountDetails search = SearchAccountNumber(account.AccNum);
                    if (search == null)
                    {
                        accounts.Add(account);
                        return true;
                    }
                    else
                    {
                        throw new AccountDetailsException("Account Already Exists");
                    }

                }
                else
                {
                    throw new AccountDetailsException("Account Nuber Invalid");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<AccountDetails> GetAccountDetails()
        {
            return accounts;
        }



    }
}
