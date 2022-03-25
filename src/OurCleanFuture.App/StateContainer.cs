using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.App;
public class StateContainer
{
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
