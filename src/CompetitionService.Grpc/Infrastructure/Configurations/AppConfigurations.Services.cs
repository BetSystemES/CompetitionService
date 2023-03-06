using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Services;
using CompetitionService.Grpc.Infastructure.Mappings;
using FluentValidation;
using BusinessEntities = CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.Grpc.Infastructure.Configurations
{
    public static partial class AppConfigurations
    {
        /// <summary>
        /// Adds the infrastructure services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CompetitionServiceProfile).Assembly);

            services.AddScoped<ICompetitionService<BusinessEntities.CompetitionDota2>, CompetitionDota2Service>();
            services.AddScoped<ICompetitionBaseService, CompetitionBaseService>();
            services.AddScoped<ICoefficientService, CoefficientService>();

            // TODO: Add new AppConfigurations partial class for fluent validation
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;
        }
    }
}
