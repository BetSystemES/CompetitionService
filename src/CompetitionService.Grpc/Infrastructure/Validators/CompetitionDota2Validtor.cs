using CompetitionService.Grpc.Extensions;
using FluentValidation;

namespace CompetitionService.Grpc.Infrastructure.Validators
{
    /// <summary>
    /// Validator for <seealso cref="CompetitionDota2"/>
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator&lt;CompetitionService.Grpc.CompetitionDota2&gt;" />
    public class CompetitionDota2Validtor : AbstractValidator<CompetitionDota2>
    {
        private static readonly string _typeName = nameof(CompetitionDota2);

        private static readonly int _minTeamKillAmount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionDota2Validtor"/> class.
        /// </summary>
        public CompetitionDota2Validtor()
        {
            //RuleFor(x => x.CompetitionBase)
            //    .SetValidator(new CompetitionBaseValidator());

            //RuleFor(x => x.Id)
            //    .MustBeValidGuid()
            //    .WithMessage($"{_typeName}.${nameof(CompetitionDota2.Id)} is invalid");

            RuleFor(x => x.Team1Id)
                .MustBeValidGuid()
                .WithMessage($"{_typeName}.${nameof(CompetitionDota2.Team1Id)} is invalid");

            RuleFor(x => x.Team2Id)
                .MustBeValidGuid()
                .WithMessage($"{_typeName}.${nameof(CompetitionDota2.Team2Id)} is invalid");

            RuleFor(x => x.Team1KillAmount)
                .GreaterThanOrEqualTo(_minTeamKillAmount)
                .WithMessage($"{_typeName}.${nameof(CompetitionDota2.Team1KillAmount)} is invalid");

            RuleFor(x => x.Team2KillAmount)
                .GreaterThanOrEqualTo(_minTeamKillAmount)
                .WithMessage($"{_typeName}.${nameof(CompetitionDota2.Team2KillAmount)} is invalid");

            RuleFor(x => x.TotalTime)
                .NotNull()
                .WithMessage($"{_typeName}.${nameof(CompetitionDota2.TotalTime)} is invalid");
        }
    }
}
