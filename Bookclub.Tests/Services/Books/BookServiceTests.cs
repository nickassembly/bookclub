using Bookclub.Brokers.API;
using Bookclub.Brokers.Logging;
using Bookclub.Services.Books;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Tests.Services.Books
{
    public class BookServiceTests
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

    }
}
