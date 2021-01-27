using System;

namespace Bookclub.Models.Books.BookViews.Exceptions
{
    public class BookViewDependencyException : Exception
    {
        public BookViewDependencyException(Exception innerException)
            : base("Book view dependency error occurred, contact support.", innerException) { }
    }
}
