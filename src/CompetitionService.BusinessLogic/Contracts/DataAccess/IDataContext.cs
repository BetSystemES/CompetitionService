namespace CompetitionService.BusinessLogic.Contracts.DataAccess
{
    /// <summary>
    ///   Data context provider
    /// </summary>
    public interface IDataContext
    {
        /// <summary>Saves the changes.</summary>
        /// <param name="token">The token.</param>
        /// <returns>
        ///   Task
        /// </returns>
        Task SaveChanges(CancellationToken token);
    }
}
