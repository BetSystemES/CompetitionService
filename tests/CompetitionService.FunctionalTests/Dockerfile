FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tests/CompetitionService.FunctionalTests/CompetitionService.FunctionalTests.csproj", "tests/CompetitionService.FunctionalTests/"]
COPY ["src/CompetitionService.DataAccess/CompetitionService.DataAccess.csproj", "src/CompetitionService.DataAccess/"]
COPY ["src/CompetitionService.BusinessLogic/CompetitionService.BusinessLogic.csproj", "src/CompetitionService.BusinessLogic/"]
COPY ["src/CompetitionService.Grpc/CompetitionService.Grpc.csproj", "src/CompetitionService.Grpc/"]
RUN dotnet restore "tests/CompetitionService.FunctionalTests/CompetitionService.FunctionalTests.csproj"
COPY . .
WORKDIR "/src/tests/CompetitionService.FunctionalTests"
RUN dotnet build "CompetitionService.FunctionalTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompetitionService.FunctionalTests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM publish AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test", "CompetitionService.FunctionalTests.dll"]