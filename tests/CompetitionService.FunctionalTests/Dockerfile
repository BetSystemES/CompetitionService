FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tests/CompetitionService.FunctionalTests/CompetitionService.FunctionalTests.csproj", "tests/CompetitionService.FunctionalTests/"]
RUN dotnet restore "tests/CompetitionService.FunctionalTests/CompetitionService.FunctionalTests.csproj"
COPY . .
WORKDIR "/src/tests/CompetitionService.FunctionalTests"
RUN dotnet build "CompetitionService.FunctionalTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompetitionService.FunctionalTests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "CompetitionService.FunctionalTests.dll"]