using Bookclub.Models.AddBookComponents.Exceptions;
using Bookclub.Models.Books.BookViews;
using Bookclub.Models.Books.BookViews.Exceptions;
using Bookclub.Models.Books.Exceptions;
using Bookclub.Models.Colors;
using Bookclub.Models.ContainerComponents;
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
        public ComponentState State { get; set; }
        public AddBookComponentException Exception { get; set; }
        public BookView BookView { get; set; }
        public TextBoxBase IdTextBox { get; set; }
        public TextBoxBase IsbnTextBox { get; set; }
        public TextBoxBase Isbn13TextBox { get; set; }
        public TextBoxBase TitleTextBox { get; set; }
        public TextBoxBase SubtitleTextBox { get; set; }
        public TextBoxBase AuthorTextBox { get; set; }
        public DropDownBase<BookViewMediaType> MediaTypeDropDown { get; set; }
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
                await this.BookViewService.AddBookViewAsync(this.BookView);
                this.StatusLabel.SetColor(Color.Green);
                this.StatusLabel.SetValue("Submitted Successfully");
            }
            catch (BookViewValidationException bookViewValidationException)
            {
                string validationMessage = bookViewValidationException.InnerException.Message;

                this.StatusLabel.SetValue(validationMessage);
            }
            catch (BookViewDependencyValidationException dependencyValidationException)
            {
                string validationMessage = dependencyValidationException.InnerException.Message;

                this.StatusLabel.SetValue(validationMessage);
            }
            catch (BookViewDependencyException bookViewDependencyException)
            {
                string validationMessage = bookViewDependencyException.Message;

                this.StatusLabel.SetValue(validationMessage);
            }
            catch (BookViewServiceException bookViewServiceException)
            {
                string validationMessage = bookViewServiceException.Message;

                this.StatusLabel.SetValue(validationMessage);
            }
        }


    }
}
