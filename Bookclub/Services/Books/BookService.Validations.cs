using Bookclub.Models.Books;
using Bookclub.Models.Books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services.Books
{
    public partial class BookService
    {
        private void ValidateBook(Book book)
        {
            switch (book)
            {
                case null: throw new NullBookException();

                case { } when IsInvalid(book.Id):
                    throw new InvalidBookException(
                    parameterName: nameof(book.Id),
                    parameterValue: book.Id);

                case { } when IsInvalid(book.Isbn):
                    throw new InvalidBookException(
                    parameterName: nameof(book.Isbn),
                    parameterValue: book.Isbn);

                case { } when IsInvalid(book.Title):
                    throw new InvalidBookException(
                    parameterName: nameof(book.Title),
                    parameterValue: book.Title);
            }
        }

        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);
        private static bool IsInvalid(Guid id) => id == Guid.Empty;

    }
}
