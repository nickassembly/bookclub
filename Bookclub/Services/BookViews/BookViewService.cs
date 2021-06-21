using Blazored.SessionStorage;
using Bookclub.Core.DomainAggregates;
using Bookclub.Core.Interfaces;
using Bookclub.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookclub.Services.BookViews

{
    public partial class BookViewService : IBookViewService
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IDateTimeBroker _dateTimeBroker;
        private readonly ILoggingBroker _loggingBroker;
        private readonly ISessionStorageService _sessionStorage;
        private readonly IHttpContextAccessor _ctx;

        private readonly HttpClient _httpClient;

        public BookViewService(
            IBookService bookService,
            IUserService userService,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker,
            HttpClient httpClient,
            ISessionStorageService sessionStorage,
            IHttpContextAccessor ctx)
        {
            _bookService = bookService;
            _userService = userService;
            _dateTimeBroker = dateTimeBroker;
            _loggingBroker = loggingBroker;
            _httpClient = httpClient;
            _sessionStorage = sessionStorage;
            _ctx = ctx;
        }

        public Task<BookResponse> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }

        public async ValueTask<BookView> AddBookViewAsync(BookView bookView)
        {
            // TODO: Add Book View validation (on back end)
            Book book = await MapToBook(bookView);
            await _bookService.AddBookAsync(book);
            return bookView;
        }


        public Task<BookResponse> EditBookAsync(Book bookToEdit)
        {
            return _bookService.EditBookAsync(bookToEdit);
        }

        public Task<BookResponse> DeleteBookAsync(Guid bookId)
        {
            return _bookService.DeleteBookAsync(bookId);
        }

        public async Task<Book> MapToBook(BookView bookView)
        {

            var userEmail = await _sessionStorage.GetItemAsync<string>("emailAddress");

            User loggedInUser = await _userService.GetCurrentlyLoggedInUser(_ctx.HttpContext, userEmail);

            if (loggedInUser == null)
                return await Task.FromResult<Book>(null);

            DateTimeOffset currentDateTime = _dateTimeBroker.GetCurrentDateTime();

            bool isValidPriceInput = Decimal.TryParse(bookView.ListPrice, out decimal bookListPrice);

            if (!isValidPriceInput)
                bookListPrice = 0.00m;

            return new Book
            {
                Id = Guid.NewGuid(),
                Isbn = bookView.Isbn,
                Isbn13 = bookView.Isbn13,
                Author = bookView.PrimaryAuthor,
                Title = bookView.Title,
                Subtitle = bookView.Subtitle,
                PublishDate = bookView.PublishedDate,
                Publisher = bookView.Publisher,
                CreatedBy = loggedInUser.Id,
                UpdatedBy = loggedInUser.Id,
                CreatedDate = currentDateTime,
                UpdatedDate = currentDateTime,
                ListPrice = bookListPrice
            };

        }


    }
}
