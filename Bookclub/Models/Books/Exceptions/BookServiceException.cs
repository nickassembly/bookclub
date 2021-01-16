using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.Exceptions
{
    public class BookServiceException : Exception
    {
        public BookServiceException(Exception innerException)
            :base ("Book service error occurred, contact support", innerException) { }
    }
}
