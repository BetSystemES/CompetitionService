using CompetitionService.BusinessLogic.Models.BetServiceModels.Enums;

namespace CompetitionService.BusinessLogic.Models.BetServiceModels.Models
{
    /// <summary>
    /// Bet business model representation.
    /// </summary>
    public class Bet
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Bet owner user identifier.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Coefficient identifier.
        /// </summary>
        public Guid CoefficientId { get; set; }

        /// <summary>
        /// Amount.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Rate.
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Create at UTC.
        /// </summary>
        public DateTime CreateAtUtc { get; set; }

        /// <summary>
        /// Bet paid type.
        /// </summary>
        public BetPayoutStatus PayoutStatus { get; set; }

        /// <summary>
        /// Bet status type.
        /// </summary>
        public BetStatusType BetStatusType { get; set; }
    }
}
