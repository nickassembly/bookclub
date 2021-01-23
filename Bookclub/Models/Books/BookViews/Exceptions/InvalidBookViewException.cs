using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.BookViews.Exceptions
{
    public class InvalidBookViewException : Exception
    {
        public InvalidBookViewException(string parameterName, string parameterValue)
            :base ($"Invalid Book View error occured." +
                 $"parameter name: {parameterName}" + $"parameter value: {parameterValue}" ) { }
    }
}
