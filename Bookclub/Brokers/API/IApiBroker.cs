using Bookclub.Models.Books;
using Bookclub.Services.Books;
using System;
using System.Threading.Tasks;

namespace Bookclub.Brokers.API
{
    public partial interface IApiBroker
    {
        Task<BookResponse> PostBookAsync(Book book);
        Task<BookResponse> DeleteBookAsync(Guid bookId);
        Task<BookResponse> EditBookAsync(Book book);
    }
}
