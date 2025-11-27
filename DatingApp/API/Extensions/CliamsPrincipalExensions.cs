

using System.Security.Claims;

namespace API.Extensions
{
    public static class CliamsPrincipalExensions
    {
        public static string GetMemberId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? throw new Exception("Can not get MemebrId from token");
        }
        
    }
}