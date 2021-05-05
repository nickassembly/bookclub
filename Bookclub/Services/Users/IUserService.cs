using Bookclub.Models.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services.Users
{
    public interface IUserService
    {
        User GetCurrentlyLoggedInUser(HttpContext ctx, string email);
    }
}
