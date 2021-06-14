using Bookclub.Models.Books;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bookclub.Tests.Services.Books
{
    public partial class BookServiceTests
    {
        //[Fact]
        //public async Task ShouldAddBookToUserAsync()
        // {
        //    // Test for adding a book, should test the 'happy' path of the service
        //    // validation testing in another class

        //    //given
        //    Book randomBook = CreateRandomBook();
        //    Book retrievedBook = randomBook;
        //    Book expectedBook = retrievedBook;

        //    _apiBrokerMock.Setup(broker => broker.PostBookAsync(randomBook))
        //                  .ReturnsAsync(retrievedBook);

        //    //when
        //    Book addedBook = await _bookService.AddBookAsync(retrievedBook);

        //    //then
        //    addedBook.Should().BeEquivalentTo(expectedBook);

        //    _apiBrokerMock.Verify(broker => broker.PostBookAsync(retrievedBook), Times.Once);
        //    _apiBrokerMock.VerifyNoOtherCalls();
        //    _loggingBrokerMock.VerifyNoOtherCalls();

        //}
    }
}
