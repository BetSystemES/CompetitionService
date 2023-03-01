// TODO: remove unused usings
using CompetitionService.Grpc.Infastructure.ValidationRules;
using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.Validators.Validators
{
    // TODO: Rename folder from Infastructure to Infrastructure
    // TODO: Change file location to CompetitionService.Grpc.Infrastructure.Validators
    public class CreateCompetitionDota2RequestValidator : AbstractValidator<CompetitionDota2>
    {
        public CreateCompetitionDota2RequestValidator()
        {
            RuleFor(x => x)
                .SetValidator(new CompetitionDota2Validtor());
        }
    }
}
