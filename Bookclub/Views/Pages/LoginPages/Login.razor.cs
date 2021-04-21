using Bookclub.Data;
using Bookclub.Models.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages.LoginPages
{
    public partial class Login
    {
        private User user;
        public string LoginMessage { get; set; }

        protected override Task OnInitializedAsync()
        {
            // TODO: Need to rethink logic, may need to hit API to return ID
            user = new User();
            return base.OnInitializedAsync();

        }

        private async Task<bool> ValidateUser()
        {
            // Serialize user object
            string serializedUser = JsonConvert.SerializeObject(user);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = new HttpMethod("POST");
           // httpRequestMessage.RequestUri = new Uri("https://bookclubapiservicev2.azurewebsites.net/api/users");       
            httpRequestMessage.RequestUri = new Uri("https://localhost:5001/api/users/login");

            httpRequestMessage.Content = new StringContent(serializedUser);

            httpRequestMessage.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await Http.SendAsync(httpRequestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            // TODO: Handle valid response object

            if (response.StatusCode.ToString() == "OK")
            {
                var returnedUser = JsonConvert.DeserializeObject<User>(responseBody);

                await sessionStorage.SetItemAsync("emailAddress", user.email);
                await sessionStorage.SetItemAsync("token", user.AccessToken);

                ((CustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthenticated(user.password);
                NavigationManager.NavigateTo("/index");
            }
            else
            {
                LoginMessage = "Invalid username or password";
            }

            // TODO: Remove temporary code once API has proper login endpoint
            //((CustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthenticated(user.EmailAddress);
            //NavigationManager.NavigateTo("/index");
            //await sessionStorage.SetItemAsync("emailAddress", user.EmailAddress);

            return await Task.FromResult(true);
        }
    }
}
