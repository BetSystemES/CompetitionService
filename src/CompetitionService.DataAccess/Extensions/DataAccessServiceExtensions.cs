using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Entities;
using CompetitionService.DataAccess.Providers;
using CompetitionService.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompetitionService.DataAccess.Extensions
{
    public static class DataAccessServiceExtensions
    {
        public static IServiceCollection AddPostgreSqlContext(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContextPool<CompetitionDbContext>(options);
            services.AddScoped<IDataContext, CompetitionDataContext>();

            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<CompetitionDbContext>()
                    .Set<Coefficient>());
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<CompetitionDbContext>()
                    .Set<CoefficientGroup>());
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<CompetitionDbContext>()
                    .Set<CompetitionBase>());
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<CompetitionDbContext>()
                    .Set<CompetitionDota2>());

            return services;
        }

        /// <summary>Register the sql providers in service collection.</summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services
                .AddScoped<ICompetitionProvider<CompetitionDota2>, CompetitionDota2Provider>()
                .AddScoped<ICoefficientGroupProvider, CoefficientGroupProvider>()
                .AddScoped<ICompetitionBaseProvider, CompetitionBaseProvider>()
                .AddScoped<ICoefficientProvider, CoefficientProvider>();

            return services;
        }

        /// <summary>Register the sql repositories in service collection.</summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<ICompetitionRepository<CompetitionDota2>, CompetitionDota2Repository>()
                .AddScoped<ICoefficientGroupRepository, CoefficientGroupRepository>()
                .AddScoped<ICompetitionBaseRepository, CompetitionBaseRepository>()
                .AddScoped<ICoefficientRepository, CoefficientRepository>();

            return services;
        }
    }
}
