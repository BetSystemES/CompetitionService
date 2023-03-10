using CompetitionService.BusinessLogic.Models.Enums;
using CompetitionService.BusinessLogic.Models.BetServiceModels.Enums;

namespace CompetitionService.BusinessLogic.Models.BetServiceModels.Models
{
    /// <summary>
    /// Bet status update model.
    /// </summary>
    public class BetServiceBetStatusUpdateModel
    {
        /// <summary>
        /// Coefficient identifier.
        /// </summary>
        public Guid CoefficientId { get; set; }

        /// <summary>
        /// Bet status type.
        /// </summary>
        public BetServiceBetStatusType StatusType { get; set; }
    }
}
