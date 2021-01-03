using Bookclub.Models.Basics;
using Bookclub.Views.Components;
using FluentAssertions;
using Tynamix.ObjectFiller;
using Xunit;

namespace Bookclub.Tests.Components
{
    public partial class BookFormComponentTests
    {
        [Fact]
        public void ShouldInitializeComponent()
        {
            // given when
            var initialBookFormComponent = new BookFormComponent();

            //then
            initialBookFormComponent.BookTextBox.Should().BeNull();
        }

        [Fact]
        public void ShouldRenderComponent()
        {
            // given
            ComponentState expectedState = ComponentState.Content;

            // when
            this.renderedBookFormComponent = RenderComponent<BookFormComponent>();

            // then
            this.renderedBookFormComponent.Instance.State.Should().BeEquivalentTo(expectedState);

            this.renderedBookFormComponent.Instance.BookTextBox.Should().NotBeNull();

            this.renderedBookFormComponent.Instance.BookTextBox.PlaceHolder.Should().BeEquivalentTo("Name");

        }
    }
}
