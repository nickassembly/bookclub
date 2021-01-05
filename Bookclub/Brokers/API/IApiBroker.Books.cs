using Bookclub.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Brokers.API
{
    public partial interface IApiBroker
    {
        ValueTask<Book> PostBookAsync(Book book);
    }
}
