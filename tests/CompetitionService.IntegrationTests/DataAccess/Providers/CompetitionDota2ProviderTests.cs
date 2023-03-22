using Microsoft.Extensions.DependencyInjection;
using FizzWare.NBuilder;
using FluentAssertions;
using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.IntegrationTests.DataAccess.Providers
{
    public class CompetitionDota2ProviderTests : IClassFixture<GrpcAppFactory>, IDisposable
    {
        private static readonly CancellationToken _ct = CancellationToken.None;

        private readonly IServiceScope _scope;
        private readonly ICompetitionProvider<CompetitionDota2> _competitionProvider;
        private readonly ICompetitionRepository<CompetitionDota2> _competitionRepository;
        private readonly IDataContext _context;

        public CompetitionDota2ProviderTests(GrpcAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            _competitionProvider = _scope.ServiceProvider.GetRequiredService<ICompetitionProvider<CompetitionDota2>>();
            _competitionRepository = _scope.ServiceProvider.GetRequiredService<ICompetitionRepository<CompetitionDota2>>();
            _context = _scope.ServiceProvider.GetRequiredService<IDataContext>();
        }

        [Fact]
        public async Task GetRange_Should_Return_ListOfConstructions()
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
                .With(x => x.Id = Guid.NewGuid())
                .With(x => x.Team1Id = Guid.NewGuid())
                .With(x => x.Team2Id = Guid.NewGuid())
                .With(x => x.CompetitionBase = Builder<CompetitionBase>
                    .CreateNew()
                    .With(x => x.Id = Guid.NewGuid())
                    .With(x => x.CoefficientGroups = coefficientGroups.ToList())
                    .Build())
                .Build();

            // Act
            var page = 1;
            var pageSize = 1;

            await _competitionRepository.Create(competitionDota2, _ct);
            await _context.SaveChanges(_ct);

            var constructions = await _competitionProvider.GetRange(page, pageSize, _ct);
            // Assert
            constructions.Should()
                .NotBeNullOrEmpty();
            //TODO: add assert for equal
        }

        [Fact]
        public async Task GetById_Should_Return_Construction()
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
                .With(x => x.Id = Guid.Parse("7fcf3c1b-01a4-4ce0-b314-b1dfd625a720"))
                .With(x => x.Team1Id = Guid.NewGuid())
                .With(x => x.Team2Id = Guid.NewGuid())
                .With(x => x.CompetitionBase = Builder<CompetitionBase>
                    .CreateNew()
                    .With(x => x.Id = Guid.NewGuid())
                    .With(x => x.CoefficientGroups = coefficientGroups.ToList())
                    .Build())
                .Build();

            var competitionId = Guid.Parse("7fcf3c1b-01a4-4ce0-b314-b1dfd625a720");

            // Act

            await _competitionRepository.Create(competitionDota2, _ct);
            await _context.SaveChanges(_ct);

            var constructions = await _competitionProvider.GetById(competitionId, _ct);
            // Assert
            constructions.Should()
                .NotBeNull();
            //TODO: add assert for equal
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
