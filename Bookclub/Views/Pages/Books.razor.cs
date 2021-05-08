using Bookclub.Models.Books;
using Bookclub.Services.Books;
using Bookclub.Services.BookViews;
using Bookclub.Views.Bases;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookclub.Models.Colors;
using Color = Bookclub.Models.Colors.Color;

namespace Bookclub.Views.Pages
{
    public partial class Books
    {
        public Book Book { get; set; }
        public ButtonBase DeleteButton { get; set; }
        public LabelBase StatusLabel { get; set; }

        [Inject]
        public IBookViewService BookViewService { get; set; }

        public List<Book> BookList { get; set; } = new List<Book>();

        protected override async Task OnInitializedAsync()
        {
            await GetBooks();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            List<Book> bookList = new List<Book>();

            BookList = await Http.GetJsonAsync<List<Book>>("https://bookclubapiservicev2.azurewebsites.net/api/books");

            return bookList;
        }

        // TODO: Error handling on delete reference add book component
        // need to implement submission status for user feedback on button
        public async Task<BookResponse> DeleteBookAsync(Guid bookId)
        {
            try
            {
                ApplyDeletingStatus();
                await BookViewService.DeleteBookAsync(bookId);
                ReportBookDeletionSucceeded();
                // TODO: Refresh Page function
                NavigationManager.NavigateTo("books", true);
            }
            catch (System.Exception)
            {

                throw;
            }

            return null;
        }

        private void ApplyDeletingStatus()
        {
            this.StatusLabel.SetColor(Color.Black);
            this.StatusLabel.SetValue("Deleting ... ");
        }

        private void ReportBookDeletionSucceeded()
        {
            this.StatusLabel.SetColor(Color.Red);
            this.StatusLabel.SetValue("Deleted Successfully");
        }


    }
}
