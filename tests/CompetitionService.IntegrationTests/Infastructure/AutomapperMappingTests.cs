﻿// TODO: remove unused/sort usings
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

// TODO: rename Infastructure folder and namespace to Infrastructure
namespace CompetitionService.IntegrationTests.Infastructure
{
    public class AutomapperMappingTests : IClassFixture<GrpcAppFactory>, IDisposable
    {
        private readonly IServiceScope _scope;
        private readonly IMapper _mapper;

        public AutomapperMappingTests(GrpcAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _mapper = _scope.ServiceProvider.GetRequiredService<IMapper>();
        }

        [Fact]
        public void AutoMapper_Should_Have_Valid_Configuration()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
