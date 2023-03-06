using FluentValidation;

namespace CompetitionService.Grpc.Infastructure.Validators.Validators
{
    /// <summary>
    /// Validator for <seealso cref="UpdateCompetitionDota2Request"/>
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator&lt;CompetitionService.Grpc.UpdateCompetitionDota2Request&gt;" />
    public class UpdateCompetitionDota2RequestValidator : AbstractValidator<UpdateCompetitionDota2Request>
    {
        public UpdateCompetitionDota2RequestValidator()
        {
            RuleFor(x => x.CompetitionDota2)
                .SetValidator(new CompetitionDota2Validtor());
        }
    }
}
