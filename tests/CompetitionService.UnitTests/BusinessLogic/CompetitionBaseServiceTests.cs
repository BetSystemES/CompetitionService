using FizzWare.NBuilder;
using Moq;

using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Entities;
using CompetitionService.BusinessLogic.Services;

namespace CompetitionService.UnitTests.BusinessLogic
{
    public class CompetitionBaseServiceTests
    {
        private static readonly CancellationToken _ct = CancellationToken.None;

        private readonly ICompetitionBaseService _competitionBaseService;

        private readonly Mock<ICompetitionBaseProvider> _mockCompetitionBaseProvider;
        private readonly Mock<ICompetitionBaseRepository> _mockCompetitionBaseRepository;
        private readonly Mock<IDataContext> _mockDataContext;

        public CompetitionBaseServiceTests()
        {
            _mockCompetitionBaseProvider = new();
            _mockCompetitionBaseRepository = new();
            _mockDataContext = new();

            _competitionBaseService = new CompetitionBaseService(
                _mockCompetitionBaseProvider.Object,
                _mockCompetitionBaseRepository.Object,
                _mockDataContext.Object);
        }

        [Fact]
        public async Task BlockCompetitionBaseById_Should_UpdateAndSaveChanges()
        {
            // Arrange
            var id = Guid.NewGuid();

            var coefficients = Builder<Coefficient>
                .CreateListOfSize(2)
                .Build();

            var coefficientGroups = Builder<CoefficientGroup>
                .CreateListOfSize(2)
                .All()
                .With(x => x.Coefficients = coefficients.ToList())
                .Build();
            
            var competitionBaseToComplete = Builder<CompetitionBase>
                .CreateNew()
                .With(x => x.CoefficientGroups = coefficientGroups.ToList())
                .Build();

            _mockCompetitionBaseProvider.Setup(_ => _.GetById(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(competitionBaseToComplete);

            // Act
            await _competitionBaseService.BlockCompetitionBaseById(id, _ct);

            // Assert
            _mockCompetitionBaseRepository.Verify(_ => _.Update(
                It.IsAny<CompetitionBase>(),
                It.IsAny<CancellationToken>()),
                Times.Once);

            _mockDataContext.Verify(_ => _.SaveChanges(It.IsAny<CancellationToken>()),
                 Times.Once);
        }

        [Fact]
        public async Task CompleteCompetitionBaseOutcomes_Should_CompleteCompetitionStatuses()
        {
            // Arrange
            var competitionBaseToComplete = Builder<CompetitionBase>
                .CreateNew()
                .Build();

            // Act
            await _competitionBaseService.CompleteCompetitionBaseOutcomes(competitionBaseToComplete, _ct);

            // Assert
            _mockCompetitionBaseRepository.Verify(_ => _.Update(
                It.IsAny<CompetitionBase>(),
                It.IsAny<CancellationToken>()),
                Times.Once);

            _mockDataContext.Verify(_ => _.SaveChanges(It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
