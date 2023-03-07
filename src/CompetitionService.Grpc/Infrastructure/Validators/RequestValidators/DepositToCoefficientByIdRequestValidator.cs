using CompetitionService.Grpc.Extensions;
using FluentValidation;

namespace CompetitionService.Grpc.Infrastructure.Validators.Validators
{
    /// <summary>
    /// Validator for <seealso cref="DepositToCoefficientByIdRequest"/>
    /// </summary>
    public class DepositToCoefficientByIdRequestValidator : AbstractValidator<DepositToCoefficientByIdRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepositToCoefficientByIdRequestValidator"/> class.
        /// </summary>
        public DepositToCoefficientByIdRequestValidator()
        {
            RuleFor(e => e.CoefficientId)
                .MustBeValidGuid();

            RuleFor(e => e.Amount)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
