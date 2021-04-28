using Bookclub.Models.Books;
using RESTFulSense.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Brokers.API
{
    // TODO: Refactor this class to remove factory or reimpliment it in a more understandable way
    public partial class ApiBroker : IApiBroker
    {
      private readonly IRESTFulApiFactoryClient apiClient;

      public ApiBroker(IRESTFulApiFactoryClient apiClient) =>
         this.apiClient = apiClient;

      private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
         await this.apiClient.GetContentAsync<T>(relativeUrl);

        //private async ValueTask<T> PostAsync<T>(string relativeUrl, T content) =>
        //   await this.apiClient.PostContentAsync<T>(relativeUrl, content);

        public async Task<Book> PostBookAsync(Book book)
        {
            // TODO: api call here to add book to the database. May need to change method signature
            return new Book();
        }

        private async ValueTask<T> PutAsync<T>(string relativeUrl, T content) =>
         await this.apiClient.PutContentAsync<T>(relativeUrl, content);

      private async ValueTask<T> DeleteAsync<T>(string relativeUrl) =>
         await this.apiClient.DeleteContentAsync<T>(relativeUrl);

    }
}
