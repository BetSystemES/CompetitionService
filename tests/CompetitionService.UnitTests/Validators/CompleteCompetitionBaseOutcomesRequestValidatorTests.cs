using CompetitionService.Grpc;
using CompetitionService.Grpc.Infastructure.Validators.Validators;
using CompetitionService.UnitTests.TestHelpers;
using FluentAssertions;
using FluentValidation;
using FizzWare.NBuilder;
using Xunit.Abstractions;

namespace CompetitionService.UnitTests.Validators
{
    public class CompleteCompetitionBaseOutcomesRequestValidatorTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IValidator<CompleteCompetitionBaseOutcomesRequest> _validator;

        public CompleteCompetitionBaseOutcomesRequestValidatorTests(ITestOutputHelper output)
        {
            _validator = new CompleteCompetitionBaseOutcomesRequestValidator();
            _output = output;
        }

        [Fact]
        public async Task CompleteCompetitionBaseOutcomesRequest_Should_Be_Valid()
        {
            var competitionBase = CompetitionBaseCreator.CreateValid();

            // Arrange
            var model = new CompleteCompetitionBaseOutcomesRequest()
            {
                CompetitionBase = competitionBase
            };

            // Act
            var result = await _validator.ValidateAsync(model);

            _output.WriteLine(result.ToString());

            // Assert
            result.IsValid
                .Should()
                .Be(true);
        }
    }
}
