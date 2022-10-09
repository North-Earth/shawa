FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Shawa.Mattermost.Api/Shawa.Mattermost.Api.csproj", "Shawa.Mattermost.Api/"]
WORKDIR /
RUN dotnet restore "src/Shawa.Mattermost.Api/Shawa.Mattermost.Api.csproj"
COPY . .
WORKDIR "/src/Shawa.Mattermost.Api"
RUN dotnet build "Shawa.Mattermost.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shawa.Mattermost.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shawa.Mattermost.Api.dll"]
