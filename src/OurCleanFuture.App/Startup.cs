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
            options.LoginPath = $"/{Configuration["Auth0:LoginPath"]}";
            options.LogoutPath = $"/{Configuration["Auth0:LogoutPath"]}";
        })
        .AddOpenIdConnect("Auth0", options => {
            options.Authority = $"https://{Configuration["Auth0:Domain"]}";
            options.ClientId = Configuration["Auth0:ClientId"];
            options.ClientSecret = Configuration["Auth0:ClientSecret"];
            options.ResponseType = "code";

            options.Scope.Clear();
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("email");

            options.CallbackPath = new PathString("/signin-oidc");
            options.ClaimsIssuer = "Auth0";

            options.Events = new OpenIdConnectEvents {
                OnRedirectToIdentityProviderForSignOut = (context) => {
                    var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

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
            options.UseSqlServer(Configuration.GetConnectionString("AppContext"), options => options.EnableRetryOnFailure())
                   .EnableSensitiveDataLogging());
#else
            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppContext"), options => options.EnableRetryOnFailure()));
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