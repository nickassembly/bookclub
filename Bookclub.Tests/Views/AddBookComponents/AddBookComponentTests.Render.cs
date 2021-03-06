﻿using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Colors;
using Bookclub.Models.ContainerComponents;
using Bookclub.Views.Components;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bookclub.Tests.Views.AddBookComponents
{
    public partial class AddBookComponentTests
    {
        [Fact]
        public void ShouldInitializeComponent()
        {
            // given
            ComponentState expectedComponentState = ComponentState.Loading;

            // when
            var initialBookAddComponent = new AddBookComponent();

            // then
            initialBookAddComponent.State.Should().Be(expectedComponentState);
            initialBookAddComponent.Exception.Should().BeNull();
            initialBookAddComponent.AuthorTextBox.Should().BeNull();
            initialBookAddComponent.Isbn13TextBox.Should().BeNull();
            initialBookAddComponent.IsbnTextBox.Should().BeNull();
            initialBookAddComponent.TitleTextBox.Should().BeNull();
            initialBookAddComponent.SubtitleTextBox.Should().BeNull();
         //   initialBookAddComponent.IdTextBox.Should().BeNull();
            initialBookAddComponent.SubmitButton.Should().BeNull();
            initialBookAddComponent.BookView.Should().BeNull();
            initialBookAddComponent.MediaTypeDropDown.Should().BeNull();
            initialBookAddComponent.PublishDatePicker.Should().BeNull();
            initialBookAddComponent.StatusLabel.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderComponent()
        {
            // given
            ComponentState expectedComponentState = ComponentState.Content;

            string expectedIsbnTextBoxPlaceholder = "Isbn";
            string expectedIsbn13TextBoxPlaceholder = "Isbn13";
            string expectedAuthorTextBoxPlaceholder = "Author";
            string expectedTitleTextBoxPlaceholder = "Title";
            string expectedSubtitleTextBoxPlaceholder = "Subtitle";
            string expectedIdTextBoxPlaceholder = "Id";
            string expectedSubmitButtonLabel = "Submit Book";

            // when
            _addBookComponent = RenderComponent<AddBookComponent>();

            // then
            _addBookComponent.Instance.BookView.Should().NotBeNull();

            _addBookComponent.Instance.State.Should().Be(expectedComponentState);

            _addBookComponent.Instance.IsbnTextBox.Should().NotBeNull();

            _addBookComponent.Instance.IsbnTextBox.IsDisabled.Should().BeFalse();

            _addBookComponent.Instance.IsbnTextBox.Placeholder.Should().Be(expectedIsbnTextBoxPlaceholder);

            _addBookComponent.Instance.Isbn13TextBox.Should().NotBeNull();

            _addBookComponent.Instance.Isbn13TextBox.IsDisabled.Should().BeFalse();

            _addBookComponent.Instance.Isbn13TextBox.Placeholder.Should().Be(expectedIsbn13TextBoxPlaceholder);

            _addBookComponent.Instance.AuthorTextBox.Should().NotBeNull();

            _addBookComponent.Instance.AuthorTextBox.IsDisabled.Should().BeFalse();

            _addBookComponent.Instance.AuthorTextBox.Placeholder.Should().Be(expectedAuthorTextBoxPlaceholder);

            _addBookComponent.Instance.TitleTextBox.Should().NotBeNull();

            _addBookComponent.Instance.TitleTextBox.IsDisabled.Should().BeFalse();

            _addBookComponent.Instance.TitleTextBox.Placeholder.Should().Be(expectedTitleTextBoxPlaceholder);

            _addBookComponent.Instance.SubtitleTextBox.Should().NotBeNull();

            _addBookComponent.Instance.SubtitleTextBox.IsDisabled.Should().BeFalse();

            _addBookComponent.Instance.SubtitleTextBox.Placeholder.Should().Be(expectedSubtitleTextBoxPlaceholder);

            _addBookComponent.Instance.MediaTypeDropDown.Value.Should().BeOfType(typeof(BookViewMediaType));

            _addBookComponent.Instance.MediaTypeDropDown.Should().NotBeNull();

            _addBookComponent.Instance.MediaTypeDropDown.IsDisabled.Should().BeFalse();

            //_addBookComponent.Instance.IdTextBox.Should().NotBeNull();

            //_addBookComponent.Instance.IdTextBox.IsDisabled.Should().BeFalse();

            //_addBookComponent.Instance.IdTextBox.Placeholder.Should().Be(expectedIdTextBoxPlaceholder);

            _addBookComponent.Instance.PublishDatePicker.Should().NotBeNull();

            _addBookComponent.Instance.PublishDatePicker.IsDisabled.Should().BeFalse();

            _addBookComponent.Instance.SubmitButton.Should().NotBeNull();

            _addBookComponent.Instance.SubmitButton.IsDisabled.Should().BeFalse();

            _addBookComponent.Instance.SubmitButton.Label.Should().Be(expectedSubmitButtonLabel);

            _addBookComponent.Instance.StatusLabel.Should().NotBeNull();
            _addBookComponent.Instance.StatusLabel.Value.Should().BeNull();

            _addBookComponent.Instance.Exception.Should().BeNull();

            _bookViewServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldDisplaySubmittingStatusAndDisableControlsBeforeBookSubmissionCompletes()
        {
            // given
            BookView someBookView = CreateRandomBookView();

            this._bookViewServiceMock.Setup(service => service.AddBookViewAsync(It.IsAny<BookView>()))
                .ReturnsAsync(
                    value: someBookView,
                    delay: TimeSpan.FromMilliseconds(500));

            // when
            _addBookComponent = RenderComponent<AddBookComponent>();

            _addBookComponent.Instance.SubmitButton.Click();

            // then
            _addBookComponent.Instance.StatusLabel.Value.Should().BeEquivalentTo("Submitting ... ");

            _addBookComponent.Instance.StatusLabel.Color.Should().Be(Color.Black);

          //  _addBookComponent.Instance.IdTextBox.IsDisabled.Should().BeTrue();
            _addBookComponent.Instance.Isbn13TextBox.IsDisabled.Should().BeTrue();
            _addBookComponent.Instance.IsbnTextBox.IsDisabled.Should().BeTrue();
            _addBookComponent.Instance.AuthorTextBox.IsDisabled.Should().BeTrue();
            _addBookComponent.Instance.TitleTextBox.IsDisabled.Should().BeTrue();
            _addBookComponent.Instance.SubtitleTextBox.IsDisabled.Should().BeTrue();
            _addBookComponent.Instance.PublishDatePicker.IsDisabled.Should().BeTrue();
            _addBookComponent.Instance.SubmitButton.IsDisabled.Should().BeTrue();

            _bookViewServiceMock.Verify(service => service.AddBookViewAsync(It.IsAny<BookView>()), Times.Once);

            _bookViewServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldSubmitBook()
        {
            // given
            BookView randomBookView = CreateRandomBookView();
            BookView inputBookView = randomBookView;
            BookView expectedBookView = inputBookView;

            // when
            _addBookComponent = RenderComponent<AddBookComponent>();

            _addBookComponent.Instance.IsbnTextBox.SetValue(inputBookView.Isbn);
            _addBookComponent.Instance.Isbn13TextBox.SetValue(inputBookView.Isbn13);
            _addBookComponent.Instance.AuthorTextBox.SetValue(inputBookView.PrimaryAuthor);
            _addBookComponent.Instance.TitleTextBox.SetValue(inputBookView.Title);
            _addBookComponent.Instance.SubtitleTextBox.SetValue(inputBookView.Subtitle);
         //   _addBookComponent.Instance.IdTextBox.SetValue(inputBookView.Id);
            _addBookComponent.Instance.MediaTypeDropDown.SetValue(inputBookView.MediaType);
            _addBookComponent.Instance.PublishDatePicker.SetValue(inputBookView.PublishedDate);

            _addBookComponent.Instance.SubmitButton.Click();

            // then
            _addBookComponent.Instance.IsbnTextBox.Value.Should().BeEquivalentTo(expectedBookView.Isbn);
            _addBookComponent.Instance.Isbn13TextBox.Value.Should().BeEquivalentTo(expectedBookView.Isbn13);
            _addBookComponent.Instance.AuthorTextBox.Value.Should().BeEquivalentTo(expectedBookView.PrimaryAuthor);
            _addBookComponent.Instance.TitleTextBox.Value.Should().BeEquivalentTo(expectedBookView.Title);
            _addBookComponent.Instance.SubtitleTextBox.Value.Should().BeEquivalentTo(expectedBookView.Subtitle);
         //   _addBookComponent.Instance.IdTextBox.Value.Should().BeEquivalentTo(expectedBookView.Id);
            _addBookComponent.Instance.MediaTypeDropDown.Value.Should().Be(expectedBookView.MediaType);
            _addBookComponent.Instance.PublishDatePicker.Value.Should().Be(expectedBookView.PublishedDate);

            _addBookComponent.Instance.StatusLabel.Value.Should().Be("Submitted Successfully");
            _addBookComponent.Instance.StatusLabel.Color.Should().Be(Color.Green);

            _bookViewServiceMock.Verify(service => service.AddBookViewAsync(_addBookComponent.Instance.BookView),
                Times.Once);

            _bookViewServiceMock.VerifyNoOtherCalls();


        }

    }
}
