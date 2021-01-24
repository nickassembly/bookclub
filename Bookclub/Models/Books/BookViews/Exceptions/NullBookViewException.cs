using System;

namespace Bookclub.Models.Books.BookViews.Exceptions
{
    public class NullBookViewException : Exception
    {
        public NullBookViewException()
            : base("Null book error occurred.") { }
    }
}
