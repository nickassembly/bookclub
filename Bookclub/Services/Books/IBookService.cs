﻿using Bookclub.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services.Books
{
    public interface IBookService
    {
        Task<BookResponse> AddBookAsync(Book book);
        void DeleteBookAsync();
    }
}
