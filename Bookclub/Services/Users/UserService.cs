﻿using Bookclub.Models.Users;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services.Users
{
    public class UserService : IUserService
    {
        // TODO: May be better way to pass around HTTP context in Blazor server. Research best practices
        public UserService()
        {

        }

        public User GetCurrentlyLoggedInUser(HttpContext ctx, string email)
        {
            var client = new RestClient($"https://bookclubapiservicev2.azurewebsites.net/api/Users");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            var bearerAccessToken = $"bearer " + ctx.Request.Cookies["access_token"]; // TODO: lock down routes and implement using session tokens for access

            request.AddHeader("Authorization", bearerAccessToken);
            IRestResponse userApiResponse = client.Execute(request);

            if (userApiResponse.StatusCode.ToString() != "OK")
            {
                // bad response
            }

            List<User> userList = JsonConvert.DeserializeObject<List<User>>(userApiResponse.Content);

            // TODO: Add validation if list is empty

 
            return userList.Where(x => x.email == email).FirstOrDefault();


        }
    }
}
