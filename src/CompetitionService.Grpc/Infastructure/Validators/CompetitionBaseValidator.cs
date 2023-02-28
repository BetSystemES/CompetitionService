using CompetitionService.Grpc.Infastructure.ValidationRules;
using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.Validators
{
    public class CompetitionBaseValidator : AbstractValidator<CompetitionBase>
    {
        private static readonly string _typeName = nameof(CompetitionBase);

        public CompetitionBaseValidator()
        {
            RuleForEach(x => x.CoefficientGroups)
                .Where(x => x is not null)
                .SetValidator(new CoefficientGroupValidator());

            RuleFor(x => x.Id)
                .MustBeValidGuid();

            RuleFor(x => x.StatusType)
                .Must(x => x != CompetitionStatusType.Unspecified)
                .WithMessage($"{_typeName}.${nameof(CompetitionBase.StatusType)} is invalid");
        }
    }
}
