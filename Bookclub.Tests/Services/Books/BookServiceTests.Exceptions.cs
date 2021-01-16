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
        public static TheoryData ValidationApiExceptions()
        {
            string exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            var httpResponseConflictException =
                new HttpResponseConflictException(
                    responseMessage: responseMessage,
                    message: exceptionMessage);

            return new TheoryData<Exception>
            {
                httpResponseBadRequestException,
                httpResponseConflictException
            };
        }

        [Theory]
        [MemberData(nameof(ValidationApiExceptions))]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateIfBadRequestErrorOccursAndLogItAsync(
            Exception validationApiException)
        {

            // given
            Book someBook = CreateRandomBook();

            var expectedDependencyValidationException = new BookDependencyValidationException(
                validationApiException);

            _apiBrokerMock.Setup(broker =>
            broker.PostBookAsync(It.IsAny<Book>()))
                .ThrowsAsync(validationApiException);

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

        public static TheoryData CriticalApiExceptions()
        {
            string exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException(
                responseMessage: responseMessage,
                message: exceptionMessage);

            var httpResponseUnauthorizedException =
                new HttpResponseUnauthorizedException(
                    responseMessage: responseMessage,
                    message: exceptionMessage);

            return new TheoryData<Exception>
            {
                httpResponseUrlNotFoundException,
                httpResponseUnauthorizedException
            };
        }

        [Theory]
        [MemberData(nameof(CriticalApiExceptions))]
        public async Task ShouldThrowCriticalDependencyExceptionOnCreateIfUrlNotFoundErrorOccursAndLogItAsync(
            Exception httpResponseCriticalException)
        {
            // given
            Book someBook = CreateRandomBook();

            var expectedDependencyException =
                new BookDependencyException(
                httpResponseCriticalException);

            _apiBrokerMock.Setup(broker =>
            broker.PostBookAsync(It.IsAny<Book>()))
                .ThrowsAsync(httpResponseCriticalException);

            // when
            ValueTask<Book> registerStudentTask =
               _bookService.AddBookAsync(someBook);

            // then
            await Assert.ThrowsAsync<BookDependencyException>(() =>
            registerStudentTask.AsTask());

            _apiBrokerMock.Verify(broker => broker.PostBookAsync(It.IsAny<Book>()), Times.Once);
            _loggingBrokerMock.Verify(broker => broker.LogCritical(It.Is(SameExceptionAs(expectedDependencyException))), Times.Once);
            _apiBrokerMock.VerifyNoOtherCalls();
            _loggingBrokerMock.VerifyNoOtherCalls();
        }

        public static TheoryData DependencyApiExceptions()
        {
            string exceptionMessage = GetRandomString();
            var responseMessage = new HttpResponseMessage();

            var httpResponseException =
                new HttpResponseException(
                httpResponseMessage: responseMessage,
                message: exceptionMessage);

            var httpResponseInternalServerErrorException =
                new HttpResponseInternalServerErrorException(
                    responseMessage: responseMessage,
                    message: exceptionMessage);

            return new TheoryData<Exception>
            {
                httpResponseException,
                httpResponseInternalServerErrorException
            };
        }

        [Theory]
        [MemberData(nameof(DependencyApiExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCreateIfDependencyApiErrorOccursAndLogItAsync(
            Exception dependencyApiException)
        {
            // given
            Book someBook = CreateRandomBook();
            string exceptionMessage = GetRandomString();
           
            var expectedBookDependencyException = new BookDependencyException(
                dependencyApiException);

            _apiBrokerMock.Setup(broker =>
            broker.PostBookAsync(It.IsAny<Book>()))
                .ThrowsAsync(dependencyApiException);

            // when
            ValueTask<Book> registerBookTask = _bookService.AddBookAsync(someBook);

            // then
            await Assert.ThrowsAsync<BookDependencyException>(() =>
            registerBookTask.AsTask());

            _apiBrokerMock.Verify(broker => broker.PostBookAsync(It.IsAny<Book>()), Times.Once);
           _loggingBrokerMock.Verify(broker => broker.LogError(It.Is(SameExceptionAs(expectedBookDependencyException))), Times.Once);
            _apiBrokerMock.VerifyNoOtherCalls();
            _loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCreateIfErrorOccursAndLogItAsync()
        {
            // given
            Book someBook = CreateRandomBook();
            var serviceException = new Exception();

            var expectedBookServiceException =
                new BookServiceException(serviceException);

            _apiBrokerMock.Setup(broker =>
            broker.PostBookAsync(It.IsAny<Book>()))
                .ThrowsAsync(serviceException);
            // when
            ValueTask<Book> registerBookTask = _bookService.AddBookAsync(someBook);

            // then
            await Assert.ThrowsAsync<BookServiceException>(() =>
            registerBookTask.AsTask());

            _apiBrokerMock.Verify(broker => broker.PostBookAsync(It.IsAny<Book>()), Times.Once);
            _loggingBrokerMock.Verify(broker => broker.LogError(It.Is(SameExceptionAs(expectedBookServiceException))), Times.Once);
            _apiBrokerMock.VerifyNoOtherCalls();
            _loggingBrokerMock.VerifyNoOtherCalls();
        }


    }
}
