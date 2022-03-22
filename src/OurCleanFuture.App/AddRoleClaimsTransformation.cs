using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.App;
public class AddRoleClaimsTransformation : IClaimsTransformation
{
    private readonly AppDbContext _context;

    public AddRoleClaimsTransformation(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var claimsIdentity = new ClaimsIdentity();
        if (!principal.HasClaim(claim => claim.Type == ClaimTypes.Role) && principal.Identity is not null) {
            var user = await _context.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.PrincipalName == principal.Identity.Name);
            if (user is not null) {
                foreach (var role in user.Roles) {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
                }
            }
        }

        principal.AddIdentity(claimsIdentity);
        return principal;
    }
}
