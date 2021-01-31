using Bookclub.Models.AddBookComponents.Exceptions;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.ContainerComponents;
using Bookclub.Services.BookViews;
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

    }
}
