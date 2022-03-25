using System.Security.Claims;

namespace OurCleanFuture.App;

public class StateContainer
{
    public ClaimsPrincipal ClaimsPrincipal { get; set; } = null!;

    private string? userPrincipal;

    public string UserPrincipal {
        get => userPrincipal ?? string.Empty;
        set {
            userPrincipal = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}