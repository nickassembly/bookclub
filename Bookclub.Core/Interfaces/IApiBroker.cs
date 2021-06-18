using Bookclub.Core.DomainAggregates;
using System;
using System.Threading.Tasks;

namespace Bookclub.Core.Interfaces
{
    public partial interface IApiBroker
    {
        Task<BookResponse> GetAllBooks();
        Task<BookResponse> PostBookAsync(Book book);
        Task<BookResponse> DeleteBookAsync(Guid bookId);
        Task<BookResponse> EditBookAsync(Book book);
    }
}
