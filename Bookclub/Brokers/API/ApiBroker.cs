using RESTFulSense.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Brokers.API
{
    public class ApiBroker : IApiBroker
    {
      private readonly IRESTFulApiFactoryClient apiClient;

      public ApiBroker(IRESTFulApiFactoryClient apiClient) =>
         this.apiClient = apiClient;

      private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
         await this.apiClient.GetContentAsync<T>(relativeUrl);

      private async ValueTask<T> PostAsync<T>(string relativeUrl, T content) =>
         await this.apiClient.PostContentAsync<T>(relativeUrl, content);

      private async ValueTask<T> PutAsync<T>(string relativeUrl, T content) =>
         await this.apiClient.PutContentAsync<T>(relativeUrl, content);

      private async ValueTask<T> DeleteAsync<T>(string relativeUrl) =>
         await this.apiClient.DeleteContentAsync<T>(relativeUrl);
   }
}
