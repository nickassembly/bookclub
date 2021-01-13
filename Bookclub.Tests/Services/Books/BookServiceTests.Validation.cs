using Bookclub.Models.Books;
using Bookclub.Models.Books.Exceptions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Bookclub.Tests.Services.Books
{
    public partial class BookServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateIfBookIsNullAndLogItAsync()
        {
            //given
            Book invalidBook = null;
            var nullBookException = new NullBookException();

            var expectedBookValidationException = new BookValidationException(nullBookException);

            //when
            ValueTask<Book> submitBookTask = _bookService.AddBookAsync(invalidBook);

            //then
            await Assert.ThrowsAsync<BookValidationException>(() => submitBookTask.AsTask());

            _loggingBrokerMock.Verify(broker => broker.LogError(
                It.Is(SameExceptionAs(expectedBookValidationException))), Times.Once);

            _apiBrokerMock.Verify(broker => broker.PostBookAsync(It.IsAny<Book>()), Times.Never);

            _apiBrokerMock.VerifyNoOtherCalls();
            _loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateIfBookIdIsInvalidAndLogItAsync()
        {
            // given
            string invalidId = string.Empty;
            Book randomBook = CreateRandomBook();
            Book invalidBook = randomBook;
            invalidBook.Id = invalidId;

            var invalidBookException = new InvalidBookException(
                parameterName: nameof(Book.Id),
                parameterValue: invalidBook.Id);

            var expectedBookValidationException = new BookValidationException(invalidBookException);

            // when
            ValueTask<Book> createBookTask = _bookService.AddBookAsync(invalidBook);

            // then
            await Assert.ThrowsAsync<BookValidationException>(() =>
            createBookTask.AsTask());

            _loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedBookValidationException))), Times.Once);

            _apiBrokerMock.Verify(broker =>
            broker.PostBookAsync(It.IsAny<Book>()), Times.Never);

            _loggingBrokerMock.VerifyNoOtherCalls();
            _apiBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task ShouldThrowValidationExceptionOnCreateIfBookUserIdIsInvalidAndLogItAsync(string invalidBookId)
        {
            // given
            Book randomBook = CreateRandomBook();
            Book invalidBook = randomBook;
            invalidBook.Id = invalidBookId;

            var invalidBookException = new InvalidBookException(
                parameterName: nameof(Book.Id),
                parameterValue: invalidBook.Id);

            var expectedBookValidationException = new BookValidationException(invalidBookException);

            // when
            ValueTask<Book> createBookTask = _bookService.AddBookAsync(invalidBook);

            // then
            await Assert.ThrowsAsync<BookValidationException>(() =>
            createBookTask.AsTask());

            _loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedBookValidationException))), Times.Once);

            _apiBrokerMock.Verify(broker =>
            broker.PostBookAsync(It.IsAny<Book>()), Times.Never);

            _loggingBrokerMock.VerifyNoOtherCalls();
            _apiBrokerMock.VerifyNoOtherCalls();
        }

    }
}
