using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
  public static class UserManagerExtensions
  {
    public static async Task<AppUser> FindByUserByClaimsPrincipalEmailWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
    {
      var email = user.FindFirstValue(ClaimTypes.Email);

      return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
    }

    public static async Task<AppUser> FindByEmailFromClaimsPrincipalAsync(this UserManager<AppUser> input, ClaimsPrincipal user)
    {
      var email = user.FindFirstValue(ClaimTypes.Email);
      return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
    }
  }
}