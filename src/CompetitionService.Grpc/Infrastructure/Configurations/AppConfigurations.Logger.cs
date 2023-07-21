using Serilog;

namespace CompetitionService.Grpc.Infrastructure.Configurations
{
    public static partial class AppConfigurations
    {
        /// <summary>
        /// Adds the serilog logger.
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        /// <returns>WebApplicationBuilder</returns>
        public static WebApplicationBuilder AddSerilogLogger(this WebApplicationBuilder appBuilder)
        {
            appBuilder.Host.UseSerilog((_, serviceProvider, config) =>
            {
                config = config.WriteTo.Console();
                config = appBuilder.Environment.IsDevelopment()
                    ? config.MinimumLevel.Debug()
                    : config.MinimumLevel.Warning();
            });

            return appBuilder;
        }
    }
}
