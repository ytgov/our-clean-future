#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ClimateChangeIndicators.API/ClimateChangeIndicators.API.csproj", "ClimateChangeIndicators.API/"]
RUN dotnet restore "ClimateChangeIndicators.API/ClimateChangeIndicators.API.csproj"
COPY . .
WORKDIR "/src/ClimateChangeIndicators.API"
RUN dotnet build "ClimateChangeIndicators.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClimateChangeIndicators.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClimateChangeIndicators.API.dll"]