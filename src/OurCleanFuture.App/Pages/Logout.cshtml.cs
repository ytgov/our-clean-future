using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OurCleanFuture.App.Pages;

public class LogoutModel : PageModel
{
    public LogoutModel(IConfiguration configuration) => Configuration = configuration;

    private IConfiguration Configuration { get; set; }

    public async Task OnGet()
    {
        await HttpContext.SignOutAsync(
            Configuration["AuthNProvider:Name"],
            new AuthenticationProperties
            {
                RedirectUri = Configuration["AuthNProvider:SignedOutCallbackPath"]
            }
        );
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
