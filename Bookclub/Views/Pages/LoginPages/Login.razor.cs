using Bookclub.Data;
using Bookclub.Models.Users;
using Bookclub.Services.Users;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages.LoginPages
{
    public partial class Login
    {
        private User user;
        public string LoginMessage { get; set; }

        // TODO: Add logging to failed api responses
        protected override Task OnInitializedAsync()
        {
            user = new User();
            return base.OnInitializedAsync();
        }

        private async Task<User> ValidateUser()
        {
            var client = new RestClient($"https://bookclubapiservicev2.azurewebsites.net/api/users/login");
            client.Timeout = -1;

            var registerUserRequest = new RestRequest(Method.POST);

            registerUserRequest.AddJsonBody(user);

            var userAddResponse = await client.ExecuteAsync<UserResponse>(registerUserRequest);

            if (userAddResponse.StatusCode.ToString() != "OK")
            {
                UserResponse invalidResponse = JsonConvert.DeserializeObject<UserResponse>(userAddResponse.Content);
                invalidResponse.ResponseMessage = $"Error Logging In User: {userAddResponse.StatusCode}";
                LoginMessage = $"Unable to log in user.";

                return null;
            }

            var validatedUser = JsonConvert.DeserializeObject<User>(userAddResponse.Content);
            await sessionStorage.SetItemAsync("emailAddress", user.email);
            await sessionStorage.SetItemAsync("token", validatedUser.Token);
            await sessionStorage.SetItemAsync("refreshToken", validatedUser.RefreshToken);

            ((CustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthenticated(user.password);
            NavigationManager.NavigateTo("/index");

            return validatedUser;
        }

    }
}
