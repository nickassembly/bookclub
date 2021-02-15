using Bookclub.Views.Components;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Moq;
using System;
using Xunit;
using FluentAssertions;

namespace Bookclub.Tests.Views.AddBookComponents
{
    public partial class AddBookComponentTests
    {

        [Fact]
        public void ShouldRenderInnerExceptionMessageIfValidationErrorOccured()
        {

            // given
            string randomMessage = GetRandomString();
            string validationMessage = randomMessage;
            string expectedErrorMessage = validationMessage;
            var innerValidationException = new Exception(validationMessage);

            var bookViewValidationException = new BookViewValidationException(innerValidationException);

            _bookViewServiceMock.Setup(service => service.AddBookViewAsync(It.IsAny<BookView>())).ThrowsAsync(bookViewValidationException);

            // when
            _addBookComponent = RenderComponent<AddBookComponent>();

            _addBookComponent.Instance.SubmitButton.Click();

            // then
            _addBookComponent.Instance.ErrorLabel.Value.Should().BeEquivalentTo(expectedErrorMessage);

            _bookViewServiceMock.Verify(service => service.AddBookViewAsync(It.IsAny<BookView>()), Times.Once);

            _bookViewServiceMock.VerifyNoOtherCalls();

        }

    }
}
