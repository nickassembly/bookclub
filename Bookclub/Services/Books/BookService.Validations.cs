using Bookclub.Models.Books;
using Bookclub.Models.Books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services.Books
{
    public partial class BookService
    {
        private void ValidateBook(Book book)
        {
            if(book is null)
            {
                throw new NullBookException();
            }
        }

    }
}
