using Bookclub.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services.Books
{
    public class BookResponse
    {
        public string ResponseMessage { get; set; }

        public List<Book> Books { get; set; }
    }


}
