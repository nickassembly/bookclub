using Bookclub.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages.LoginPages
{
    public partial class SignUp
    {
        private User user;
        public string LoginMesssage { get; set; }

        protected override Task OnInitializedAsync()
        {
            user = new User();
            return base.OnInitializedAsync();
        }

        private async Task<bool> RegisterUser()
        {
            //assume that user is valid
            // user.Source = "APPC";
            var returnedUser = await userService.RegisterUserAsync(user); // TODO: Implement method, hit register endpoint in api

            if (returnedUser != null) // if is valid
                return await Task.FromResult(true);
            else
                return false;
        }
    }
}
