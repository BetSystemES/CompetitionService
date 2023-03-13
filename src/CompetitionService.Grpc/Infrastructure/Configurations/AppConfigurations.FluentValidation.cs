using FluentValidation;

namespace CompetitionService.Grpc.Infrastructure.Configurations
{
    public static partial class AppConfigurations
    {
        /// <summary>
        /// Add validators.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFluentValidation (this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;
        }
    }
}
