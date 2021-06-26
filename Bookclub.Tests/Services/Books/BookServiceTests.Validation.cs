using Bookclub.Models.Books;
using Bookclub.Models.Books.Exceptions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Bookclub.Tests.Services.Books
{
    public partial class BookServiceTests
    {
        // TODO: Need to add more validation tests based on Book object
        // TODO: Possible tests for DateTime? if it can be a default value for publish date
        // TODO: Refactor API based on new more clean patterns 

        //[Fact]
        //public async Task ShouldThrowValidationExceptionOnCreateIfBookIsNullAndLogItAsync()
        //{
        //    //given
        //    Book invalidBook = null;
        //    var nullBookException = new NullBookException();

        //    var expectedBookValidationException = new BookValidationException(nullBookException);

        //    //when
        //    ValueTask<Book> submitBookTask = _bookService.AddBookAsync(invalidBook);

        //    //then
        //    await Assert.ThrowsAsync<BookValidationException>(() => submitBookTask.AsTask());

        //    _loggingBrokerMock.Verify(broker => broker.LogError(
        //        It.Is(SameExceptionAs(expectedBookValidationException))), Times.Once);

        //    _apiBrokerMock.Verify(broker => broker.PostBookAsync(It.IsAny<Book>()), Times.Never);

        //    _apiBrokerMock.VerifyNoOtherCalls();
        //    _loggingBrokerMock.VerifyNoOtherCalls();
        //}

        //[Fact]
        //public async Task ShouldThrowValidationExceptionOnCreateIfBookIdIsInvalidAndLogItAsync()
        //{
        //    // given
        //    string invalidId = string.Empty;
        //    Book randomBook = CreateRandomBook();
        //    Book invalidBook = randomBook;
        //    invalidBook.Id = invalidId;

        //    var invalidBookException = new InvalidBookException(
        //        parameterName: nameof(Book.Id),
        //        parameterValue: invalidBook.Id);

        //    var expectedBookValidationException = new BookValidationException(invalidBookException);

        //    // when
        //    ValueTask<Book> createBookTask = _bookService.AddBookAsync(invalidBook);

        //    // then
        //    await Assert.ThrowsAsync<BookValidationException>(() =>
        //    createBookTask.AsTask());

        //    _loggingBrokerMock.Verify(broker =>
        //    broker.LogError(It.Is(SameExceptionAs(expectedBookValidationException))), Times.Once);

        //    _apiBrokerMock.Verify(broker =>
        //    broker.PostBookAsync(It.IsAny<Book>()), Times.Never);

        //    _loggingBrokerMock.VerifyNoOtherCalls();
        //    _apiBrokerMock.VerifyNoOtherCalls();
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("   ")]
        //public async Task ShouldThrowValidationExceptionOnCreateIfIsbnIsInvalidAndLogItAsync(string invalidIsbn)
        //{
        //    // given
        //    Book randomBook = CreateRandomBook();
        //    Book invalidBook = randomBook;
        //    invalidBook.Isbn = invalidIsbn;

        //    var invalidBookException = new InvalidBookException(
        //        parameterName: nameof(Book.Isbn),
        //        parameterValue: invalidBook.Isbn);

        //    var expectedBookValidationException = new BookValidationException(invalidBookException);

        //    // when
        //    ValueTask<Book> createBookTask = _bookService.AddBookAsync(invalidBook);

        //    // then
        //    await Assert.ThrowsAsync<BookValidationException>(() =>
        //    createBookTask.AsTask());

        //    _loggingBrokerMock.Verify(broker =>
        //    broker.LogError(It.Is(SameExceptionAs(expectedBookValidationException))), Times.Once);

        //    _apiBrokerMock.Verify(broker =>
        //    broker.PostBookAsync(It.IsAny<Book>()), Times.Never);

        //    _loggingBrokerMock.VerifyNoOtherCalls();
        //    _apiBrokerMock.VerifyNoOtherCalls();
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("   ")]
        //public async Task ShouldThrowValidationExceptionOnCreateIfTitleIsInvalidAndLogItAsync(string invalidTitle)
        //{
        //    // given
        //    Book randomBook = CreateRandomBook();
        //    Book invalidBook = randomBook;
        //    invalidBook.Title = invalidTitle;

        //    var invalidBookException = new InvalidBookException(
        //        parameterName: nameof(Book.Title),
        //        parameterValue: invalidBook.Title);

        //    var expectedBookValidationException = new BookValidationException(invalidBookException);

        //    // when
        //    ValueTask<Book> createBookTask = _bookService.AddBookAsync(invalidBook);

        //    // then
        //    await Assert.ThrowsAsync<BookValidationException>(() =>
        //    createBookTask.AsTask());

        //    _loggingBrokerMock.Verify(broker =>
        //    broker.LogError(It.Is(SameExceptionAs(expectedBookValidationException))), Times.Once);

        //    _apiBrokerMock.Verify(broker =>
        //    broker.PostBookAsync(It.IsAny<Book>()), Times.Never);

        //    _loggingBrokerMock.VerifyNoOtherCalls();
        //    _apiBrokerMock.VerifyNoOtherCalls();
        //}

    }
}
