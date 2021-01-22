using Bookclub.Brokers.DateTimes;
using Bookclub.Brokers.Logging;
using Bookclub.Models.Books;
using Bookclub.Services.Books;
using Bookclub.Services.BookViews;
using Bookclub.Services.Users;
using Moq;
using System;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using Tynamix.ObjectFiller;
using Bookclub.Models.Books.BookViews;

namespace Bookclub.Tests.Services.Books.BookViews
{
    public partial class BookViewServiceTests
    {
        private readonly Mock<IBookService> _bookServiceMock;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IDateTimeBroker> _dateTimeBrokerMock;
        private readonly Mock<ILoggingBroker> _loggingBrokerMock;
        private readonly IBookViewService bookViewService;
        private readonly ICompareLogic _compareLogic;

        public BookViewServiceTests()
        {
            this._bookServiceMock = new Mock<IBookService>();
            this._userServiceMock = new Mock<IUserService>();
            this._dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this._loggingBrokerMock = new Mock<ILoggingBroker>();
            var compareConfig = new ComparisonConfig();
            compareConfig.IgnoreProperty<Book>(book => book.Id);
            compareConfig.IgnoreProperty<Book>(book => book.BookId);
            this._compareLogic = new CompareLogic(compareConfig);

            this.bookViewService = new BookViewService(
               bookService: _bookServiceMock.Object,
               userService: _userServiceMock.Object,
               dateTimeBroker: _dateTimeBrokerMock.Object,
               loggingBroker: _loggingBrokerMock.Object);
        }

        private static dynamic CreateRandomBookViewProperties()
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
        private Expression<Func<Book, bool>> SameBookAs(Book expectedBook)
        {
            return actualBook => _compareLogic.Compare(expectedBook, actualBook).AreEqual;
        }

        private static DateTime GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static BookView CreateRandomBookView() =>
            CreateBookViewFiller().Create();

        private static string GetRandomName() =>
            new RealNames(NameStyle.LastName).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static Filler<BookView> CreateBookViewFiller()
        {
            var filler = new Filler<BookView>();

            filler.Setup()
                .OnType<DateTime>().Use(DateTime.UtcNow);

            return filler;
        }


    }
}
