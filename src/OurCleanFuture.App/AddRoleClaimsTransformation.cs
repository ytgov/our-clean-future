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
    private readonly IConfiguration _configuration;

    public AddRoleClaimsTransformation(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var claimsIdentity = new ClaimsIdentity();
        if (!principal.HasClaim(claim => claim.Type == ClaimTypes.Role) && principal.Identity is not null) {
            if(principal.Identity.Name == GetAdministrators()) {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));
            }
            var user = await _context.Users.Include(u => u.Leads).SingleOrDefaultAsync(u => u.PrincipalName == principal.Identity.Name);
            if (user is not null) {
                foreach (var lead in user.Leads) {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, lead.Id.ToString()));
                }
            }
        }

        principal.AddIdentity(claimsIdentity);
        return principal;
    }

    public string GetAdministrators()
    {
        return _configuration["AdminUsers"];
    }
}
