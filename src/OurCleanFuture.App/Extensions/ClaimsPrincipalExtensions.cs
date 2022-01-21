using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace OurCleanFuture.App.Extensions;
public static class ClaimsPrincipalExtensions
{
    public static string GetFormattedName(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value.Replace('.', ' ') ?? "";
    }
}
