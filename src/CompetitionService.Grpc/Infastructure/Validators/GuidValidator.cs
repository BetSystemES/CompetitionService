using CompetitionService.Grpc.Infastructure.ValidationRules;
using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.Validators
{
    public class GuidValidator : AbstractValidator<string>
    {
        public GuidValidator()
        {
            RuleFor(x => x)
                .MustBeValidGuid();
        }
    }
}
