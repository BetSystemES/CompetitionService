using CompetitionService.BusinessLogic.Models.BetServiceModels.Enums;

namespace CompetitionService.BusinessLogic.Models.BetServiceModels.Models
{
    /// <summary>
    /// Bet status update model.
    /// </summary>
    public class BetStatusUpdateModel
    {
        /// <summary>
        /// Coefficient identifier.
        /// </summary>
        public Guid CoefficientId { get; set; }

        /// <summary>
        /// Bet status type.
        /// </summary>
        public BetStatusType StatusType { get; set; }
    }
}
