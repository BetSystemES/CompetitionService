using CompetitionService.Grpc.Infastructure.ValidationRules;
using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.Validators
{
    public class CoefficientGroupValidator : AbstractValidator<CoefficientGroup>
    {
        private static readonly string _typeName = nameof(CoefficientGroup);

        public CoefficientGroupValidator()
        {
            RuleForEach(x => x.Coefficients)
                .Where(x => x is not null)
                .SetValidator(new CoefficientValidator());

            RuleFor(x => x.Name)
                .Must(x => string.IsNullOrEmpty(x))
                .WithMessage($"{_typeName}.${nameof(CoefficientGroup.Name)} is invalid");

            RuleFor(x => x.Id)
                .MustBeValidGuid();

            RuleFor(x => x.Type)
                .Must(x => x != CoefficientGroupType.Unspecified)
                .WithMessage($"{_typeName}.${nameof(CoefficientGroup.Type)} is invalid");
        }
    }
}
