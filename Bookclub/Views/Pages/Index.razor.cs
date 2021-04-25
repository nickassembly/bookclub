using Bookclub.Data;
using Bookclub.Models.Users;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages
{
    public partial class Index : ComponentBase
    {
        public User loggedInUser;
        protected override Task OnInitializedAsync()
        {
            GetUser();
            return base.OnInitializedAsync();
        }

        public User GetUser()
        {
            loggedInUser = new User();

            // TODO: Hook up GetCurrentlyLoggedInUser and populate here
            loggedInUser.email = "need get current user method";

            return loggedInUser;
        }
    }
}
