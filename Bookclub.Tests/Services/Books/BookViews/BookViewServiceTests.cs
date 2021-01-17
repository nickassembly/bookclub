using Bookclub.Brokers.DateTimes;
using Bookclub.Brokers.Logging;
using Bookclub.Services.BookViews;
using Bookclub.Services.Users;
using Moq;

namespace Bookclub.Tests.Services.Books.BookViews
{
    public partial class BookViewServiceTests
    {
        private readonly Mock<IBookViewService> bookService;
        private readonly Mock<IUserService> userService;
        private readonly Mock<IDateTimeBroker> dateTimeBroker;
        private readonly Mock<ILoggingBroker> loggingBroker;
    }
}
