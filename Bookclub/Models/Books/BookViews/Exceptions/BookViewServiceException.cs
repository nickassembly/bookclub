using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.BookViews.Exceptions
{
    public class BookViewServiceException : Exception
    {
        public BookViewServiceException(Exception innerException)
            :base ("Book view service error occured, contact support.", innerException){ }
    }
}
