using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using OurCleanFuture.Data;

namespace OurCleanFuture.App;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(Configuration);
        services.AddScoped<IClaimsTransformation, AddRoleClaimsTransformation>();

        services.AddRazorPages();
        services.AddServerSideBlazor();

        services.Configure<CookiePolicyOptions>(options => {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        // Add authentication services
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie(options => {
            options.LoginPath = $"/{Configuration["AuthNProvider:LoginPath"]}";
            options.LogoutPath = $"/{Configuration["AuthNProvider:LogoutPath"]}";
        })
        .AddOpenIdConnect(Configuration["AuthNProvider:Name"], options => {
            options.Authority = $"https://{Configuration["AuthNProvider:Domain"]}";
            options.ClientId = Configuration["AuthNProvider:ClientId"];
            options.ClientSecret = Configuration["AuthNProvider:ClientSecret"];
            options.ResponseType = "code";

            options.Scope.Clear();
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("email");

            options.CallbackPath = Configuration["AuthNProvider:CallbackPath"];
            options.SignedOutCallbackPath = Configuration["AuthNProvider:SignedOutCallbackPath"];
            options.SignedOutRedirectUri = Configuration["AuthNProvider:SignedOutRedirectUri"];
            options.ClaimsIssuer = Configuration["AuthNProvider:Name"];

            options.Events = new OpenIdConnectEvents {
                OnRedirectToIdentityProviderForSignOut = (context) => {
                    var logoutUri = $"https://{Configuration["AuthNProvider:Domain"]}/v2/logout?client_id={Configuration["AuthNProvider:ClientId"]}";

                    var postLogoutUri = context.Properties.RedirectUri;
                    if (!string.IsNullOrEmpty(postLogoutUri)) {
                        if (postLogoutUri.StartsWith("/")) {
                            var request = context.Request;
                            postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                        }
                        logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                    }

                    context.Response.Redirect(logoutUri);
                    context.HandleResponse();

                    return Task.CompletedTask;
                }
            };

            options.Events.OnSignedOutCallbackRedirect = (context) => {

                context.Response.Redirect(options.SignedOutRedirectUri);
                context.HandleResponse();

                return Task.CompletedTask;
            };

        });

        // TODO: Adding the authz fallback policy is resulting in an infinite loop of login redirects.
        //services.AddAuthorization(options => {
        //    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        //        .RequireAuthenticatedUser()
        //        .Build();
        //});

        services.AddHttpContextAccessor();

        services.AddMudServices();
#if DEBUG
        services.AddDbContextFactory<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AppDbContext"), options => options.EnableRetryOnFailure())
                   .EnableSensitiveDataLogging());
#else
            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppDbContext"), options => options.EnableRetryOnFailure()));
#endif

        services.AddLocalization();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }
        else {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseRequestLocalization("en-CA");

        app.UseCookiePolicy();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}