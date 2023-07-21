using CompetitionService.Grpc.Extensions;
using FluentValidation;

namespace CompetitionService.Grpc.Infrastructure.Validators
{
    /// <summary>
    /// Validator for <seealso cref="Coefficient"/>
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator&lt;CompetitionService.Grpc.Coefficient&gt;" />
    public class CoefficientValidator : AbstractValidator<Coefficient>
    {
        private static readonly string _typeName = nameof(Coefficient);

        private static readonly double _minRateValue = 1;
        private static readonly double _minProbabilityValue = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoefficientValidator"/> class.
        /// </summary>
        public CoefficientValidator()
        {
            //RuleFor(x => x.Id)
            //    .MustBeValidGuid()
            //    .WithMessage($"{_typeName}.${nameof(Coefficient.Id)} is invalid");

            RuleFor(x => x.StatusType)
                .Must(e => e != CoefficientStatusType.Unspecified)
                .WithMessage($"Received {nameof(Coefficient.StatusType)} type is unsupported");

            RuleFor(x => x.Description)
                .Must(e => !string.IsNullOrEmpty(e))
                .WithMessage($"{_typeName}.${nameof(Coefficient.Description)} is invalid");

            RuleFor(x => x.Rate)
                .Must(e => e > _minRateValue)
                .WithMessage($"{_typeName}.${nameof(Coefficient.Rate)} is invalid");

            RuleFor(x => x.Probability)
                .Must(e => e > _minProbabilityValue)
                .WithMessage($"{_typeName}.${nameof(Coefficient.Probability)} is invalid");
        }
    }
}
