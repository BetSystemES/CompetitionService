﻿using FluentValidation;

namespace CompetitionService.Grpc.Extensions
{
    /// <summary>
    /// Validation rule for guid
    /// </summary>
    public static class ValidationRulesExtensions
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
