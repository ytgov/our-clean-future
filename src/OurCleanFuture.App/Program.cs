using Serilog;
using Serilog.Events;

namespace OurCleanFuture.App;

public static class Program
{
    public static int Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateBootstrapLogger();

        try {
            Log.Information("Starting web host");
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        catch (Exception ex) {
            Log.Fatal(ex, "Host terminated unexpectedly");
            return 1;
        }
        finally {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
                .UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext())
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(opts => {
                        opts.ListenAnyIP(5000);
                        opts.ListenAnyIP(5001, opts => opts.UseHttps());
                    });
                })
                .UseWindowsService();
    }
}