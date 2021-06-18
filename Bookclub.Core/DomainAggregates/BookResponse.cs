using Bookclub.Core.DomainAggregates;
using System.Collections.Generic;

namespace Bookclub.Core.DomainAggregates
{
    public class BookResponse
    {
        public string ResponseMessage { get; set; }

        public List<Book> Books { get; set; }
    }


}
