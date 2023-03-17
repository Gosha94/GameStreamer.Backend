FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src/GameStreamer.Backend

COPY *.sln .
COPY ["src/GameStreamer.Domain/*.csproj", "./src/GameStreamer.Domain/"]
COPY ["src/GameStreamer.Application/*.csproj", "./src/GameStreamer.Application/"]
COPY ["src/GameStreamer.Infrastructure/*.csproj", "./src/GameStreamer.Infrastructure/"]
COPY ["src/GameStreamer.Presentation/*.csproj", "./src/GameStreamer.Presentation/"]
COPY ["src/GameStreamer.UI/*.csproj", "./src/GameStreamer.UI/"]

COPY ["tests/GameStreamer.Architecture.Tests/*.csproj", "./tests/GameStreamer.Architecture.Tests/"]

RUN dotnet restore -s https://api.nuget.org/v3/index.json --packages packages --ignore-failed-sources

COPY ["src/GameStreamer.Domain/.", "./src/GameStreamer.Domain/"]
COPY ["src/GameStreamer.Application/.", "./src/GameStreamer.Application/"]
COPY ["src/GameStreamer.Infrastructure/.", "./src/GameStreamer.Infrastructure/"]
COPY ["src/GameStreamer.Presentation/.", "./src/GameStreamer.Presentation/"]
COPY ["src/GameStreamer.UI/.", "./src/GameStreamer.UI/"]

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build /src/GameStreamer.Backend/out ./
ENTRYPOINT ["dotnet", "GameStreamer.UI.dll"]