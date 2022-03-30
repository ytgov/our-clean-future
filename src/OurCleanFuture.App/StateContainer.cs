using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data;
using System.Security.Claims;

namespace OurCleanFuture.App;

public class StateContainer
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
    private AppDbContext _context;

    private ClaimsPrincipal _claimsPrincipal;

    public StateContainer(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public ClaimsPrincipal ClaimsPrincipal {
        get => _claimsPrincipal;
        set {
            _claimsPrincipal = value ?? throw new ArgumentNullException(nameof(ClaimsPrincipal));
            UserPrincipal = _claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value.ToLower()
                ?? throw new InvalidOperationException("User is missing an email claim");
            _context = _dbContextFactory.CreateDbContext();
            UserHasARole = _context.Users.Any(u => u.Email == UserPrincipal);
        }
    }

    public string UserPrincipal { get; private set; }
    public bool UserHasARole { get; private set; }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}