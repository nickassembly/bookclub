﻿using Bookclub.Models.ContainerComponents;
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

        }

    }
}
