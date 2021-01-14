﻿using Bookclub.Models.Books;
using Bookclub.Models.Books.Exceptions;
using RESTFulSense.Exceptions;
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
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                throw CreateAndLogDependencyValidationException(httpResponseBadRequestException);
            }

        }

        private Exception CreateAndLogValidationException(Exception nullBookException)
        {
            var bookValidationException = new BookValidationException(nullBookException);
            _loggingBroker.LogError(bookValidationException);

            return bookValidationException;
        }

        private BookDependencyValidationException CreateAndLogDependencyValidationException(Exception exception)
        {
            var bookDependencyValidationException = new BookDependencyValidationException(exception);
            _loggingBroker.LogError(bookDependencyValidationException);

            return bookDependencyValidationException;
        }
    }
}
