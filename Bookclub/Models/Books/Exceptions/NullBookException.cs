using System;

namespace Bookclub.Models.Books.Exceptions
{
    public class NullBookException : Exception
    {
        public NullBookException() 
            : base("Null book error occurred.") { }
    
    }
}
