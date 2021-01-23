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
        // TODO: Validate for Id, Title (string) and publish date
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]   
        public async Task ShouldThrowValidationExceptionOnAddIfBookIdIsInvalidAndLogItAsync(
            string invalidIdNumber)
        {
            // given
            BookView randomBookView = CreateRandomBookView();
            BookView invalidBookView = randomBookView;
            invalidBookView.Id = invalidIdNumber;

            var invalidBookViewException = new InvalidBookViewException(
                parameterName: nameof(BookView.Id),
                parameterValue: invalidBookView.Id);

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
