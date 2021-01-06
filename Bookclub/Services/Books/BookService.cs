using Bookclub.Brokers.API;
using Bookclub.Brokers.Logging;
using Bookclub.Models.Books;
using System;
using System.Threading.Tasks;

namespace Bookclub.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IApiBroker _apiBroker;
        private readonly ILoggingBroker _loggingBroker;

        public BookService(IApiBroker apiBroker, ILoggingBroker loggingBroker)
        {
            _apiBroker = apiBroker;
            _loggingBroker = loggingBroker;
        }

        public ValueTask<Book> AddBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
