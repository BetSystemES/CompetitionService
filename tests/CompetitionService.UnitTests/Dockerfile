#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tests/CompetitionService.UnitTests/CompetitionService.UnitTests.csproj", "tests/CompetitionService.UnitTests/"]
COPY ["src/CompetitionService.BusinessLogic/CompetitionService.BusinessLogic.csproj", "src/CompetitionService.BusinessLogic/"]
COPY ["src/CompetitionService.DataAccess/CompetitionService.DataAccess.csproj", "src/CompetitionService.DataAccess/"]
RUN dotnet restore "tests/CompetitionService.UnitTests/CompetitionService.UnitTests.csproj"
COPY . .
WORKDIR "/src/tests/CompetitionService.UnitTests"
RUN dotnet build "CompetitionService.UnitTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompetitionService.UnitTests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompetitionService.UnitTests.dll"]