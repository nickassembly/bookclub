using Bookclub.Models.Books;
using Bookclub.Models.Books.Exceptions;
using Moq;
using RESTFulSense.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bookclub.Tests.Services.Books
{
    public partial class BookServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateIfBadRequestErrorOccursAndLogItAsync()
        {

            // given
            Book someBook = CreateRandomBook();
            string exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseBadRequestException = new HttpResponseBadRequestException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            var expectedDependencyValidationException = new BookDependencyValidationException(
                httpResponseBadRequestException);

            _apiBrokerMock.Setup(broker =>
            broker.PostBookAsync(It.IsAny<Book>()))
                .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Book> registerBookTask = _bookService.AddBookAsync(someBook);

            // then
            await Assert.ThrowsAsync<BookDependencyValidationException>(() =>
            registerBookTask.AsTask());

            _apiBrokerMock.Verify(broker => broker.PostBookAsync(It.IsAny<Book>()), Times.Once);
            _loggingBrokerMock.Verify(broker => broker.LogError(It.Is(SameExceptionAs(expectedDependencyValidationException))), Times.Once);
            _apiBrokerMock.VerifyNoOtherCalls();
            _loggingBrokerMock.VerifyNoOtherCalls();

        }
    }
}
