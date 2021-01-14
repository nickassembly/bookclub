using Bookclub.Brokers.API;
using Bookclub.Brokers.Logging;
using Bookclub.Models.Books;
using Bookclub.Services.Books;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Xunit.Sdk;

namespace Bookclub.Tests.Services.Books
{
    public partial class BookServiceTests
    {
        private readonly Mock<IApiBroker> _apiBrokerMock;
        private readonly Mock<ILoggingBroker> _loggingBrokerMock;
        private readonly IBookService _bookService;

        public BookServiceTests()
        {
            _apiBrokerMock = new Mock<IApiBroker>();
            _loggingBrokerMock = new Mock<ILoggingBroker>();

            _bookService = new BookService(_apiBrokerMock.Object, _loggingBrokerMock.Object);
        }

        private static Book CreateRandomBook() => CreateBookFiller().Create();

        private Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
            && actualException.InnerException.Message == expectedException.InnerException.Message;
        }

        private static string GetRandomString() => new MnemonicString().GetValue();

        private static Filler<Book> CreateBookFiller()
        {
            var filler = new Filler<Book>();

            return filler;
        }


    }
}
