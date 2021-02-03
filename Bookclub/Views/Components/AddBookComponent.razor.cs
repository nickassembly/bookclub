using Bookclub.Models.AddBookComponents.Exceptions;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.ContainerComponents;
using Bookclub.Services.BookViews;
using Bookclub.Views.Bases;
using Microsoft.AspNetCore.Components;

namespace Bookclub.Views.Components
{
    public partial class AddBookComponent
    {
        [Inject]
        public IBookViewService BookViewService { get; set; }
        public ComponentState State { get; set; }
        public AddBookComponentException Exception { get; set; }
        public BookView BookView { get; set; }
        public TextBoxBase IdTextBox { get; set; }
        public TextBoxBase IsbnTextBox { get; set; }
        public TextBoxBase Isbn13TextBox { get; set; }
        public TextBoxBase TitleTextBox { get; set; }
        public TextBoxBase SubtitleTextBox { get; set; }
        public TextBoxBase AuthorTextBox { get; set; }
        public ButtonBase SubmitButton { get; set; }

        protected override void OnInitialized()
        {
            this.State = ComponentState.Content;
        }

    }
}
