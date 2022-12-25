FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY *.sln .
#COPY ["src/Shawa.Core/*.csproj", "Shawa.Core/"]
#COPY ["src/Shawa.Domain/*.csproj", "Shawa.Domain/"]
#COPY ["src/Shawa.Integration/*.csproj", "Shawa.Integration/"]
COPY ["src/Shawa.Bot.Api/*.csproj", "src/Shawa.Bot.Api/"]
COPY ["src/Shawa.Mattermost.Api/*.csproj", "src/Shawa.Mattermost.Api/"]
# Copy Production Configs
COPY ["/configs/shawa-bot-api.json", "src/Shawa.Bot.Api/appsettings.Production.json"]
COPY ["/configs/shawa-mattermost-api.json", "src/Shawa.Mattermost.Api/appsettings.Production.json"]
WORKDIR /
RUN dotnet restore
COPY . .
RUN dotnet build "/src/Shawa.Bot.Api/Shawa.Bot.Api.csproj" -c Release -o /app/shawa-bot-api/build
RUN dotnet build "/src/Shawa.Mattermost.Api/Shawa.Mattermost.Api.csproj" -c Release -o /app/shawa-mattermost-api/build

FROM build AS publish
RUN dotnet publish "/src/Shawa.Bot.Api/Shawa.Bot.Api.csproj" -c Release -o /app/shawa-bot-api/publish
RUN dotnet publish "/src/Shawa.Mattermost.Api/Shawa.Mattermost.Api.csproj" -c Release -o /app/shawa-mattermost-api/publish

FROM base AS shawa-bot-api-final
WORKDIR /app
COPY --from=publish /app/shawa-bot-api/publish .

ENTRYPOINT ["dotnet", "Shawa.Bot.Api.dll"]

FROM base AS shawa-mattermost-api-final
WORKDIR /app
COPY --from=publish /app/shawa-mattermost-api/publish .

ENTRYPOINT ["dotnet", "Shawa.Bot.Mattermost.dll"]
