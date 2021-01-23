using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.BookViews.Exceptions
{
    public class BookViewValidationException : Exception
    {
        public BookViewValidationException(Exception innerException)
            : base($"Book view validation error occurred, try again.", innerException) { }
    }
}
