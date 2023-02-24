﻿using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Services;
using CompetitionService.Grpc.Infastructure.Mappings;
using FluentValidation;
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
            services.AddAutoMapper(typeof(CompetitionServiceProfile).Assembly);

            services.AddScoped<ICompetitionService<BusinessModels.Competitions.CompetitionDota2>, CompetitionDota2Service>();
            services.AddScoped<ICompetitionBaseService, CompetitionBaseService>();
            services.AddScoped<ICoefficientService, CoefficientService>();

            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;
        }
    }
}
