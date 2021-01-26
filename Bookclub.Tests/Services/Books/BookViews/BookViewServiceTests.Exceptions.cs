using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Bookclub.Models.Books.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bookclub.Tests.Services.Books.BookViews
{
    public partial class BookViewServiceTests
    {
        public static TheoryData BookServiceValidationExceptions()
        {
            var innerException = new Exception();

            return new TheoryData<Exception>
            {
                new BookValidationException(innerException),
                new BookDependencyValidationException(innerException)
            };
        }

        [Theory]
        [MemberData(nameof(BookServiceValidationExceptions))]
        public async Task ShouldThrowDependencyValidationExceptionOnAddIfBookValidationErrorOccuredAndLogAsync(
            Exception bookServiceValidationException)
        {
            // given
            BookView someBookView = CreateRandomBookView();

            var expectedDepedencyValidationException =
                new BookViewDependencyValidationException(bookServiceValidationException);

            _bookServiceMock.Setup(service =>
            service.AddBookAsync(It.IsAny<Book>()))
                .ThrowsAsync(bookServiceValidationException);

            // when 
            ValueTask<BookView> addBookViewTask =
                this.bookViewService.AddBookViewAsync(someBookView);

            // then
            await Assert.ThrowsAsync<BookViewDependencyValidationException>(() =>
            addBookViewTask.AsTask());

            _userServiceMock.Verify(service =>
            service.GetCurrentlyLoggedInUser(),
            Times.Once);

            _dateTimeBrokerMock.Verify(broker =>
            broker.GetCurrentDateTime(),
            Times.Once);

            _bookServiceMock.Verify(service =>
            service.AddBookAsync(It.IsAny<Book>()),
            Times.Once);

            _loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedDepedencyValidationException))),
            Times.Once);

            _loggingBrokerMock.VerifyNoOtherCalls();
            _userServiceMock.VerifyNoOtherCalls();
            _dateTimeBrokerMock.VerifyNoOtherCalls();
            _bookServiceMock.VerifyNoOtherCalls();
        }



    }
}
