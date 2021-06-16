using Bookclub.Core.DomainAggregates;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Bookclub.Services.Users
{
    public interface IUserService
    {
        Task<User> GetCurrentlyLoggedInUser(HttpContext ctx, string email);
    }
}
