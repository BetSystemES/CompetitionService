using CompetitionService.DataAccess;
using CompetitionService.Grpc.Infastructure.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args).
    AddAppSettings();

var configuration = builder.Configuration;

builder.Services
    .AddGrpc()
    .Services
    .AddInfrastructureServices()
    .AddProviders()
    .AddRepositories()
    .AddPostgreSqlContext(options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("CompetitionDb"));
    });

var app = builder.Build();

app.MapGrpcService<CompetitionService.Grpc.Services.CompetitionService>();

app.Run();


namespace CompetitionService.Grpc
{
    public partial class Program { }
}
