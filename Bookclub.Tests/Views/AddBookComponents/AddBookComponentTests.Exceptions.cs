using Bookclub.Views.Components;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Moq;
using System;
using Xunit;
using FluentAssertions;
using Bookclub.Models.Colors;

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
            _addBookComponent.Instance.StatusLabel.Value.Should().BeEquivalentTo(expectedErrorMessage);
           
            _addBookComponent.Instance.StatusLabel.Color.Should().Be(Color.Red);

        //    _addBookComponent.Instance.IdTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.Isbn13TextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.IsbnTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.AuthorTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.TitleTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.SubtitleTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.PublishDatePicker.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.SubmitButton.IsDisabled.Should().BeFalse();

            _bookViewServiceMock.Verify(service => service.AddBookViewAsync(It.IsAny<BookView>()), Times.Once);

            _bookViewServiceMock.VerifyNoOtherCalls();

        }

        [Theory]
        [MemberData(nameof(BookViewDependencyServiceExceptions))]
        public void ShouldRenderOuterExceptionMessageIfDependencyOrServiceErrorOccured(
          Exception bookViewDependencyServiceException)
        {
            // given
            string expectedErrorMessage = bookViewDependencyServiceException.Message;

            _bookViewServiceMock.Setup(service => service.AddBookViewAsync(It.IsAny<BookView>())).ThrowsAsync(bookViewDependencyServiceException);

            // when
            _addBookComponent = RenderComponent<AddBookComponent>();

            _addBookComponent.Instance.SubmitButton.Click();

            // then
            _addBookComponent.Instance.StatusLabel.Value.Should().BeEquivalentTo(expectedErrorMessage);

            _addBookComponent.Instance.StatusLabel.Color.Should().Be(Color.Red);

         //   _addBookComponent.Instance.IdTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.Isbn13TextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.IsbnTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.AuthorTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.TitleTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.SubtitleTextBox.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.PublishDatePicker.IsDisabled.Should().BeFalse();
            _addBookComponent.Instance.SubmitButton.IsDisabled.Should().BeFalse();

            _bookViewServiceMock.Verify(service => service.AddBookViewAsync(It.IsAny<BookView>()), Times.Once);

            _bookViewServiceMock.VerifyNoOtherCalls();

        }

    }
}
