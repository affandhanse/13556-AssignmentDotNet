using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Exception
{
    internal class IdAlreadyExceptionException : ApplicationException
    {
        public IdAlreadyExceptionException()
        {

        }
        public IdAlreadyExceptionException(string message) : base(message)
        {
        }
    }
}