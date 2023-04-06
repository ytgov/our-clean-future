using System.Security.Claims;

namespace OurCleanFuture.App.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetFormattedName(this ClaimsPrincipal claimsPrincipal)
    {
        var email = claimsPrincipal.FindFirst(ClaimTypes.Email);
        if (email == null)
        {
            return string.Empty;
        }
        return email.Value.Substring(0, email.Value.IndexOf('@')).Replace('.', ' ');
    }
}
