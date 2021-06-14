using Bookclub.Core.DomainAggregates;
using System;
using System.Threading.Tasks;

namespace Bookclub.Services.Books
{
    public interface IBookService
    {
        Task<BookResponse> GetAllBooks();
        Task<BookResponse> AddBookAsync(Book book);
        Task<BookResponse> DeleteBookAsync(Guid bookId);
        Task<BookResponse> EditBookAsync(Book book);
    }
}
