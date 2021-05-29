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

        private string _isbnInput;
        [Parameter]
        public string IsbnInput
        {
            get => _isbnInput;
            set
            {
                if (_isbnInput == value) return;
                _isbnInput = value;
                IsbnInputChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> IsbnInputChanged { get; set; }

        private string _isbn13Input;
        [Parameter]
        public string Isbn13Input
        {
            get => _isbn13Input;
            set
            {
                if (_isbn13Input == value) return;
                _isbn13Input = value;
                Isbn13InputChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> Isbn13InputChanged { get; set; }

        private string _authorInput;
        [Parameter]
        public string AuthorInput
        {
            get => _authorInput;
            set
            {
                if (_authorInput == value) return;
                _authorInput = value;
                AuthorInputChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> AuthorInputChanged { get; set; }

        private string _titleInput;
        [Parameter]
        public string TitleInput
        {
            get => _titleInput;
            set
            {
                if (_titleInput == value) return;
                _titleInput = value;
                TitleInputChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> TitleInputChanged { get; set; }

        private string _subTitleInput;
        [Parameter]
        public string SubTitleInput
        {
            get => _subTitleInput;
            set
            {
                if (_subTitleInput == value) return;
                _subTitleInput = value;
                SubTitleInputChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> SubTitleInputChanged { get; set; }

        private string _mediaTypeInput;
        [Parameter]
        public string MediaTypeInput
        {
            get => _mediaTypeInput;
            set
            {
                if (_mediaTypeInput == value) return;
                _mediaTypeInput = value;
                MediaTypeInputChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> MediaTypeInputChanged { get; set; }

        private string _publisherInput;
        [Parameter]
        public string PublisherInput
        {
            get => _publisherInput;
            set
            {
                if (_publisherInput == value) return;
                _publisherInput = value;
                PublisherInputChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> PublisherInputChanged { get; set; }

        private string _listPriceInput;
        [Parameter]
        public string ListPriceInput
        {
            get => _listPriceInput;
            set
            {
                if (_listPriceInput == value) return;
                _listPriceInput = value;
                ListPriceInputChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> ListPriceInputChanged { get; set; }

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



            this.State = ComponentState.Content;
        }

        // TODO: need client side validation.
        // TODO: better way to handle edit book component labels/placeholders
        public async void EditBookAsync(Book bookToEdit)
        {
            decimal uneditedListPrice = bookToEdit.ListPrice;

            try
            {
                bookToEdit.Isbn = IsbnInput != null ? IsbnInput : bookToEdit.Isbn;
                bookToEdit.Author = AuthorInput != null ? AuthorInput : bookToEdit.Author;
                bookToEdit.Isbn13 = Isbn13Input != null ? Isbn13Input : bookToEdit.Isbn13;
                bookToEdit.Title = TitleInput != null ? TitleInput : bookToEdit.Title;
                bookToEdit.Subtitle = SubTitleInput != null ? SubTitleInput : bookToEdit.Subtitle;
                bookToEdit.Publisher = PublisherInput != null ? PublisherInput : bookToEdit.Publisher;
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
