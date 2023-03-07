using FluentValidation;

namespace CompetitionService.Grpc.Infrastructure.Configurations
{
    public static partial class AppConfigurations
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;
        }
    }
}
