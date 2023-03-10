using CompetitionService.BusinessLogic.Enums;
using CompetitionService.BusinessLogic.Models.Entities;

namespace CompetitionService.BusinessLogic.Extensions
{
    /// <summary>
    /// Provides functionality for setting coefficients status.
    /// </summary>
    public static class CompetitionBaseStatusSetter
    {
        /// <summary>
        /// Sets the coefficients status.
        /// </summary>
        /// <param name="competitionBase">The competition base.</param>
        /// <param name="type">The type.</param>
        /// <returns><seealso cref="CompetitionBase"/></returns>
        public static CompetitionBase SetCoefficientsStatus(this CompetitionBase competitionBase, CoefficientStatusType type)
        {
            competitionBase.CoefficientGroups
                .ForEach(x => x.Coefficients
                .ForEach(x => x.StatusType = type));

            return competitionBase;
        }
    }
}
