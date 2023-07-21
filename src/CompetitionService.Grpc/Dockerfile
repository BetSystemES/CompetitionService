FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CompetitionService.Grpc/CompetitionService.Grpc.csproj", "src/CompetitionService.Grpc/"]
COPY ["src/CompetitionService.BusinessLogic/CompetitionService.BusinessLogic.csproj", "src/CompetitionService.BusinessLogic/"]
COPY ["src/CompetitionService.DataAccess/CompetitionService.DataAccess.csproj", "src/CompetitionService.DataAccess/"]
RUN dotnet restore "src/CompetitionService.Grpc/CompetitionService.Grpc.csproj"
COPY . .
WORKDIR "/src/src/CompetitionService.Grpc"
RUN dotnet build "CompetitionService.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompetitionService.Grpc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompetitionService.Grpc.dll"]