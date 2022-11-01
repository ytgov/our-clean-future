using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data;

namespace OurCleanFuture.App.Services;

public class StateContainerService
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
    private ClaimsPrincipal _claimsPrincipal = null!;
    private AppDbContext _context = null!;

    public StateContainerService(IDbContextFactory<AppDbContext> dbContextFactory) =>
        _dbContextFactory = dbContextFactory;

    public ClaimsPrincipal ClaimsPrincipal
    {
        get => _claimsPrincipal;
        set
        {
            _claimsPrincipal = value ?? throw new ArgumentNullException(nameof(ClaimsPrincipal));
            ClaimsPrincipalEmail = _claimsPrincipal.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Email)
                ?.Value.ToLower();
            if (ClaimsPrincipalEmail is not null)
            {
                Log.Information("{User} has established a connection", ClaimsPrincipalEmail);
                _context = _dbContextFactory.CreateDbContext();
                UserHasARole = _context.Users.Any(u => u.Email == ClaimsPrincipalEmail);
            }
        }
    }

    public string? ClaimsPrincipalEmail { get; private set; } = "";
    public bool UserHasARole { get; private set; }

    //public event Action? OnChange;
    //private void NotifyStateChanged() => OnChange?.Invoke();
}
