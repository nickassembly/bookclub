using Bookclub.Brokers.DateTimes;
using Bookclub.Brokers.Logging;
using Bookclub.Models.Books.BookViews;
using Bookclub.Services.Books;
using Bookclub.Services.Users;
using System;
using System.Threading.Tasks;

namespace Bookclub.Services.BookViews
{
    public class BookViewService : IBookViewService
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IDateTimeBroker _dateTimeBroker;
        private readonly ILoggingBroker _loggingBroker;

        public BookViewService(
            IBookService bookService,
            IUserService userService, 
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            _bookService = bookService;
            _userService = userService;
            _dateTimeBroker = dateTimeBroker;
            _loggingBroker = loggingBroker;
        }

        public ValueTask<BookView> AddBookViewAsync(BookView book)
        {
            throw new NotImplementedException();
        }
    }
}
