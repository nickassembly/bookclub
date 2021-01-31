using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.AddBookComponents.Exceptions
{
    public class AddBookComponentException : Exception
    {
        public AddBookComponentException(Exception innerException)
            : base ("Error occurred, contact support", innerException) { }
    }
}
