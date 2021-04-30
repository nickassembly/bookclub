using Bookclub.Models.Books;
using Bookclub.Services.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Brokers.API
{
    public partial interface IApiBroker
    {
        Task<Book> PostBookAsync(Book book);
        Task<BookResponse> PostBookAsync2(Book book);
    }
}
