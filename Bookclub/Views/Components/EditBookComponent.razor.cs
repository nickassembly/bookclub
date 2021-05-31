using Bookclub.Models.AddBookComponents.Exceptions;
using Bookclub.Models.Books;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Colors;
using Bookclub.Models.ContainerComponents;
using Bookclub.Services.Books;
using Bookclub.Services.BookViews;
using Bookclub.Views.Bases;
using Microsoft.AspNetCore.Components;
using System;

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

        [Parameter]
        public string BookListPrice { get; set; }
        public ComponentState State { get; set; }
       // public AddBookComponentException Exception { get; set; }
        public BookView BookView { get; set; }
        public TextBoxBase IsbnTextBox { get; set; }
        public TextBoxBase Isbn13TextBox { get; set; }
        public TextBoxBase TitleTextBox { get; set; }
        public TextBoxBase SubtitleTextBox { get; set; }
        public TextBoxBase AuthorTextBox { get; set; }
        //public DropDownBase<BookViewMediaType> MediaTypeDropDown { get; set; }
        public TextBoxBase PublisherTextBox { get; set; }
        public TextBoxBase ListPrice { get; set; }
        public DatePickerBase PublishDatePicker { get; set; }
        public ButtonBase ConfirmEditButton { get; set; }
        public ButtonBase CancelEditButton { get; set; }
        public LabelBase StatusLabel { get; set; }

        // TODO: Need better way to handle publish date picker
        private DateTimeOffset _publishDateInput;
        [Parameter]
        public DateTimeOffset PublishDateInput
        {
            get => _publishDateInput;
            set
            {
                if (_publishDateInput == value) return;
                _publishDateInput = value;
                PublishDateInputChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<DateTimeOffset> PublishDateInputChanged { get; set; }

        private string Isbn { get; set; }
        private string Isbn13 { get; set; }
        private string Author { get; set; }
        private string Title { get; set; }
        private string Subtitle { get; set; }
        private string Publisher { get; set; }

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

            this.State = ComponentState.Content;
        }

        // TODO: need client side validation.

        public async void EditBookAsync(Book bookToEdit)
        {
            decimal uneditedListPrice = bookToEdit.ListPrice;

            try
            {

                bookToEdit.Isbn = !string.IsNullOrEmpty(Isbn) ? Isbn : bookToEdit.Isbn;
                bookToEdit.Author = !string.IsNullOrEmpty(Author) ? Author : bookToEdit.Author;
                bookToEdit.Isbn13 = !string.IsNullOrEmpty(Isbn13) ? Isbn13 : bookToEdit.Isbn13;
                bookToEdit.Title = !string.IsNullOrEmpty(Title) ? Title : bookToEdit.Title;
                bookToEdit.Subtitle = !string.IsNullOrEmpty(Subtitle) ? Subtitle : bookToEdit.Subtitle;
                bookToEdit.Publisher = !string.IsNullOrEmpty(Publisher) ? Publisher : bookToEdit.Publisher;

                bookToEdit.PublishDate = PublishDateInput != default ? PublishDateInput : bookToEdit.PublishDate;

                if (Convert.ToDecimal(BookListPrice) == 0)
                    bookToEdit.ListPrice = uneditedListPrice;
                else
                    bookToEdit.ListPrice = Convert.ToDecimal(BookListPrice);

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
