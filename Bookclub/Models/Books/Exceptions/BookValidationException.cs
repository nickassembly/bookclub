using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.Exceptions
{
    public class BookValidationException : Exception
    {
        public BookValidationException(Exception innerException)
            :base ("Book validation error occurred.", innerException) { }
    }
}
