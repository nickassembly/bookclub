using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.Exceptions
{
    public class InvalidBookException : Exception
    {
        public InvalidBookException(string parameterName, string parameterValue)
            :base("Invalid Book error occurred," +
                 $"parameter name: {parameterName}" +
                 $"parameter value: {parameterValue}")
        { }
    }
}
