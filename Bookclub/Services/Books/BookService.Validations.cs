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

                case { } when IsInvalid(book.BookId):
                    throw new InvalidBookException(
                    parameterName: nameof(book.BookId),
                    parameterValue: book.BookId);
            }
        }
        private static bool IsInvalid(int id) => id == null;
        private static bool IsInvalid(string text) => String.IsNullOrWhiteSpace(text);

    }
}
