using System.Security.Claims;
using System.Security.Principal;

namespace Prueba.Extensions
{
    public static class IdentityExtensions
    {

        public static int GetId(this IIdentity identity)
        {
            if (identity == null) return -1;

            ClaimsIdentity? claimsIdentity = identity as ClaimsIdentity;

            if (claimsIdentity == null) return -1;

            Claim? claim = claimsIdentity.FindFirst("id");

            if (claim == null)
                return -1;

            return int.Parse(claim.Value);
        }

        public static string GetUsername(this IIdentity identity)
        {
            if (identity == null) return "";

            ClaimsIdentity? claimsIdentity = identity as ClaimsIdentity;

            if (claimsIdentity == null) return "";

            Claim? claim = claimsIdentity.FindFirst("username");

            if (claim == null)
                return "";

            return claim.Value;
        }
    }
}
