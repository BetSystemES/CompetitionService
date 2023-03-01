using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.ValidationRules
{
    // TODO: Rename folder from Infastructure to Infrastructure
    // TODO: change file location to CashService.GRPC.Extensions
    // TODO: rename file to ValidationRulesExtensions
    /// <summary>
    /// Validation rule for guid
    /// </summary>
    public static class GuidValidationRule
    {
        /// <summary>
        /// Must the be valid unique identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder">The rule builder.</param>
        /// <returns>IRuleBuilderOptions</returns>
        public static IRuleBuilderOptions<T, string> MustBeValidGuid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builderOptions = ruleBuilder
                .NotNull()
                .NotEmpty()
                .Must(e => Guid.TryParse(e, out var guid));

            return builderOptions;
        }
    }
}
