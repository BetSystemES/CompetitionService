using FluentValidation;

namespace CompetitionService.Grpc.Infrastructure.Validators.RequestValidators
{
    /// <summary>
    /// Validator for <seealso cref="GetCompetitionsDota2Request"/>.
    /// </summary>
    public class GetCompetitionsDota2RequestValidator : AbstractValidator<GetCompetitionsDota2Request>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCompetitionsDota2RequestValidator"/> class.
        /// </summary>
        public GetCompetitionsDota2RequestValidator()
        {
            RuleFor(e => e.Page)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Page value is invalid");

            RuleFor(e => e.PageSize)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("PageSize value is invalid");
        }
    }
}
