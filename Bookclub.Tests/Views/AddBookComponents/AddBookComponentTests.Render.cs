using Bookclub.Models.ContainerComponents;
using Bookclub.Views.Components;
using FluentAssertions;
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
            initialBookAddComponent.IdTextBox.Should().BeNull();
            initialBookAddComponent.SubmitButton.Should().BeNull();
            initialBookAddComponent.BookView.Should().BeNull();
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
            _addBookComponent.Instance.State.Should().Be(expectedComponentState);

            _addBookComponent.Instance.IsbnTextBox.Should().NotBeNull();
            _addBookComponent.Instance.IsbnTextBox.Placeholder.Should().Be(expectedIsbnTextBoxPlaceholder);

            _addBookComponent.Instance.Isbn13TextBox.Should().NotBeNull();
            _addBookComponent.Instance.Isbn13TextBox.Placeholder.Should().Be(expectedIsbn13TextBoxPlaceholder);

            _addBookComponent.Instance.AuthorTextBox.Should().NotBeNull();
            _addBookComponent.Instance.AuthorTextBox.Placeholder.Should().Be(expectedAuthorTextBoxPlaceholder);

            _addBookComponent.Instance.TitleTextBox.Should().NotBeNull();
            _addBookComponent.Instance.TitleTextBox.Placeholder.Should().Be(expectedTitleTextBoxPlaceholder);

            _addBookComponent.Instance.SubtitleTextBox.Should().NotBeNull();
            _addBookComponent.Instance.SubtitleTextBox.Placeholder.Should().Be(expectedSubtitleTextBoxPlaceholder);

            _addBookComponent.Instance.IdTextBox.Should().NotBeNull();
            _addBookComponent.Instance.IdTextBox.Placeholder.Should().Be(expectedIdTextBoxPlaceholder);

            _addBookComponent.Instance.SubmitButton.Should().NotBeNull();
            _addBookComponent.Instance.SubmitButton.Label.Should().Be(expectedSubmitButtonLabel);

            _addBookComponent.Instance.BookView.Should().BeNull();
            _addBookComponent.Instance.Exception.Should().BeNull();

            _bookViewServiceMock.VerifyNoOtherCalls();


        }

    }
}
