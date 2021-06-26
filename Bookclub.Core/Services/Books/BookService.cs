using Bookclub.Core.DomainAggregates;
using Bookclub.Core.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookclub.Core.Services.Books
{
    public partial class BookService : IBookService
    {
        public BookService()
        {

        }

        // TODO: invalid response and created response are coming back null
        public async Task<BookResponse> GetAllBooks()
        {
            var client = new RestClient($"https://bookclubapiservicev2.azurewebsites.net/api/books");

            client.Timeout = -1;

            //var bearerAccessToken = $"bearer " + ctx.Request.Cookies["access_token"]; // may need later

            var bookGetRequest = new RestRequest(Method.GET);

            //bookAddRequest.AddHeader("Authorization", bearerAccessToken); 

            var bookGetResponse = await client.ExecuteAsync<BookResponse>(bookGetRequest);

            if (bookGetResponse.StatusCode.ToString() != "OK")
            {
                BookResponse invalidResponse = JsonConvert.DeserializeObject<BookResponse>(bookGetResponse.Content);

                return invalidResponse;
            }

            List<Book> returnedBooks = JsonConvert.DeserializeObject<List<Book>>(bookGetResponse.Content);

            BookResponse createdResponse = new BookResponse
            {
                ResponseMessage = bookGetResponse.StatusCode.ToString(),
                Books = returnedBooks
            };

            return createdResponse;
        }

        public async Task<BookResponse> AddBookAsync(Book book)
        {
            var client = new RestClient($"https://bookclubapiservicev2.azurewebsites.net/api/books");

            client.Timeout = -1;

            var bookAddRequest = new RestRequest(Method.POST);

            bookAddRequest.AddJsonBody(book);

            var bookAddResponse = await client.ExecuteAsync<BookResponse>(bookAddRequest);

            if (bookAddResponse.StatusCode.ToString() != "OK")
            {
                BookResponse invalidResponse = JsonConvert.DeserializeObject<BookResponse>(bookAddResponse.Content);

                return invalidResponse;
            }

            BookResponse createdResponse = JsonConvert.DeserializeObject<BookResponse>(bookAddResponse.Content);

            return createdResponse;

        }

        public async Task<BookResponse> EditBookAsync(/*HttpContext ctx,*/ Book book)
        {
            var client = new RestClient($"https://bookclubapiservicev2.azurewebsites.net/api/books");

            client.Timeout = -1;

            var bookAddRequest = new RestRequest(Method.PUT);

            bookAddRequest.AddJsonBody(book);

            var bookAddResponse = await client.ExecuteAsync<BookResponse>(bookAddRequest);

            if (bookAddResponse.StatusCode.ToString() != "OK")
            {
                BookResponse invalidResponse = JsonConvert.DeserializeObject<BookResponse>(bookAddResponse.Content);

                return invalidResponse;
            }

            BookResponse createdResponse = JsonConvert.DeserializeObject<BookResponse>(bookAddResponse.Content);

            return createdResponse;

        }

        public async Task<BookResponse> DeleteBookAsync(Guid bookId)
        {

            var client = new RestClient($"https://bookclubapiservicev2.azurewebsites.net/api/books/{bookId}");

            client.Timeout = -1;

            var bookDeleteRequest = new RestRequest(Method.DELETE);

            var bookDeleteResponse = await client.ExecuteAsync<BookResponse>(bookDeleteRequest);

            if (bookDeleteResponse.StatusCode.ToString() != "OK")
            {
                BookResponse invalidResponse = JsonConvert.DeserializeObject<BookResponse>(bookDeleteResponse.Content);

                // handle logging and errors
                return invalidResponse;
            }

            BookResponse deletedResponse = JsonConvert.DeserializeObject<BookResponse>(bookDeleteResponse.Content);

            return deletedResponse;
        }

    }
}
