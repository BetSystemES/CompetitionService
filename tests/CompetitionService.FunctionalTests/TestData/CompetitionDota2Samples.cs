using CompetitionService.BusinessLogic.Entities;
using CompetitionService.BusinessLogic.Models.Enums;

namespace CompetitionService.FunctionalTests.TestData
{
    public static class CompetitionDota2Samples
    {
        // TODO: remove all empty lines
        public static readonly CompetitionDota2 CompetitionDota2ValidModel = new CompetitionDota2()
        {
            // TODO: use NBuilder library for data preparation
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
    }
}
