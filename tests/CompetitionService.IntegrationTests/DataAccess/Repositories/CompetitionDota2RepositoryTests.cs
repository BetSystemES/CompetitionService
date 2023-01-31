using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Enums;
using CompetitionService.BusinessLogic.Models;
using CompetitionService.BusinessLogic.Models.Competitions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace CompetitionService.IntegrationTests.DataAccess.Repositories
{
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

            var competitionDota2 = new CompetitionDota2()
            {
                Id = Guid.Parse("3248299a-700e-48bf-8601-eb48dc482813"),
                Team1Id = Guid.Parse("d8705402-b376-4a2b-8959-a8da15e96b9b"),
                Team2Id = Guid.Parse("a71f00c1-b271-422b-a18a-ae120b1227fd"),
                Team1KillAmount = 1,
                Team2KillAmount = 1,
                CompetitionBaseId = Guid.Parse("d4036d01-da0b-4809-b989-f085d517dec7"),
                TotalTime = DateTime.MinValue,
                CompetitionBase = new CompetitionBase()
                {
                    Id = Guid.Parse("d4036d01-da0b-4809-b989-f085d517dec7"),
                    StartTime = DateTime.MinValue,
                    StatusType = CompetitionStatusType.Live,
                    Type = CompetitionType.EsportDota2,
                    CoefficientGroups = new List<CoefficientGroup>()
                    {
                        new CoefficientGroup()
                        {
                            Id = Guid.Parse("c4c94cc4-5bae-47fe-be17-d8464a71e338"),
                            CompetitionBaseId = Guid.Parse("d4036d01-da0b-4809-b989-f085d517dec7"),
                            Name = "winner",
                            Type = CoefficientGroupType.OneWinner,
                            Coefficients= new List<Coefficient>()
                            {
                                new Coefficient()
                                {
                                    Id = Guid.Parse("6c4e5394-ab0a-4c15-b6cc-117b67f74db5"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                                new Coefficient()
                                {
                                    CoefficientGroupId = Guid.Parse("c4c94cc4-5bae-47fe-be17-d8464a71e338"),
                                    Id = Guid.Parse("10de3338-1995-4b77-9ca5-0ba4e8ff6f66"),
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
                            Id = Guid.Parse("2f87f471-e7d5-4ee4-b9d7-e37e86ae01e1"),
                            Name = "most kills",
                            Type = CoefficientGroupType.TwoWinners,
                            Coefficients= new List<Coefficient>()
                            {
                                new Coefficient()
                                {
                                    Id = Guid.Parse("9850b658-c7e8-40fe-958d-b13a8fca3d4c"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                                new Coefficient()
                                {
                                    Id = Guid.Parse("2484afdd-2fe3-4b77-aa02-975ba6687bd5"),
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
            var expectedCompetition = new CompetitionDota2()
            {
                Id = Guid.Parse("3248299a-700e-48bf-8601-eb48dc482813"),
                Team1Id = Guid.Parse("d8705402-b376-4a2b-8959-a8da15e96b9b"),
                Team2Id = Guid.Parse("a71f00c1-b271-422b-a18a-ae120b1227fd"),
                Team1KillAmount = 1,
                Team2KillAmount = 1,
                CompetitionBaseId = Guid.Parse("d4036d01-da0b-4809-b989-f085d517dec7"),
                TotalTime = DateTime.MinValue,
                CompetitionBase = new CompetitionBase()
                {
                    Id = Guid.Parse("d4036d01-da0b-4809-b989-f085d517dec7"),
                    StartTime = DateTime.MinValue,
                    StatusType = CompetitionStatusType.Live,
                    Type = CompetitionType.EsportDota2,
                    CoefficientGroups = new List<CoefficientGroup>()
                    {
                        new CoefficientGroup()
                        {
                            Id = Guid.Parse("c4c94cc4-5bae-47fe-be17-d8464a71e338"),
                            CompetitionBaseId = Guid.Parse("d4036d01-da0b-4809-b989-f085d517dec7"),
                            Name = "winner",
                            Type = CoefficientGroupType.OneWinner,
                            Coefficients= new List<Coefficient>()
                            {
                                new Coefficient()
                                {
                                    Id = Guid.Parse("6c4e5394-ab0a-4c15-b6cc-117b67f74db5"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                                new Coefficient()
                                {
                                    CoefficientGroupId = Guid.Parse("c4c94cc4-5bae-47fe-be17-d8464a71e338"),
                                    Id = Guid.Parse("10de3338-1995-4b77-9ca5-0ba4e8ff6f66"),
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
                            Id = Guid.Parse("2f87f471-e7d5-4ee4-b9d7-e37e86ae01e1"),
                            Name = "most kills",
                            Type = CoefficientGroupType.TwoWinners,
                            Coefficients= new List<Coefficient>()
                            {
                                new Coefficient()
                                {
                                    Id = Guid.Parse("9850b658-c7e8-40fe-958d-b13a8fca3d4c"),
                                    Description = "desc",
                                    Amount= 0,
                                    Rate = 1,
                                    StatusType = CoefficientStatusType.Active,
                                    Probability = 50,
                                },
                                new Coefficient()
                                {
                                    Id = Guid.Parse("2484afdd-2fe3-4b77-aa02-975ba6687bd5"),
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

            await _competitionRepository.Create(competitionDota2, _ct);
            await _context.SaveChanges(_ct);

            var existingCompetitionDota2Id = Guid.Parse("3248299a-700e-48bf-8601-eb48dc482813");
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
