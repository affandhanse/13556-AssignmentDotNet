using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Task1.Models
{
    interface IbankRepo
    {
        public bool AddAccount(AccountDetails account);
        AccountDetails SearchAccountNumber(long number);

        public List<AccountDetails> GetAccountDetails();
    }
}
