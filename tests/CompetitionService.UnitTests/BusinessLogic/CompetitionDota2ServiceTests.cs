using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Entities;
using CompetitionService.BusinessLogic.Models.Enums;
using CompetitionService.BusinessLogic.Services;
using FluentAssertions;
using Moq;

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
            // TODO: use NBuilder library for data preparation
            // Arrange
            var competitionDota2 = new CompetitionDota2()
            {
                Id = Guid.Parse("7a679df5-9d39-45eb-a99b-c53eafc88a0b"),
                Team1Id = Guid.Parse("1b5735ce-43fb-4b5f-a8e2-0b89383f6593"),
                Team2Id = Guid.Parse("09d7eb50-901c-4f22-98f7-c9af474ac5b9"),
                Team1KillAmount = 1,
                Team2KillAmount = 1,
                CompetitionBaseId = Guid.Parse("e9f6c341-0137-413d-aa57-ad80c1d2e271"),
                TotalTime = DateTime.MinValue,
                CompetitionBase = new CompetitionBase()
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
                }

            };

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
            // TODO: use NBuilder library for data preparation
            // Arrange
            var competitionDota2 = new CompetitionDota2()
            {
                Id = Guid.Parse("7a679df5-9d39-45eb-a99b-c53eafc88a0b"),
                Team1Id = Guid.Parse("1b5735ce-43fb-4b5f-a8e2-0b89383f6593"),
                Team2Id = Guid.Parse("09d7eb50-901c-4f22-98f7-c9af474ac5b9"),
                Team1KillAmount = 1,
                Team2KillAmount = 1,
                CompetitionBaseId = Guid.Parse("e9f6c341-0137-413d-aa57-ad80c1d2e271"),
                TotalTime = DateTime.MinValue,
                CompetitionBase = new CompetitionBase()
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
                }

            };

            _mockCompetitionProvider.Setup(_ => _.GetById(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(competitionDota2));

            var id = Guid.Parse("510349bb-7c9d-47ac-bb51-8ed9fe1120ed");

            // Act
            var actualCompetition = await _competitionService.GetById(id, _ct);

            // Assert
            actualCompetition.Should()
                .BeEquivalentTo(competitionDota2);
        }

        [Fact]
        public async Task GetRange_Should_Return_RangeOfCompetitions()
        {
            // TODO: use NBuilder library for data preparation
            // Arrange
            var competitionDota2 = new CompetitionDota2()
            {
                Id = Guid.Parse("7a679df5-9d39-45eb-a99b-c53eafc88a0b"),
                Team1Id = Guid.Parse("1b5735ce-43fb-4b5f-a8e2-0b89383f6593"),
                Team2Id = Guid.Parse("09d7eb50-901c-4f22-98f7-c9af474ac5b9"),
                Team1KillAmount = 1,
                Team2KillAmount = 1,
                CompetitionBaseId = Guid.Parse("e9f6c341-0137-413d-aa57-ad80c1d2e271"),
                TotalTime = DateTime.MinValue,
                CompetitionBase = new CompetitionBase()
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
                }

            };

            var competitions = new List<CompetitionDota2>()
            {
                competitionDota2,
                competitionDota2,
                competitionDota2
            };

            var page = 1;
            var pageSize = 1;

            _mockCompetitionProvider.Setup(_ => _.GetRange(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(competitions));

            // Act
            var actualCompetitions = await _competitionService.GetRange(page, pageSize, _ct);

            // Assert
            actualCompetitions.Should()
                .BeEquivalentTo(competitions);
        }

        [Fact]
        public async Task Update_Should_Update()
        {
            // TODO: use NBuilder library for data preparation
            // Arrange
            var competitionDota2 = new CompetitionDota2()
            {
                Id = Guid.Parse("7a679df5-9d39-45eb-a99b-c53eafc88a0b"),
                Team1Id = Guid.Parse("1b5735ce-43fb-4b5f-a8e2-0b89383f6593"),
                Team2Id = Guid.Parse("09d7eb50-901c-4f22-98f7-c9af474ac5b9"),
                Team1KillAmount = 1,
                Team2KillAmount = 1,
                CompetitionBaseId = Guid.Parse("e9f6c341-0137-413d-aa57-ad80c1d2e271"),
                TotalTime = DateTime.MinValue,
                CompetitionBase = new CompetitionBase()
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
                }

            };

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
