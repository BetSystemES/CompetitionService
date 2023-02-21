using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.Services;
using Moq;
using CompetitionService.BusinessLogic.Services;
using CompetitionService.BusinessLogic.Models.Competitions;
using CompetitionService.BusinessLogic.Enums;
using CompetitionService.BusinessLogic.Models;

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
        public async Task BlockCompetitionBaseById_Should_BlockCompetitionById() //todo: rename
        {
            // Arrange

            var id = Guid.Parse("f3793808-0fc6-4e57-a9ec-20ff7c85ddfc");

            var competitionBaseToComplete = new CompetitionBase()
            {
                Id = Guid.Parse("b6f43b5a-c037-404e-8cfd-8d39b54d5e77"),
                StartTime = DateTime.MinValue,
                StatusType = CompetitionStatusType.Live,
                Type = CompetitionType.EsportDota2,
                CoefficientGroups = new List<CoefficientGroup>()
                    {
                        new CoefficientGroup()
                        {
                            Id = Guid.Parse("dcd66d95-2c8b-4480-9844-4a9e5f0531c8"),
                            CompetitionBaseId = Guid.Parse("3d32fbb9-0034-4d75-b1d5-5c0a8398c885"),
                            Name = "winner",
                            Type = CoefficientGroupType.OneWinner,
                            Coefficients= new List<Coefficient>()
                            {
                                new Coefficient()
                                {
                                    Id = Guid.Parse("f582c094-3b31-46ce-bc8a-a6650cb27c58"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                                new Coefficient()
                                {
                                    CoefficientGroupId = Guid.Parse("e27543d8-f40b-4e8e-b04b-aaee17679ff7"),
                                    Id = Guid.Parse("94e75b14-64f0-4ebc-8032-2a71c838e5c1"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                            }
                        },
                        new CoefficientGroup()
                        {
                            Id = Guid.Parse("d641a457-5e36-40a2-8ead-41d14090c4c3"),
                            Name = "most kills",
                            Type = CoefficientGroupType.TwoWinners,
                            Coefficients= new List<Coefficient>()
                            {
                                new Coefficient()
                                {
                                    Id = Guid.Parse("3b5e6bd4-00bf-4283-9a0e-f09c419957c4"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                                new Coefficient()
                                {
                                    Id = Guid.Parse("1b0fabcc-0b77-4e85-8840-00185e8276df"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                            }
                        }
                    }
            };

            _mockCompetitionBaseProvider.Setup(_ => _.GetById(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(competitionBaseToComplete));

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

            var competitionBaseToComplete = new CompetitionBase()
            {
                Id = Guid.Parse("b6f43b5a-c037-404e-8cfd-8d39b54d5e77"),
                StartTime = DateTime.MinValue,
                StatusType = CompetitionStatusType.Live,
                Type = CompetitionType.EsportDota2,
                CoefficientGroups = new List<CoefficientGroup>()
                    {
                        new CoefficientGroup()
                        {
                            Id = Guid.Parse("dcd66d95-2c8b-4480-9844-4a9e5f0531c8"),
                            CompetitionBaseId = Guid.Parse("3d32fbb9-0034-4d75-b1d5-5c0a8398c885"),
                            Name = "winner",
                            Type = CoefficientGroupType.OneWinner,
                            Coefficients= new List<Coefficient>()
                            {
                                new Coefficient()
                                {
                                    Id = Guid.Parse("f582c094-3b31-46ce-bc8a-a6650cb27c58"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                                new Coefficient()
                                {
                                    CoefficientGroupId = Guid.Parse("e27543d8-f40b-4e8e-b04b-aaee17679ff7"),
                                    Id = Guid.Parse("94e75b14-64f0-4ebc-8032-2a71c838e5c1"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                            }
                        },
                        new CoefficientGroup()
                        {
                            Id = Guid.Parse("d641a457-5e36-40a2-8ead-41d14090c4c3"),
                            Name = "most kills",
                            Type = CoefficientGroupType.TwoWinners,
                            Coefficients= new List<Coefficient>()
                            {
                                new Coefficient()
                                {
                                    Id = Guid.Parse("3b5e6bd4-00bf-4283-9a0e-f09c419957c4"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                                new Coefficient()
                                {
                                    Id = Guid.Parse("1b0fabcc-0b77-4e85-8840-00185e8276df"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                            }
                        }
                    }
            };

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
