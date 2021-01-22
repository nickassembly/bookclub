using Bookclub.Models.Books.BookViews;
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

            // when 

            // then
        }

    }
}
