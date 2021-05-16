﻿using Bookclub.Data;
using Bookclub.Models.Users;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages.LoginPages
{
    public partial class SignUp
    {
        private User user;
        public string RegisterMessage { get; set; }

        protected override Task OnInitializedAsync()
        {
            user = new User();
            return base.OnInitializedAsync();
        }

        // TODO: Convert to RestSharp call...possibly add logging?

        private async Task<bool> RegisterUser()
        {
            // Serialize user object
            string serializedUser = JsonConvert.SerializeObject(user);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = new HttpMethod("POST");

            httpRequestMessage.RequestUri = new Uri("https://bookclubapiservicev2.azurewebsites.net/api/users/register");       

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
                // TODO: Need navigation button to bring unauthorized user back to login screen as an option.
                RegisterMessage = $"Unable to create user. Name or email taken.";
            }

            return await Task.FromResult(true);

        }
    }
}
