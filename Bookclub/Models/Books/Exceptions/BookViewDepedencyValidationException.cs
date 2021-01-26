using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.Exceptions
{
    public class BookViewDependencyValidationException : Exception
    {
        public BookViewDependencyValidationException(Exception innerException)
            : base("Book view dependency error occurred, try again.", innerException) { }
    }
}
