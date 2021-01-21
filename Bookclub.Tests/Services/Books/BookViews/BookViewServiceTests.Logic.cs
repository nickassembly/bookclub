using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bookclub.Tests.Services.Books.BookViews
{
    // TODO: Need to refactor Tests with better modelling
    public partial class BookViewServiceTests
    {
        [Fact]
        public async Task ShouldAddBookViewAsync()
        {
            // given
            DateTime randomDateTime = GetRandomDate();

            Random random = new Random();
            int randomInt = random.Next(99);
            double randomFloat = random.NextDouble() * (99.99f - 10.00f) + 10.00f;

            dynamic randomBookViewProperties =
                CreateRandomBookViewProperties();

            var randomBookView = new BookView
            {
                Id = randomBookViewProperties.Id,
                Isbn = randomBookViewProperties.Isbn,
                Isbn13 = randomBookViewProperties.Isbn13,
                PrimaryAuthor = randomBookViewProperties.PrimaryAuthor,
                PublishedDate = randomBookViewProperties.PublishedDate,
                Title = randomBookViewProperties.Title,
                Subtitle = randomBookViewProperties.Subtitle
            };

            BookView inputBookView = randomBookView;
            BookView expectedBookView = inputBookView;

            var randomBook = new Book
            { 
                BookId = randomInt,
                Id = randomBookViewProperties.Id,
                Isbn = randomBookViewProperties.Isbn,
                Isbn13 = randomBookViewProperties.Isbn13,
                PrimaryAuthor = randomBookViewProperties.PrimaryAuthor,
                PublishedDate = randomBookViewProperties.PublishedDate,
                Title = randomBookViewProperties.Title,
                Subtitle = randomBookViewProperties.Subtitle,
                CollectionType = randomInt,
                Country = GetRandomString(),
                Description = GetRandomString(),
                ExtraLarge = GetRandomString(),
                Language = GetRandomString(),
                Large = GetRandomString(),
                ListCurrencyCode = GetRandomString(),
                ListPrice = (decimal)randomFloat,
                Medium = GetRandomString(),
                Publisher = GetRandomString(),
                SelfLink = GetRandomString(),
                Small = GetRandomString(),
                SmallThumbnail = GetRandomString(),
                Thumbnail = GetRandomString()
            };

            Book expectedInputBook = randomBook;
            Book returnedBook = expectedInputBook;

            _userServiceMock.Setup(service =>
            service.GetCurrentlyLoggedInUser())
                .Returns(randomInt);

            _dateTimeBrokerMock.Setup(broker =>
            broker.GetCurrentDateTime())
                .Returns(randomDateTime);

            _bookServiceMock.Setup(service =>
            service.AddBookAsync(It.Is(
                SameBookAs(expectedInputBook))))
                .ReturnsAsync(returnedBook);

            // when
            BookView actualBookView =
                await this.bookViewService.AddBookViewAsync(inputBookView);

            // then
            actualBookView.Should().BeEquivalentTo(expectedBookView);

            _userServiceMock.Verify(service => service.GetCurrentlyLoggedInUser(),
                Times.Once);

            _dateTimeBrokerMock.Verify(broker => broker.GetCurrentDateTime(),
                Times.Once);

            _bookServiceMock.Verify(service => service.AddBookAsync(
                It.Is(SameBookAs(expectedInputBook))),
                Times.Once);

            _dateTimeBrokerMock.VerifyNoOtherCalls();
            _userServiceMock.VerifyNoOtherCalls();
            _bookServiceMock.VerifyNoOtherCalls();
            _loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
