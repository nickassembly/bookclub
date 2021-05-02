using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
using Bookclub.Services.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services.BookViews
{
    public interface IBookViewService
    {
        ValueTask<BookView> AddBookViewAsync(BookView book);
        Task<BookResponse> DeleteBookAsync(Guid bookId);
    }
}
