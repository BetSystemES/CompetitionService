FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tests/CompetitionService.IntegrationTests/CompetitionService.IntegrationTests.csproj", "tests/CompetitionService.IntegrationTests/"]
COPY ["src/CompetitionService.Grpc/CompetitionService.Grpc.csproj", "src/CompetitionService.Grpc/"]
COPY ["src/CompetitionService.BusinessLogic/CompetitionService.BusinessLogic.csproj", "src/CompetitionService.BusinessLogic/"]
COPY ["src/CompetitionService.DataAccess/CompetitionService.DataAccess.csproj", "src/CompetitionService.DataAccess/"]
RUN dotnet restore "tests/CompetitionService.IntegrationTests/CompetitionService.IntegrationTests.csproj"
COPY . .
WORKDIR "/src/tests/CompetitionService.IntegrationTests"
RUN dotnet build "CompetitionService.IntegrationTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompetitionService.IntegrationTests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "CompetitionService.IntegrationTests.dll"]