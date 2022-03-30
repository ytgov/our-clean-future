using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data;

namespace OurCleanFuture.App;

public class AddRoleClaimsTransformation : IClaimsTransformation
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AddRoleClaimsTransformation(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        bool UserIsAdministrator(string email)
        {
            return _configuration["AdminUsers"].Contains(email, StringComparison.OrdinalIgnoreCase);
        }

        var claimsIdentity = new ClaimsIdentity();
        if (!principal.HasClaim(claim => claim.Type == ClaimTypes.Role) && principal.Identity is not null)
        {
            var email = (principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value) ?? "";
            if (UserIsAdministrator(email))
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));
            }
            var user = await _context.Users.Include(u => u.Leads).SingleOrDefaultAsync(u => u.Email == email);
            if (user is not null)
            {
                foreach (var lead in user.Leads)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, lead.Id.ToString()));
                }
            }
        }

        principal.AddIdentity(claimsIdentity);
        return principal;
    }
}
