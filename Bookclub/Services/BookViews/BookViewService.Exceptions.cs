using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
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
        }

        private BookViewValidationException CreateAndLogValidationException(Exception exception)
        {
            var bookViewValidationException = new BookViewValidationException(exception);
            _loggingBroker.LogError(bookViewValidationException);

            return bookViewValidationException;
        }

    }
}
