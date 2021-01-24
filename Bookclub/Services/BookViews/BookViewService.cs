using Bookclub.Brokers.DateTimes;
using Bookclub.Brokers.Logging;
using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
using Bookclub.Services.Books;
using Bookclub.Services.Users;
using System;
using System.Threading.Tasks;

namespace Bookclub.Services.BookViews
{
    public partial class BookViewService : IBookViewService
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

        public ValueTask<BookView> AddBookViewAsync(BookView bookView) =>
            TryCatch(async () =>
            {
                ValidateBookView(bookView);
                Book book = MapToBook(bookView);
                await _bookService.AddBookAsync(book);

                return bookView;
            });


        private Book MapToBook(BookView bookView)
        {
            int currentLoggedInUserId = _userService.GetCurrentlyLoggedInUser();
            DateTimeOffset currentDateTime = _dateTimeBroker.GetCurrentDateTime();

            return new Book
            {
                // TODO: Need better mapping between Book and Book View
                BookId = 99, //TODO: need to change how Id is generated
                Id = bookView.Id,
                Isbn = bookView.Isbn,
                Isbn13 = bookView.Isbn13,
                PrimaryAuthor = bookView.PrimaryAuthor,
                PublishedDate = bookView.PublishedDate,
                Title = bookView.Title,
                Subtitle = bookView.Subtitle,
                CollectionType = bookView.CollectionType,
                Country = "",
                Description = "",
                ExtraLarge = "",
                Language = "",
                Large = "",
                ListCurrencyCode = "",
                ListPrice = (decimal)0.00f,
                Medium = "",
                Publisher = "",
                SelfLink = "",
                Small = "",
                SmallThumbnail = "",
                Thumbnail = ""
            };

        }
    }
}
