# Our Clean Future

This app is used by 10 departments in Yukon Government to record data on ~230 indicators for the [Our Clean Future](https://yukon.ca/our-clean-future) initiative.

>We live in a world that’s rapidly changing. Climate change is threatening ecosystems, subsistence harvesting, infrastructure, leisure activities, and many other aspects of our >lives.
>
>Yukon’s population is growing, along with our need for reliable, affordable and renewable energy to continue to power our lives, our work and our economy. New economic >opportunities are emerging in the sustainable, green economy.
>
>Our Clean Future is our answer to the climate emergency.
>
>The Government of Yukon developed Our Clean Future in partnership with Yukon First Nations, transboundary Indigenous groups and Yukon municipalities over the course of 3 years. >During this time, the partner group gathered 4 times to establish a vision and values for Our Clean Future and to prioritize the areas we should focus on over the next 10 years >to respond to the climate emergency. As a result of this collaborative process, the strategy reflects multiple perspectives, worldviews and ideas.

## Stack

* UI Component Library: [MudBlazor](https://github.com/Garderoben/MudBlazor)
* Web Framework: [ASP.NET Core 6](https://github.com/dotnet/aspnetcore) and [Blazor Server](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
* Data Access: [Entity Framework Core](https://github.com/dotnet/efcore)
* Data Store: SQL Server
* Logging: [Serilog](https://github.com/serilog/serilog)

## How do I run this?

See <https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations> if you are new to Entity Framework Core.

Ensure that you have LocalDB installed, or override the "AppContext" connection string in appsettings.json

### Build the project and restore packages

Using the .NET CLI:

```bash
dotnet build
```

### Create and seed the database with test data

.NET CLI:

```bash
dotnet ef database update
```

Or, using VS Package Manager Console (PowerShell):

```pwsh
Update-Database
```

### Run the app

.NET CLI:

```bash
dotnet run
```
