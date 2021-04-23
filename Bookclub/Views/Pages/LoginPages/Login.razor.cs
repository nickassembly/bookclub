using Bookclub.Data;
using Bookclub.Models.Users;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages.LoginPages
{
    public partial class Login
    {
        private User user;
        public string LoginMessage { get; set; }

        protected override Task OnInitializedAsync()
        {
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
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.StatusCode.ToString() == "OK")
            {
                var returnedUser = JsonConvert.DeserializeObject<User>(responseBody);

                await sessionStorage.SetItemAsync("emailAddress", user.email);
                await sessionStorage.SetItemAsync("token", returnedUser.Token);
                await sessionStorage.SetItemAsync("refreshToken", returnedUser.RefreshToken);

                ((CustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthenticated(user.password);
                NavigationManager.NavigateTo("/index");
            }
            else
            {
                LoginMessage = "Invalid username or password";
            }

            return await Task.FromResult(true);
        }
    }
}
