using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.Exceptions
{
    public class BookDependencyValidationException : Exception
    {
        public BookDependencyValidationException(Exception innerException)
           : base("Book dependency validation error occurred, try again.", innerException) { }
    }
}
