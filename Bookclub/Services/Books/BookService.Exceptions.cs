using Bookclub.Models.Books;
using Bookclub.Models.Books.Exceptions;
using System;
using System.Threading.Tasks;

namespace Bookclub.Services.Books
{
    public partial class BookService
    {
        private delegate ValueTask<Book> ReturningBookFunction();

        private async ValueTask<Book> TryCatch(ReturningBookFunction returningBookFunction)
        {
            try
            {
                return await returningBookFunction();
            }
            catch (NullBookException nullBookException)
            {

                throw CreateAndLogValidationException(nullBookException);
            }
            catch (InvalidBookException invalidBookException)
            {

                throw CreateAndLogValidationException(invalidBookException);
            }

        }

        private Exception CreateAndLogValidationException(Exception nullBookException)
        {
            var bookValidationException = new BookValidationException(nullBookException);
            _loggingBroker.LogError(bookValidationException);

            return bookValidationException;
        }
    }
}
