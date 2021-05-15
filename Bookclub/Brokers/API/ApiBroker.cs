using Bookclub.Models.Books;
using Bookclub.Services.Books;
using Newtonsoft.Json;
using RESTFulSense.Clients;
using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Bookclub.Brokers.API
{
    public partial class ApiBroker : IApiBroker
    {
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient _http;

        public ApiBroker(IRESTFulApiFactoryClient apiClient, HttpClient http)
        {
            this.apiClient = apiClient;
            _http = http;
        }

        private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
           await this.apiClient.GetContentAsync<T>(relativeUrl);

        public async Task<BookResponse> PostBookAsync(/*HttpContext ctx,*/ Book book)
        {
            var client = new RestClient($"https://bookclubapiservicev2.azurewebsites.net/api/books");

            client.Timeout = -1;

            //var bearerAccessToken = $"bearer " + ctx.Request.Cookies["access_token"]; // may need later

            var bookAddRequest = new RestRequest(Method.POST);

            //bookAddRequest.AddHeader("Authorization", bearerAccessToken); 

            bookAddRequest.AddJsonBody(book);

            var bookAddResponse = await client.ExecuteAsync<BookResponse>(bookAddRequest);

            if (bookAddResponse.StatusCode.ToString() != "")
            {
                BookResponse invalidResponse = JsonConvert.DeserializeObject<BookResponse>(bookAddResponse.Content);

                // handle logging and errors
                return invalidResponse;
            }

            BookResponse createdResponse = JsonConvert.DeserializeObject<BookResponse>(bookAddResponse.Content);

            return createdResponse;

        }

        public async Task<BookResponse> EditBookAsync(/*HttpContext ctx,*/ Book book)
        {
            var client = new RestClient($"https://bookclubapiservicev2.azurewebsites.net/api/books");

            client.Timeout = -1;

            //var bearerAccessToken = $"bearer " + ctx.Request.Cookies["access_token"]; // may need later

            var bookAddRequest = new RestRequest(Method.PUT);

            //bookAddRequest.AddHeader("Authorization", bearerAccessToken); 

            bookAddRequest.AddJsonBody(book);

            var bookAddResponse = await client.ExecuteAsync<BookResponse>(bookAddRequest);

            if (bookAddResponse.StatusCode.ToString() != "")
            {
                BookResponse invalidResponse = JsonConvert.DeserializeObject<BookResponse>(bookAddResponse.Content);

                // handle logging and errors
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

            if (bookDeleteResponse.StatusCode.ToString() != "")
            {
                BookResponse invalidResponse = JsonConvert.DeserializeObject<BookResponse>(bookDeleteResponse.Content);

                // handle logging and errors
                return invalidResponse;
            }

            BookResponse deletedResponse = JsonConvert.DeserializeObject<BookResponse>(bookDeleteResponse.Content);

            return deletedResponse;
        }

        private async ValueTask<T> PutAsync<T>(string relativeUrl, T content) =>
         await this.apiClient.PutContentAsync<T>(relativeUrl, content);

        private async ValueTask<T> DeleteAsync<T>(string relativeUrl) =>
           await this.apiClient.DeleteContentAsync<T>(relativeUrl);

    }
}
