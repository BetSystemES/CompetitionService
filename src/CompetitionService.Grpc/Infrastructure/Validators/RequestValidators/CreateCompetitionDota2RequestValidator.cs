using FluentValidation;

namespace CompetitionService.Grpc.Infrastructure.Validators.Validators
{
    /// <summary>
    /// Validator for <seealso cref="CompetitionDota2"/>
    /// </summary>
    public class CreateCompetitionDota2RequestValidator : AbstractValidator<CreateCompetitionDota2Request>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCompetitionDota2RequestValidator"/> class.
        /// </summary>
        public CreateCompetitionDota2RequestValidator()
        {
            RuleFor(x => x.CompetitionDota2)
                .SetValidator(new CompetitionDota2Validtor());
        }
    }
}
