using Bookclub.Core.DomainAggregates;
using Bookclub.Core.Interfaces;
using Bookclub.Models.Colors;
using Bookclub.Models.ContainerComponents;
using Bookclub.Shared;
using Bookclub.Views.Bases;
using Microsoft.AspNetCore.Components;
using System;

namespace Bookclub.Views.Components
{
    public partial class AddBookComponent
    {
        // Added for error logging
        [CascadingParameter]
        public Error Error { get; set; }

        [Inject]
        public IBookViewService BookViewService { get; set; }

        [Inject]
        public IBookService BookService { get; set; }

        public ComponentState State { get; set; }
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
        public ButtonBase CancelAddButton { get; set; }
        public LabelBase StatusLabel { get; set; }

        protected override void OnInitialized()
        {
            this.BookView = new BookView();
            this.State = ComponentState.Content;

            // TODO: Refactor catch blocks to call Error.ProcessError to use global error component
            // something similar to below
            try
            {

            }
            catch (Exception ex)
            {
                // Call global error component process error method
                Error.ProcessError(ex);
            }
  
        }

        // TODO: Add Logging
        public async void AddBookAsync()
        {
            try
            {
                ApplySubmittingStatus();
                await this.BookViewService.AddBookViewAsync(this.BookView);
                ReportBookSubmissionSucceeded();
                NavigationManager.NavigateTo("books", true);
                
            }
            catch
            {
                // TODO: Define exceptions
            }
           
        }

        public async void CancelAddAsync()
        {
            NavigationManager.NavigateTo("books", true);
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
