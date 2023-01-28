using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Services;

using BusinessModels = CompetitionService.BusinessLogic.Models;

namespace CompetitionService.Grpc.Infastructure.Configurations
{
    public static partial class AppConfiguration
    {
        /// <summary>
        /// Adds the infrastructure services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(AuctionProfile).Assembly);
            services.AddScoped<ICompetitionService<BusinessModels.Competitions.CompetitionDota2>, CompetitionDota2Service>();

            return services;
        }
    }
}
