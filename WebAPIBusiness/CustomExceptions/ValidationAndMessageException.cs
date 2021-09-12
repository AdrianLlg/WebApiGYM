using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIBusiness.CustomExceptions
{
    /// <summary>
    /// Custom Exception
    /// </summary>
    public class ValidationAndMessageException : Exception
    {
        public ValidationAndMessageException()
        {
        }

        public ValidationAndMessageException(string message)
            : base(message)
        {
        }

        public ValidationAndMessageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
