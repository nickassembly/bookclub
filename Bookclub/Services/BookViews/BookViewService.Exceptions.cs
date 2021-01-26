using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Bookclub.Models.Books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services.BookViews
{
    public partial class BookViewService
    {
        private delegate ValueTask<BookView> ReturningBookViewFunction();

        private async ValueTask<BookView> TryCatch(ReturningBookViewFunction returningBookViewFunction)
        {
            try
            {
                return await returningBookViewFunction();
            }
            catch (NullBookViewException nullBookViewException)
            {
                throw CreateAndLogValidationException(nullBookViewException);
            }
            catch (InvalidBookViewException invalidBookViewException)
            {
                throw CreateAndLogValidationException(invalidBookViewException);
            }
            catch (BookValidationException bookValidationException)
            {
                throw CreateAndLogDependencyValidationException(bookValidationException);
            }
            catch (BookDependencyValidationException bookDependencyValidationException)
            {
                throw CreateAndLogDependencyValidationException(bookDependencyValidationException);
            }
        }

        private BookViewValidationException CreateAndLogValidationException(Exception exception)
        {
            var bookViewValidationException = new BookViewValidationException(exception);
            _loggingBroker.LogError(bookViewValidationException);

            return bookViewValidationException;
        }

        private BookViewDependencyValidationException CreateAndLogDependencyValidationException(Exception exception)
        {
            var bookViewValidationException = new BookViewDependencyValidationException(exception);
            _loggingBroker.LogError(bookViewValidationException);

            return bookViewValidationException;
        }

    }
}
