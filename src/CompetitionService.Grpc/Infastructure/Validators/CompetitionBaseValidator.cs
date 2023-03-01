using CompetitionService.Grpc.Infastructure.ValidationRules;
using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.Validators
{
    // TODO: Rename folder from Infastructure to Infrastructure
    /// <summary>
    /// Validator for <seealso cref="CompetitionBase"/>
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator&lt;CompetitionService.Grpc.CompetitionBase&gt;" />
    public class CompetitionBaseValidator : AbstractValidator<CompetitionBase>
    {
        private static readonly string _typeName = nameof(CompetitionBase);

        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionBaseValidator"/> class.
        /// </summary>
        public CompetitionBaseValidator()
        {
            RuleForEach(x => x.CoefficientGroups)
                .Where(x => x is not null)
                .SetValidator(new CoefficientGroupValidator());

            RuleFor(x => x.Id)
                .MustBeValidGuid()
                .WithMessage($"{_typeName}.${nameof(CompetitionBase.Id)} is invalid");

            RuleFor(x => x.StatusType)
                .Must(x => x != CompetitionStatusType.Unspecified)
                .WithMessage($"{_typeName}.${nameof(CompetitionBase.StatusType)} is invalid");
        }
    }
}
