using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Task1.ExceptionFiles
{
    internal class AccountDetailsException : ApplicationException
    {
        public AccountDetailsException(string message) : base(message)
        {

        }
    }
}
