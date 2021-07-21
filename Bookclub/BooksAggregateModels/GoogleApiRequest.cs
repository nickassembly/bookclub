using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.BooksAggregateModels
{
    public class GoogleApiRequest
    {
        // TODO: Add properties that can be used to search for book details
        public string Isbn { get; set; }
        public string Isbn13 { get; set; }
    }
}
