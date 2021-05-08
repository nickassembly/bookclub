using Bookclub.Models.AddBookComponents.Exceptions;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Bookclub.Models.Books.Exceptions;
using Bookclub.Models.Colors;
using Bookclub.Models.ContainerComponents;
using Bookclub.Services.Books;
using Bookclub.Services.BookViews;
using Bookclub.Views.Bases;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Bookclub.Views.Components
{
    public partial class AddBookComponent
    {
        [Inject]
        public IBookViewService BookViewService { get; set; }

        [Inject]
        public IBookService BookService { get; set; }

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
        public ButtonBase SubmitButton { get; set; }
        public LabelBase StatusLabel { get; set; }

        protected override void OnInitialized()
        {
            this.BookView = new BookView();
            this.State = ComponentState.Content;
        }

        public async void AddBookAsync()
        {
            try
            {
                ApplySubmittingStatus();
                await this.BookViewService.AddBookViewAsync(this.BookView);
                ReportBookSubmissionSucceeded();
                NavigationManager.NavigateTo("books", true);
                
            }
            catch (BookViewValidationException bookViewValidationException)
            {
                string validationMessage = bookViewValidationException.InnerException.Message;

                ApplySubmissionFailed(validationMessage);
            }
            catch (BookViewDependencyValidationException dependencyValidationException)
            {
                string validationMessage = dependencyValidationException.InnerException.Message;

                ApplySubmissionFailed(validationMessage);
            }
            catch (BookViewDependencyException bookViewDependencyException)
            {
                string validationMessage = bookViewDependencyException.Message;

                ApplySubmissionFailed(validationMessage);
            }
            catch (BookViewServiceException bookViewServiceException)
            {
                string validationMessage = bookViewServiceException.Message;

                ApplySubmissionFailed(validationMessage);
            }
        }

        private void ApplySubmittingStatus()
        {
            this.StatusLabel.SetColor(Color.Black);
            this.StatusLabel.SetValue("Submitting ... ");
            this.IsbnTextBox.Disable();
            this.Isbn13TextBox.Disable();
            this.AuthorTextBox.Disable();
            this.TitleTextBox.Disable();
            this.SubtitleTextBox.Disable();
            this.PublishDatePicker.Disable();
            this.SubmitButton.Disable();
        }

        private void ReportBookSubmissionSucceeded()
        {
            this.StatusLabel.SetColor(Color.Green);
            this.StatusLabel.SetValue("Submitted Successfully");
        }

        private void ApplySubmissionFailed(string errorMessage)
        {
            this.StatusLabel.SetColor(Color.Red);
            this.StatusLabel.SetValue(errorMessage);
            this.IsbnTextBox.Enable();
            this.Isbn13TextBox.Enable();
            this.AuthorTextBox.Enable();
            this.TitleTextBox.Enable();
            this.SubtitleTextBox.Enable();
            this.PublishDatePicker.Enable();
            this.SubmitButton.Enable();
        }

    }
}
