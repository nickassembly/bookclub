using Bookclub.Brokers.DateTimes;
using Bookclub.Brokers.Logging;
using Bookclub.Services.BookViews;
using Bookclub.Services.Users;
using Moq;
using System;
using Tynamix.ObjectFiller;

namespace Bookclub.Tests.Services.Books.BookViews
{
    public partial class BookViewServiceTests
    {
        private readonly Mock<IBookViewService> _bookServiceMock;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IDateTimeBroker> _dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> _loggingBrokerMock;
        private readonly IBookViewService bookViewService;

        public BookViewServiceTests(
            Mock<IBookViewService> bookServiceMock,
            Mock<IUserService> userServiceMock,
            Mock<IDateTimeBroker> dateTimeBrokerMock,
            Mock<ILoggingBroker> loggingBrokerMock)
        {
            _bookServiceMock = bookServiceMock;
            _userServiceMock = userServiceMock;
            _dateTimeBrokerMock = dateTimeBrokerMock;
            _loggingBrokerMock = loggingBrokerMock;

            this.bookViewService = new BookViewService(
               bookService: _bookServiceMock.Object,
               userService: _userServiceMock.Object,
               dateTimeBroker: _dateTimeBrokerMock.Object,
               loggingBroker: _loggingBrokerMock.Object);
        }

        // Todo: Get better filler strings for title/etc. 
        private static dynamic CreateRandomStudentViewProperties()
        {
            return new
            {
                Id = GetRandomString(),
                Isbn = GetRandomString(),
                Isbn13 = GetRandomString(),
                Title = GetRandomString(),
                Subtitle = GetRandomString(),
                PrimaryAuthor = GetRandomName(),
                PublishedDate = GetRandomDate()
            };

        }

        private static string GetRandomName() =>
            new RealNames(NameStyle.LastName).GetValue();

        private static DateTime GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();


    }
}
