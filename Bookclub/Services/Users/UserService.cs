using Bookclub.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services.Users
{
    public class UserService : IUserService
    {
        // TODO: Implement this method
        public int GetCurrentlyLoggedInUser() => 0; 

        public async Task<User> RegisterUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
