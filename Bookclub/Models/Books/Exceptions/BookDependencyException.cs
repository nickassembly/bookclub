using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.Exceptions
{
    public class BookDependencyException : Exception
    {
        public BookDependencyException(Exception innerException)
            :base ("Book dependency error occurred, contact support.", innerException)
        {

        }
    }
}
