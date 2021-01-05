using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Books
{
    public class Book
    {
        public int BookId { get; set; }
        public int CollectionType { get; set; }
        public string Id { get; set; }
        public string Isbn { get; set; }
        public string Isbn13 { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string PrimaryAuthor { get; set; }
        public string Thumbnail { get; set; }
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
        public string SmallThumbnail { get; set; }
        public string ExtraLarge { get; set; }
        public string Language { get; set; }
        public string SelfLink { get; set; }
        public string Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Description { get; set; }
        public decimal ListPrice { get; set; }
        public string ListCurrencyCode { get; set; }
        public string Country { get; set; }
    }
}
