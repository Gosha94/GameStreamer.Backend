FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src/GameStreamer.Backend

COPY *.sln .
COPY ["src/Ugsk.Daemon.Consent.Domain/*.csproj", "./src/Ugsk.Daemon.Consent.Domain/"]
COPY ["src/Ugsk.Daemon.Consent.Application/*.csproj", "./src/Ugsk.Daemon.Consent.Application/"]
COPY ["src/Ugsk.Daemon.Consent.Infrastructure/*.csproj", "./src/Ugsk.Daemon.Consent.Infrastructure/"]
COPY ["src/Ugsk.Daemon.Consent.EntryPoint/*.csproj", "./src/Ugsk.Daemon.Consent.EntryPoint/"]

COPY ["tests/Ugsk.Daemon.Consent.Architecture.Tests/*.csproj", "./tests/Ugsk.Daemon.Consent.Architecture.Tests/"]
COPY ["tests/Ugsk.Daemon.Consent.IntegrationTests/*.csproj", "./tests/Ugsk.Daemon.Consent.IntegrationTests/"]
COPY ["tests/UGSK.Daemon.Consent.Test/*.csproj", "./tests/UGSK.Daemon.Consent.Test/"]


COPY ["GameStreamer.csproj", "."]
RUN dotnet restore "./GameStreamer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GameStreamer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameStreamer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameStreamer.dll"]

# ------------------------------
FROM artifacts.ugsk.ru:8085/mobile/runtime:5.0 AS base
WORKDIR /app

FROM artifacts.ugsk.ru:8085/mobile/sdk:5.0 AS build
WORKDIR /app/Ugsk.Daemon.Consent

COPY *.sln .
COPY ["src/Ugsk.Daemon.Consent.Domain/*.csproj", "./src/Ugsk.Daemon.Consent.Domain/"]
COPY ["src/Ugsk.Daemon.Consent.Application/*.csproj", "./src/Ugsk.Daemon.Consent.Application/"]
COPY ["src/Ugsk.Daemon.Consent.Infrastructure/*.csproj", "./src/Ugsk.Daemon.Consent.Infrastructure/"]
COPY ["src/Ugsk.Daemon.Consent.EntryPoint/*.csproj", "./src/Ugsk.Daemon.Consent.EntryPoint/"]

COPY ["tests/Ugsk.Daemon.Consent.Architecture.Tests/*.csproj", "./tests/Ugsk.Daemon.Consent.Architecture.Tests/"]
COPY ["tests/Ugsk.Daemon.Consent.IntegrationTests/*.csproj", "./tests/Ugsk.Daemon.Consent.IntegrationTests/"]
COPY ["tests/UGSK.Daemon.Consent.Test/*.csproj", "./tests/UGSK.Daemon.Consent.Test/"]

RUN dotnet restore --source https://artifacts.ugsk.ru/repository/nuget-group/ --source https://artifacts.ugsk.ru/repository/mobile-nuget-hosted/

COPY ["src/Ugsk.Daemon.Consent.Domain/.", "./src/Ugsk.Daemon.Consent.Domain/"]
COPY ["src/Ugsk.Daemon.Consent.Application/.", "./src/Ugsk.Daemon.Consent.Application/"]
COPY ["src/Ugsk.Daemon.Consent.Infrastructure/.", "./src/Ugsk.Daemon.Consent.Infrastructure/"]
COPY ["src/Ugsk.Daemon.Consent.EntryPoint/.", "./src/Ugsk.Daemon.Consent.EntryPoint/"]

RUN dotnet publish -c Release -o out

FROM base AS final
COPY --from=build /app/Ugsk.Daemon.Consent/out ./
ENTRYPOINT ["dotnet", "Ugsk.Daemon.Consent.EntryPoint.dll"]