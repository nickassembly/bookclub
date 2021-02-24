
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Bookclub.Models.Books.Exceptions;
using Bookclub.Services.BookViews;
using Bookclub.Views.Components;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Tynamix.ObjectFiller;
using Xunit;

namespace Bookclub.Tests.Views.AddBookComponents
{
    public partial class AddBookComponentTests : TestContext
    {
        private readonly Mock<IBookViewService> _bookViewServiceMock;
        private IRenderedComponent<AddBookComponent> _addBookComponent;

        public AddBookComponentTests()
        {
            _bookViewServiceMock = new Mock<IBookViewService>();
            this.Services.AddScoped(services => this._bookViewServiceMock.Object);
            this.Services.AddServerSideBlazor();
        }

        private static BookView CreateRandomBookView() => CreateBookFiller().Create();

        private static string GetRandomString() => new MnemonicString().GetValue();

        public static TheoryData BookViewValidationExceptions()
        {
            string randomMessage = GetRandomString();
            string validationMessage = randomMessage;
            var innerValidationException = new Exception(validationMessage);

            return new TheoryData<Exception>
            {
                new BookViewValidationException(innerValidationException),
                new BookViewDependencyValidationException(innerValidationException)
            };
        }

        public static TheoryData BookViewDependencyServiceExceptions()
        {
            var innerValidationException = new Exception();

            return new TheoryData<Exception>
            {
                new BookViewDependencyException(innerValidationException),
                new BookViewServiceException(innerValidationException)
            };
        }

        private static Filler<BookView> CreateBookFiller()
        {
            var filler = new Filler<BookView>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(DateTimeOffset.UtcNow);

            return filler;
        }

    }
}
