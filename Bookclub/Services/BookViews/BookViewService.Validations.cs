using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using System;

namespace Bookclub.Services.BookViews
{
    public partial class BookViewService
    {
        private static void ValidateBookView(BookView bookView)
        {
            switch (bookView)
            {
                case null:
                    throw new NullBookViewException();

                case { } when IsInvalid(bookView.Id):
                    throw new InvalidBookViewException(
                        parameterName: nameof(BookView.Id),
                        parameterValue: bookView.Id);

                case { } when IsInvalid(bookView.Title):
                    throw new InvalidBookViewException(
                        parameterName: nameof(BookView.Title),
                        parameterValue: bookView.Title);

                case { } when IsInvalid(bookView.PublishedDate.ToString()):
                    throw new InvalidBookViewException(
                        parameterName: nameof(BookView.PublishedDate),
                        parameterValue: bookView.PublishedDate);
            }
        }

        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);

        private static bool IsInvalid(DateTime date) => date == default;

    }

}
