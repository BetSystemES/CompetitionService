using CompetitionService.Grpc.Infastructure.ValidationRules;
using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.Validators.Validators
{
    public class CreateCompetitionDota2RequestValidator : AbstractValidator<CompetitionDota2>
    {
        public CreateCompetitionDota2RequestValidator()
        {
            RuleFor(x => x)
                .SetValidator(new CompetitionDota2Validtor());
        }
    }
}
