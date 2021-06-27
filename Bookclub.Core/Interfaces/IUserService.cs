using Bookclub.Core.DomainAggregates;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Bookclub.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetCurrentlyLoggedInUser(HttpContext ctx, string email);
    }
}
