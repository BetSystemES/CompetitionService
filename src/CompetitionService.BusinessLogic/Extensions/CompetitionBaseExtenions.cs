using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetitionService.BusinessLogic.Entities;
using CompetitionService.BusinessLogic.Models.BetServiceModels.Models;

namespace CompetitionService.BusinessLogic.Extensions
{
    /// <summary>
    /// Exntension for <seealso cref="CompetitionBase"/>
    /// </summary>
    public static class CompetitionBaseExtenions
    {
        public static IEnumerable<BetServiceBetStatusUpdateModel> ToBetStatusUpdateModels(this CompetitionBase entity)
        {
            var betStatusUpdateModels = new List<BetServiceBetStatusUpdateModel>();
            foreach (var coeffGroup in entity.CoefficientGroups)
            {
                foreach (var coeff in coeffGroup.Coefficients)
                {
                    betStatusUpdateModels.Add(new BetServiceBetStatusUpdateModel() { CoefficientId = coeff.Id, StatusType = coeff.StatusType });
                }
            }

            return betStatusUpdateModels;
        }
    }
}
