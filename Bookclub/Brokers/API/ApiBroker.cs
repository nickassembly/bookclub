using Bookclub.Models.Books;
using Bookclub.Models.Books.Books;
using Bookclub.Services.Books;
using Microsoft.AspNetCore.Http;
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

        //private async ValueTask<T> PostAsync<T>(string relativeUrl, T content) =>
        //   await this.apiClient.PostContentAsync<T>(relativeUrl, content);

        public async Task<Book> PostBookAsync(Book book)
        {

            string serializedBook = JsonConvert.SerializeObject(book);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = new HttpMethod("POST");

            httpRequestMessage.RequestUri = new Uri("https://bookclubapiservicev2.azurewebsites.net/api/books");

            httpRequestMessage.Content = new StringContent(serializedBook);

            httpRequestMessage.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _http.SendAsync(httpRequestMessage);

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.StatusCode.ToString() == "OK")
            {
                var returnedBook = JsonConvert.DeserializeObject<Book>(responseBody);

                return returnedBook;
            }
            else
            {

            }

            return null;
        }

        // TODO: Need to add logic to save user cookies once book table is locked down
        public async Task<BookResponse> PostBookAsync2(/*HttpContext ctx,*/ Book book)
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

        private async ValueTask<T> PutAsync<T>(string relativeUrl, T content) =>
         await this.apiClient.PutContentAsync<T>(relativeUrl, content);

        private async ValueTask<T> DeleteAsync<T>(string relativeUrl) =>
           await this.apiClient.DeleteContentAsync<T>(relativeUrl);

    }
}
