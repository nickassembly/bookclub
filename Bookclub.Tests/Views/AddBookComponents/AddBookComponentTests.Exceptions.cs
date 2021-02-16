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

        [Theory]
        [MemberData(nameof(BookViewValidationExceptions))]
        public void ShouldRenderInnerExceptionMessageIfValidationErrorOccured(
            Exception bookViewValidationException)
        {
            // given
            string expectedErrorMessage = bookViewValidationException.InnerException.Message;

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
