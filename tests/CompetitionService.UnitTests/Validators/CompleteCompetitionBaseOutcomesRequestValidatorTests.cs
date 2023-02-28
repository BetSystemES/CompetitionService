using CompetitionService.Grpc;
using CompetitionService.Grpc.Infastructure.Validators.Validators;
using FluentValidation;

namespace CompetitionService.UnitTests.Validators
{
    public class CompleteCompetitionBaseOutcomesRequestValidatorTests
    {
        private readonly IValidator<CompleteCompetitionBaseOutcomesRequest> _validator;

        public CompleteCompetitionBaseOutcomesRequestValidatorTests()
        {
            _validator = new CompleteCompetitionBaseOutcomesRequestValidator();
        }

        public async Task CompleteCompetitionBaseOutcomesRequest_Should_Be_Valid()
        {
            //var coefficientGroup = 
            //
            //var competitionBase = new CompetitionBase()
            //{
            //    Id = "b6f43b5a-c037-404e-8cfd-8d39b54d5e77",
            //    StartTime = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
            //    StatusType = CompetitionStatusType.Live,
            //    Type = CompetitionType.Esportdota2,
            //    CoefficientGroups = new List<CoefficientGroup>()
            //        {
            //            new CoefficientGroup()
            //            {
            //                Id = Guid.Parse("dcd66d95-2c8b-4480-9844-4a9e5f0531c8"),
            //                CompetitionBaseId = Guid.Parse("3d32fbb9-0034-4d75-b1d5-5c0a8398c885"),
            //                Name = "winner",
            //                Type = CoefficientGroupType.OneWinner,
            //                Coefficients= new List<Coefficient>()
            //                {
            //                    new Coefficient()
            //                    {
            //                        Id = Guid.Parse("f582c094-3b31-46ce-bc8a-a6650cb27c58"),
            //                        Description = "desc",
            //                        Amount= 0,
            //                        Rate = 1,
            //                        StatusType = CoefficientStatusType.Active,
            //                        Probability = 50,
            //                    },
            //                    new Coefficient()
            //                    {
            //                        CoefficientGroupId = Guid.Parse("e27543d8-f40b-4e8e-b04b-aaee17679ff7"),
            //                        Id = Guid.Parse("94e75b14-64f0-4ebc-8032-2a71c838e5c1"),
            //                        Description = "desc",
            //                        Amount= 0,
            //                        Rate = 1,
            //                        StatusType = CoefficientStatusType.Active,
            //                        Probability = 50,
            //                    },
            //                }
            //            },
            //            new CoefficientGroup()
            //            {
            //                Id = Guid.Parse("d641a457-5e36-40a2-8ead-41d14090c4c3"),
            //                Name = "most kills",
            //                Type = CoefficientGroupType.TwoWinners,
            //                Coefficients= new List<Coefficient>()
            //                {
            //                    new Coefficient()
            //                    {
            //                        Id = Guid.Parse("3b5e6bd4-00bf-4283-9a0e-f09c419957c4"),
            //                        Description = "desc",
            //                        Amount= 0,
            //                        Rate = 1,
            //                        StatusType = CoefficientStatusType.Active,
            //                        Probability = 50,
            //                    },
            //                    new Coefficient()
            //                    {
            //                        Id = Guid.Parse("1b0fabcc-0b77-4e85-8840-00185e8276df"),
            //                        Description = "desc",
            //                        Amount= 0,
            //                        Rate = 1,
            //                        StatusType = CoefficientStatusType.Active,
            //                        Probability = 50,
            //                    },
            //                }
            //            }
            //        }
            //};
            //
            //// Arrange
            //var model = new AddDiscountRequest()
            //{
            //    Discount = discount
            //};

            // Act
           //var result = await _validator.ValidateAsync();
           //
           //// Assert
           //result.IsValid
           //    .Should()
           //    .Be(false);
        }
    }
}
