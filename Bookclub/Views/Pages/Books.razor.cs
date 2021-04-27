using Bookclub.Models.Books;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages
{
    public partial class Books
    {
        public Book Book { get; set; }

        public List<Book> BookList { get; set; } = new List<Book>();

        protected override async Task OnInitializedAsync()
        {
            await GetBooks();
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            List<Book> bookList = new List<Book>();

            BookList = await http.GetJsonAsync<List<Book>>("https://bookclubapiservicev2.azurewebsites.net/api/books");

            return bookList;
        }
    }
}
