using Bookclub.Brokers.DateTimes;
using Bookclub.Brokers.Logging;
using Bookclub.Models.Books.BookViews;
using Bookclub.Services.Users;
using System;
using System.Threading.Tasks;

namespace Bookclub.Services.BookViews
{
    public class BookViewService : IBookViewService
    {
        private readonly ILoggingBroker _bookViewService;
        private readonly IUserService _userService;
        private readonly IDateTimeBroker _dateTimeBroker;
        private readonly Brokers.Logging.ILoggingBroker _loggingBroker;

        public BookViewService(
            ILoggingBroker bookViewService,
            IUserService userService, 
            IDateTimeBroker dateTimeBroker,
            Brokers.Logging.ILoggingBroker loggingBroker)
        {
            _bookViewService = bookViewService;
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
