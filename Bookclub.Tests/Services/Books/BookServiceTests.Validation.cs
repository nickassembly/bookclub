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
    }
}
