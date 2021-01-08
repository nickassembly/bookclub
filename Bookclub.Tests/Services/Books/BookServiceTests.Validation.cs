using Bookclub.Models.Books;
using Bookclub.Models.Books.Exceptions;
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

            //when

            //then
        }
    }
}
