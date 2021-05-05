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
        // TODO: Use Restsharp to /GET all users and match email, return user data
        public User GetCurrentlyLoggedInUser(string email)
        {
            throw new NotImplementedException();
        }
    }
}
