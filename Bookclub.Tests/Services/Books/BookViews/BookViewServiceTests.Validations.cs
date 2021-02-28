using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Bookclub.Tests.Services.Books.BookViews
{
    public partial class BookViewServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfBookViewIsNullAndLogItAsync()
        {
            // given
            BookView nullBookView = null;
            var nullBookViewException = new NullBookViewException();

            var expectedBookViewValidationException =
                new BookViewValidationException(nullBookViewException);

            // when 
            ValueTask<BookView> addBookViewTask =
                this.bookViewService.AddBookViewAsync(nullBookView);

            // then
            await Assert.ThrowsAsync<BookViewValidationException>(() =>
            addBookViewTask.AsTask());

            _loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedBookViewValidationException))),
            Times.Once);

            _userServiceMock.Verify(service =>
            service.GetCurrentlyLoggedInUser(),
            Times.Never);

            _dateTimeBrokerMock.Verify(broker =>
            broker.GetCurrentDateTime(),
            Times.Never);

            _bookServiceMock.Verify(service =>
            service.AddBookAsync(It.IsAny<Book>()),
            Times.Never);

            _loggingBrokerMock.VerifyNoOtherCalls();
            _userServiceMock.VerifyNoOtherCalls();
            _dateTimeBrokerMock.VerifyNoOtherCalls();
            _bookServiceMock.VerifyNoOtherCalls();

        }

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("   ")]   
        //public async Task ShouldThrowValidationExceptionOnAddIfBookIdIsInvalidAndLogItAsync(
        //    string invalidIdNumber)
        //{
        //    // given
        //    BookView randomBookView = CreateRandomBookView();
        //    BookView invalidBookView = randomBookView;
        //    invalidBookView.Id = invalidIdNumber;

        //    var invalidBookViewException = new InvalidBookViewException(
        //        parameterName: nameof(BookView.Id),
        //        parameterValue: invalidBookView.Id);

        //    var expectedBookViewValidationException =
        //        new BookViewValidationException(invalidBookViewException);

        //    // when 
        //    ValueTask<BookView> addBookViewTask =
        //        this.bookViewService.AddBookViewAsync(invalidBookView);

        //    // then
        //    await Assert.ThrowsAsync<BookViewValidationException>(() =>
        //    addBookViewTask.AsTask());

        //    _loggingBrokerMock.Verify(broker =>
        //    broker.LogError(It.Is(SameExceptionAs(expectedBookViewValidationException))),
        //    Times.Once);

        //    _userServiceMock.Verify(service =>
        //    service.GetCurrentlyLoggedInUser(),
        //    Times.Never);

        //    _dateTimeBrokerMock.Verify(broker =>
        //    broker.GetCurrentDateTime(),
        //    Times.Never);

        //    _bookServiceMock.Verify(service =>
        //    service.AddBookAsync(It.IsAny<Book>()),
        //    Times.Never);

        //    _loggingBrokerMock.VerifyNoOtherCalls();
        //    _userServiceMock.VerifyNoOtherCalls();
        //    _dateTimeBrokerMock.VerifyNoOtherCalls();
        //    _bookServiceMock.VerifyNoOtherCalls();

        //}

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task ShouldThrowValidationExceptionOnAddIfBookTitleIsInvalidAndLogItAsync(
     string invalidTitle)
        {
            // given
            BookView randomBookView = CreateRandomBookView();
            BookView invalidBookView = randomBookView;
            invalidBookView.Title = invalidTitle;

            var invalidBookViewException = new InvalidBookViewException(
                parameterName: nameof(BookView.Title),
                parameterValue: invalidBookView.Title);

            var expectedBookViewValidationException =
                new BookViewValidationException(invalidBookViewException);

            // when 
            ValueTask<BookView> addBookViewTask =
                this.bookViewService.AddBookViewAsync(invalidBookView);

            // then
            await Assert.ThrowsAsync<BookViewValidationException>(() =>
            addBookViewTask.AsTask());

            _loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedBookViewValidationException))),
            Times.Once);

            _userServiceMock.Verify(service =>
            service.GetCurrentlyLoggedInUser(),
            Times.Never);

            _dateTimeBrokerMock.Verify(broker =>
            broker.GetCurrentDateTime(),
            Times.Never);

            _bookServiceMock.Verify(service =>
            service.AddBookAsync(It.IsAny<Book>()),
            Times.Never);

            _loggingBrokerMock.VerifyNoOtherCalls();
            _userServiceMock.VerifyNoOtherCalls();
            _dateTimeBrokerMock.VerifyNoOtherCalls();
            _bookServiceMock.VerifyNoOtherCalls();

        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfBookPublishDateInvalidAndLogItAsync()
        {
            // given
            BookView randomBookView = CreateRandomBookView();
            BookView invalidBookView = randomBookView;
            invalidBookView.PublishedDate = default;

            var invalidBookViewException = new InvalidBookViewException(
                parameterName: nameof(BookView.PublishedDate),
                parameterValue: invalidBookView.PublishedDate);

            var expectedBookViewValidationException =
                new BookViewValidationException(invalidBookViewException);

            // when 
            ValueTask<BookView> addBookViewTask =
                this.bookViewService.AddBookViewAsync(invalidBookView);

            // then
            await Assert.ThrowsAsync<BookViewValidationException>(() =>
            addBookViewTask.AsTask());

            _loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedBookViewValidationException))),
            Times.Once);

            _userServiceMock.Verify(service =>
            service.GetCurrentlyLoggedInUser(),
            Times.Never);

            _dateTimeBrokerMock.Verify(broker =>
            broker.GetCurrentDateTime(),
            Times.Never);

            _bookServiceMock.Verify(service =>
            service.AddBookAsync(It.IsAny<Book>()),
            Times.Never);

            _loggingBrokerMock.VerifyNoOtherCalls();
            _userServiceMock.VerifyNoOtherCalls();
            _dateTimeBrokerMock.VerifyNoOtherCalls();
            _bookServiceMock.VerifyNoOtherCalls();

        }

    }
}
