using CompetitionService.Grpc.Infastructure.ValidationRules;
using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.Validators.Validators
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
