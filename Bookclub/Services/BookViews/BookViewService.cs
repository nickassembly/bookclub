﻿using Blazored.SessionStorage;
using Bookclub.Brokers.DateTimes;
using Bookclub.Brokers.Logging;
using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Users;
using Bookclub.Services.Books;
using Bookclub.Services.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
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

        public ValueTask<BookView> AddBookViewAsync(BookView bookView) =>
            TryCatch(async () =>
            {
                ValidateBookView(bookView);
                Book book = MapToBook(bookView);
                await _bookService.AddBookAsync(book);

                return bookView;
            });

        public Task<BookResponse> DeleteBookAsync(Guid bookId)
        {
            return _bookService.DeleteBookAsync(bookId);
        }

        public async Task<string> GetUserEmail()
        {
            return await _sessionStorage.GetItemAsync<string>("emailAddress");
        }

        // need to make async
        private Book MapToBook(BookView bookView)
        {

            var userEmail = GetUserEmail();

         //   User loggedInUser = _userService.GetCurrentlyLoggedInUser(_ctx.HttpContext, userEmail);
            User loggedInUser = _userService.GetCurrentlyLoggedInUser(_ctx.HttpContext, "");

            DateTimeOffset currentDateTime = _dateTimeBroker.GetCurrentDateTime();

            return new Book
            {

                Id = Guid.NewGuid(),
                Isbn = bookView.Isbn,
                Isbn13 = bookView.Isbn13,
                Author = bookView.PrimaryAuthor,
                Title = bookView.Title,
                Subtitle = bookView.Subtitle,
                PublishDate = bookView.PublishedDate,
                // TODO: Replace with function. Temporary Test code
                Publisher = "test pub",
                CreatedBy = Guid.NewGuid(),
                UpdatedBy = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                UpdatedDate = DateTimeOffset.UtcNow,
                ListPrice = 9 // TODO: figure out decimal to float conversions
            };

        }
    }
}
