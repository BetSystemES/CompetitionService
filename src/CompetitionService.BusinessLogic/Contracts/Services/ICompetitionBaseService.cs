using CompetitionService.BusinessLogic.Models.Competitions;

namespace CompetitionService.BusinessLogic.Contracts.Services
{
    public interface ICompetitionBaseService
    {
        Task BlockCompetitionBaseById(Guid id, CancellationToken token);

        Task CompleteCompetitionBaseOutcomes(CompetitionBase competitionBase, CancellationToken token);
    }
}
