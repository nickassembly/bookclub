
using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Moq;
using System;
using Xunit;

namespace Bookclub.Tests.Views.AddBookComponents
{
    public partial class AddBookComponentTests
    {

        [Fact]
        public void ShouldRenderInnerExceptionMessageIfValidationErrorOccured()
        {

            // given
            string randomMessage = GetRandomString();
            string validationMessage = randomMessage;
            var innerValidationException = new Exception(validationMessage);

            var bookViewValidationException = new BookViewValidationException(innerValidationException);

            _bookViewServiceMock.Setup(service => service.AddBookViewAsync(It.IsAny<BookView>())).ThrowsAsync(bookViewValidationException);

            // when

            // then


        }

    }
}
