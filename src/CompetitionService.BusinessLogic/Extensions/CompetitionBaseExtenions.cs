using CompetitionService.BusinessLogic.Entities;
using CompetitionService.BusinessLogic.Models;
using CompetitionService.BusinessLogic.Models.BetServiceModels.Models;

namespace CompetitionService.BusinessLogic.Extensions
{
    /// <summary>
    /// Exntension for <seealso cref="CompetitionBase"/>
    /// </summary>
    public static class CompetitionBaseExtenions
    {
        public static IEnumerable<CoefficientStatus> ToBetStatusUpdateModels(this CompetitionBase entity)
        {
            var betStatusUpdateModels = new List<CoefficientStatus>();
            foreach (var coeffGroup in entity.CoefficientGroups)
            {
                foreach (var coeff in coeffGroup.Coefficients)
                {
                    betStatusUpdateModels.Add(new CoefficientStatus() { CoefficientId = coeff.Id, OutcomeType = coeff.OutcomeType });
                }
            }

            return betStatusUpdateModels;
        }
    }
}
