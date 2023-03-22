using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Entities;
using CompetitionService.BusinessLogic.Services;

namespace CompetitionService.UnitTests.BusinessLogic
{
    public class CompetitionDota2ServiceTests
    {
        private static readonly CancellationToken _ct = CancellationToken.None;

        private readonly ICompetitionService<CompetitionDota2> _competitionService;

        private readonly Mock<ICompetitionProvider<CompetitionDota2>> _mockCompetitionProvider;
        private readonly Mock<ICompetitionRepository<CompetitionDota2>> _mockCompetitionRepository;
        private readonly Mock<IDataContext> _mockDataContext;

        public CompetitionDota2ServiceTests()
        {
            _mockCompetitionProvider = new();
            _mockCompetitionRepository = new();
            _mockDataContext = new();

            _competitionService = new CompetitionDota2Service(
                _mockCompetitionProvider.Object,
                _mockCompetitionRepository.Object,
                _mockDataContext.Object);
        }

        [Fact]
        public async Task Create_Should_Create()
        {
            // Arrange
            var competitionDota2 = Builder<CompetitionDota2>
                .CreateNew()
                .Build();

            // Act
            await _competitionService.Create(competitionDota2, _ct);

            // Assert
            _mockCompetitionRepository.Verify(_ => _.Create(
                It.IsAny<CompetitionDota2>(),
                It.IsAny<CancellationToken>()),
                Times.Once);

            _mockDataContext.Verify(_ => _.SaveChanges(It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task GetById_Should_Return_Competition()
        {
            // Arrange
            var id = Guid.NewGuid();

            var competitionDota2 = Builder<CompetitionDota2>
                .CreateNew()
                .Build();

            _mockCompetitionProvider.Setup(_ => _.GetById(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(competitionDota2);

            // Act
            var actualCompetition = await _competitionService.GetById(id, _ct);

            // Assert
            actualCompetition.Should()
                .BeEquivalentTo(competitionDota2);
        }

        [Fact]
        public async Task GetRange_Should_Return_RangeOfCompetitions()
        {
            // Arrange
            var competitions = Builder<CompetitionDota2>
                .CreateListOfSize(3)
                .Build();

            var page = 1;
            var pageSize = 1;

            _mockCompetitionProvider.Setup(_ => _.GetRange(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(competitions.ToList());

            // Act
            var actualCompetitions = await _competitionService.GetRange(page, pageSize, _ct);

            // Assert
            actualCompetitions.Should()
                .BeEquivalentTo(competitions);
        }

        [Fact]
        public async Task Update_Should_Update()
        {
            // Arrange
            var competitionDota2 = Builder<CompetitionDota2>
                .CreateNew()
                .Build();

            // Act
            await _competitionService.Update(competitionDota2, _ct);

            // Assert
            _mockDataContext.Verify(_ => _.SaveChanges(It.IsAny<CancellationToken>()),
                Times.Once);

            _mockCompetitionRepository.Verify(_ => _.Update(It.IsAny<CompetitionDota2>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
