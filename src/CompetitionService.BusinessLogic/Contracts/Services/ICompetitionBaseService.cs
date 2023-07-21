using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.BusinessLogic.Contracts.Services
{
    public interface ICompetitionBaseService
    {
        Task BlockCompetitionBaseById(Guid id, CancellationToken token);

        Task CompleteCompetitionBaseOutcomes(CompetitionBase competitionBase, CancellationToken token);

        Task Update(CompetitionBase competitionBase, CancellationToken token);

        /// <summary>
        /// Create specific Competition Base.
        /// </summary>
        /// <param name="coefficient"></param>
        /// <param name="token"></param>
        /// <returns>Task</returns>
        Task<CompetitionBase> Create(CompetitionBase competitionBase, CancellationToken token);
    }
}
