using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
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
        [Fact]
        public async Task ShouldAddBookViewAsync()
        {
            // given
            DateTime randomDateTime = GetRandomDate();

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

            };
                

            // when

            // then
        }
    }
}
