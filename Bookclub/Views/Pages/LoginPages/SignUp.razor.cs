using Bookclub.Core.DomainAggregates;
using Bookclub.Data;
using Bookclub.Services.Users;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages.LoginPages
{
    public partial class SignUp
    {
        private User user;
        public string RegisterMessage { get; set; }

        // TODO: Add logger to log errors on failed api calls
        protected override Task OnInitializedAsync()
        {
            user = new User();
            return base.OnInitializedAsync();
        }

        private async Task<User> RegisterUser()
        {
            var client = new RestClient($"https://bookclubapiservicev2.azurewebsites.net/api/users/register");
            client.Timeout = -1;

            var registerUserRequest = new RestRequest(Method.POST);

            registerUserRequest.AddJsonBody(user);

            var userAddResponse = await client.ExecuteAsync<UserResponse>(registerUserRequest);


            if (userAddResponse.StatusCode.ToString() != "OK")
            {
                UserResponse invalidResponse = JsonConvert.DeserializeObject<UserResponse>(userAddResponse.Content);
                invalidResponse.ResponseMessage = $"Error Registering User: {userAddResponse.StatusCode}";
                RegisterMessage = $"Unable to create user. Name or email taken.";

                return null;
            }

            var returnedUser = JsonConvert.DeserializeObject<User>(userAddResponse.Content);
            await sessionStorage.SetItemAsync("emailAddress", user.email);
            await sessionStorage.SetItemAsync("token", returnedUser.Token);
            await sessionStorage.SetItemAsync("refreshToken", returnedUser.RefreshToken);

            ((CustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthenticated(user.password);
            NavigationManager.NavigateTo("/index");

            return returnedUser;

        }

    }
}
