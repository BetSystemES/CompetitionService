using CompetitionService.Grpc.Infastructure.ValidationRules;
using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.Validators
{
    // TODO: Rename folder from Infastructure to Infrastructure
    /// <summary>
    /// Validator for <seealso cref="CoefficientGroup"/>
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator&lt;CompetitionService.Grpc.CoefficientGroup&gt;" />
    public class CoefficientGroupValidator : AbstractValidator<CoefficientGroup>
    {
        private static readonly string _typeName = nameof(CoefficientGroup);

        public CoefficientGroupValidator()
        {
            RuleFor(x => x.Id)
               .MustBeValidGuid()
               .WithMessage($"{_typeName}.${nameof(CoefficientGroup.Id)} is invalid");

            RuleForEach(x => x.Coefficients)
                .Where(x => x is not null)
                .SetValidator(new CoefficientValidator());

            RuleFor(x => x.Name)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage($"{_typeName}.${nameof(CoefficientGroup.Name)} is invalid");

            RuleFor(x => x.Type)
                .Must(x => x != CoefficientGroupType.Unspecified)
                .WithMessage($"{_typeName}.${nameof(CoefficientGroup.Type)} is invalid");
        }
    }
}
