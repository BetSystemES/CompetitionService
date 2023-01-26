using CompetitionService.BusinessLogic.Contracts.DataAccess;

namespace CompetitionService.DataAccess
{
    public class CompetitionDataContext : IDataContext
    {
        private readonly CompetitionDbContext _competitionDbContext;

        public CompetitionDataContext(CompetitionDbContext competitionDbContext)
        {
            _competitionDbContext = competitionDbContext;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// Task
        /// </returns>
        public Task SaveChanges(CancellationToken token)
        {
            return _competitionDbContext.SaveChangesAsync(token);
        }
    }
}
