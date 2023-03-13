using CompetitionService.DataAccess.Extensions;
using CompetitionService.Grpc.Infrastructure.Configurations;
using CompetitionService.Grpc.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args).
    AddAppSettings();

var configuration = builder.Configuration;

builder.Services.Configure<ServiceEndpointsSettings>(
    builder.Configuration.GetSection("ServiceEndpointsSettings"));

builder.Services
    .AddGrpc()
    .Services
    .AddInfrastructureServices()
    .AddProviders()
    .AddRepositories()
    .AddFluentValidation ()
    .AddPostgreSqlContext(options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("CompetitionDb"));
    })
    .AddGrpcClients();

var app = builder.Build();

app.MapGrpcService<CompetitionService.Grpc.Services.CompetitionService>();

app.Run();

namespace CompetitionService.Grpc
{
    public partial class Program
    { }
}
