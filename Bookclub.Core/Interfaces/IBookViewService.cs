using Bookclub.Core.DomainAggregates;
using System;
using System.Threading.Tasks;

namespace Bookclub.Core.Interfaces
{
    public interface IBookViewService
    {
        ValueTask<BookView> AddBookViewAsync(BookView book);
        Task<BookResponse> GetAllBooks();
        Task<BookResponse> DeleteBookAsync(Guid bookId);
        Task<BookResponse> EditBookAsync(Book bookToEdit);
    }
}
