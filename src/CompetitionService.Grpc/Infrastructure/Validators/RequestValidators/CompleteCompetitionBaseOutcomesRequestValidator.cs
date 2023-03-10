using FluentValidation;

namespace CompetitionService.Grpc.Infrastructure.Validators.RequestValidators
{
    /// <summary>
    /// Validator for <seealso cref="CompleteCompetitionBaseOutcomesRequest"/>
    /// </summary>
    public class CompleteCompetitionBaseOutcomesRequestValidator : AbstractValidator<CompleteCompetitionBaseOutcomesRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompleteCompetitionBaseOutcomesRequestValidator"/> class.
        /// </summary>
        public CompleteCompetitionBaseOutcomesRequestValidator()
        {
            RuleFor(e => e.CompetitionBase)
                .SetValidator(new CompetitionBaseValidator());
        }
    }
}
