using Microsoft.Extensions.DependencyInjection;

using FizzWare.NBuilder;
using FluentAssertions;

using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.IntegrationTests.DataAccess.Repositories
{
    // TODO: remove all empty lines
    public class CompetitionDota2RepositoryTests : IClassFixture<GrpcAppFactory>, IDisposable
    {
        private static readonly CancellationToken _ct = CancellationToken.None;

        private readonly IServiceScope _scope;
        private readonly ICompetitionProvider<CompetitionDota2> _competitionProvider;
        private readonly ICompetitionRepository<CompetitionDota2> _competitionRepository;
        private readonly IDataContext _context;

        public CompetitionDota2RepositoryTests(GrpcAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _competitionProvider = _scope.ServiceProvider.GetRequiredService<ICompetitionProvider<CompetitionDota2>>();
            _competitionRepository = _scope.ServiceProvider.GetRequiredService<ICompetitionRepository<CompetitionDota2>>();
            _context = _scope.ServiceProvider.GetRequiredService<IDataContext>();
        }

        [Fact]
        public async Task Create_Should_CreateDatabaseEntity()
        {
            // Arrange
            var coefficients = Builder<Coefficient>
                .CreateListOfSize(2)
                .All()
                .With(x => x.Id = Guid.NewGuid())
                .Build();

            var coefficientGroups = Builder<CoefficientGroup>
                .CreateListOfSize(2)
                .All()
                .With(x => x.Id = Guid.NewGuid())
                .With(x => x.Coefficients = coefficients.ToList())
                .Build();

            var competitionDota2 = Builder<CompetitionDota2>
                .CreateNew()
                .With(x => x.Id = Guid.Parse("7a679df5-9d39-45eb-a99b-c53eafc88a0b"))
                .With(x => x.Team1Id = Guid.NewGuid())
                .With(x => x.Team2Id = Guid.NewGuid())
                .With(x => x.CompetitionBase = Builder<CompetitionBase>
                    .CreateNew()
                    .With(x => x.Id = Guid.NewGuid())
                    .With(x => x.CoefficientGroups = coefficientGroups.ToList())
                    .Build())
                .Build();

            var existingCompetitionDota2Id = Guid.Parse("7a679df5-9d39-45eb-a99b-c53eafc88a0b");

            // Act
            await _competitionRepository.Create(competitionDota2, _ct);
            await _context.SaveChanges(_ct);

            var existingCompetitionDota = await _competitionProvider.GetById(existingCompetitionDota2Id, _ct);

            // Assert
            existingCompetitionDota.Should()
                .NotBeNull().And
                .BeEquivalentTo(competitionDota2);
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
