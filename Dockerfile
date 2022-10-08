FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY *.sln .
WORKDIR /src
#COPY ["src/Shawa.Core/*.csproj", "Shawa.Core/"]
#COPY ["src/Shawa.Domain/*.csproj", "Shawa.Domain/"]
#COPY ["src/Shawa.Integration/*.csproj", "Shawa.Integration/"]
COPY ["src/Shawa.Bot.Api/*.csproj", "Shawa.Bot.Api/"]
WORKDIR /
RUN dotnet restore
COPY . .
WORKDIR "/src/Shawa.Bot.Api"
RUN dotnet build "Shawa.Bot.Api.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "Shawa.Bot.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shawa.Bot.Api.dll"]
