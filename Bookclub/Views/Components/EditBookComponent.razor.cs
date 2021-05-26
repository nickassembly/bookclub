using Bookclub.Models.AddBookComponents.Exceptions;
using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Bookclub.Models.Books.Exceptions;
using Bookclub.Models.Colors;
using Bookclub.Models.ContainerComponents;
using Bookclub.Services.Books;
using Bookclub.Services.BookViews;
using Bookclub.Views.Bases;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Bookclub.Views.Components
{
    public partial class EditBookComponent
    {
        [Inject]
        public IBookViewService BookViewService { get; set; }

        [Inject]
        public IBookService BookService { get; set; }

        [Parameter]
        public Book BookToEdit { get; set; }

        public ComponentState State { get; set; }
        public AddBookComponentException Exception { get; set; }
        public BookView BookView { get; set; }
        public TextBoxBase IsbnTextBox { get; set; }
        public TextBoxBase Isbn13TextBox { get; set; }
        public TextBoxBase TitleTextBox { get; set; }
        public TextBoxBase SubtitleTextBox { get; set; }
        public TextBoxBase AuthorTextBox { get; set; }
        public DropDownBase<BookViewMediaType> MediaTypeDropDown { get; set; }
        public TextBoxBase Publisher { get; set; }
        public TextBoxBase ListPrice { get; set; }
        public DatePickerBase PublishDatePicker { get; set; }
        public ButtonBase ConfirmEditButton { get; set; }
        public ButtonBase CancelEditButton { get; set; }
        public LabelBase StatusLabel { get; set; }

        protected override void OnInitialized()
        {

            this.BookView = new BookView
            {
                Id = BookToEdit.Id,
                Isbn = BookToEdit.Isbn,
                Isbn13 = BookToEdit.Isbn13,
                Title = BookToEdit.Title,
                Subtitle = BookToEdit.Subtitle,
                PrimaryAuthor = BookToEdit.Author,
                Publisher = BookToEdit.Publisher,
                ListPrice = BookToEdit.ListPrice.ToString(),
                PublishedDate = BookToEdit.PublishDate
              // MediaType = BookToEdit.MediaType
              // TODO: Fix Media Type
            };

            // TODO: Book data needs to be changeable in component and editbookasync should take edited data
            // currently it just passes the same book view data that is currently in the list. 

            this.State = ComponentState.Content;
        }

        public async void EditBookAsync(Book bookToEdit)
        {

            try
            {
               // Book newBookInfo = GetNewBookInfo();

                await BookViewService.EditBookAsync(bookToEdit);
                ReportEditingSuccess();
                NavigationManager.NavigateTo("books", true);
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public async void CancelEditAsync()
        {
            NavigationManager.NavigateTo("books", true);
        }

        public Book GetNewBookInfo()
        {
            Book newBookInfo = new Book();

            NavigationManager.NavigateTo("editbookcomponent", true);

            return newBookInfo;
        }

        private void ReportEditingSuccess()
        {
            this.StatusLabel.SetColor(Color.Green);
            this.StatusLabel.SetValue("Book Edited Successfully");
        }

    }
}
