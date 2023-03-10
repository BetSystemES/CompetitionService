namespace CompetitionService.BusinessLogic.Models.BetServiceModels.Enums
{
    /// <summary>
    /// Bet status type.
    /// </summary>
    public enum BetServiceBetStatusType
    {
        /// <summary>
        /// The unspecified
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The win
        /// </summary>
        Win = 1,

        /// <summary>
        /// The lose
        /// </summary>
        Lose = 2,

        /// <summary>
        /// The canceled
        /// </summary>
        Canceled = 3,

        /// <summary>
        /// The blocked
        /// </summary>
        Blocked = 4,
    }
}
