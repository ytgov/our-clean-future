#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["src/OurCleanFuture.App/OurCleanFuture.App.csproj", "src/OurCleanFuture.App/"]
COPY ["src/OurCleanFuture.Data/OurCleanFuture.Data.csproj", "src/OurCleanFuture.Data/"]
RUN dotnet restore "src/OurCleanFuture.App/OurCleanFuture.App.csproj"
COPY . .
WORKDIR "/src/src/OurCleanFuture.App"
RUN dotnet build "OurCleanFuture.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OurCleanFuture.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OurCleanFuture.App.dll"]