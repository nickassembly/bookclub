using Bookclub.Models.Books.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Isbn { get; set; }
        public string Isbn13 { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public BookMediaType MediaType { get; set; }
        public string Publisher { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public decimal ListPrice { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

    }
}
