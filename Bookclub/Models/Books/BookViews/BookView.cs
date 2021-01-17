using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books.BookViews
{
    public class BookView
    {
        public string Id { get; set; }
        public string Isbn { get; set; }
        public string Isbn13 { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string PrimaryAuthor { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
