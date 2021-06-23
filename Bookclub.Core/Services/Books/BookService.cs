using Bookclub.Core.DomainAggregates;
using Bookclub.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Bookclub.Core.Services.Books
{
    public partial class BookService : IBookService
    {
        // TODO: Refactor out Api broker
        private readonly IApiBroker _apiBroker;
        private readonly ILoggingBroker _loggingBroker;

        public BookService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
        {
            _apiBroker = apiBroker;
            _loggingBroker = loggingBroker;
        }

        public async Task<BookResponse> GetAllBooks()
        {
            return await _apiBroker.GetAllBooks();
        }

        public async Task<BookResponse> AddBookAsync(Book book)
        {
            // TODO: Add Book Validation ...service? (back end validation)
            return await _apiBroker.PostBookAsync(book);
        }

        public async Task<BookResponse> EditBookAsync(Book book)
        {
            return await _apiBroker.EditBookAsync(book);
        }

        public async Task<BookResponse> DeleteBookAsync(Guid bookId)
        {
           return await _apiBroker.DeleteBookAsync(bookId);
        }
    }
}
