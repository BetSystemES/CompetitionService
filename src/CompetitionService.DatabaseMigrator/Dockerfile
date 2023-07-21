FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CompetitionService.DatabaseMigrator/CompetitionService.DatabaseMigrator.csproj", "src/CompetitionService.DatabaseMigrator/"]
COPY ["src/CompetitionService.DataAccess/CompetitionService.DataAccess.csproj", "src/CompetitionService.DataAccess/"]
COPY ["src/CompetitionService.BusinessLogic/CompetitionService.BusinessLogic.csproj", "src/CompetitionService.BusinessLogic/"]
RUN dotnet restore "src/CompetitionService.DatabaseMigrator/CompetitionService.DatabaseMigrator.csproj"
COPY . .
WORKDIR "/src/src/CompetitionService.DatabaseMigrator"
RUN dotnet build "CompetitionService.DatabaseMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompetitionService.DatabaseMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
