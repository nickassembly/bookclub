using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.BookViews
{
    public class BookView
    {
        public Guid Id { get; set; }
        public string Isbn { get; set; }
        public string Isbn13 { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string PrimaryAuthor { get; set; }
        public DateTimeOffset PublishedDate { get; set; } = DateTime.Now;

        public BookViewMediaType MediaType { get; set; }

    }
}
