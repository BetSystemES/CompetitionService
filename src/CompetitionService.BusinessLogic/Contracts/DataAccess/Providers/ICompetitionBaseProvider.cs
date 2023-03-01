using CompetitionService.BusinessLogic.Models.Competitions;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Providers
{
    // TODO: change file location to CompetitionService.DataAccess.Contracts.Providers
    public interface ICompetitionBaseProvider
    {
        Task<CompetitionBase?> GetById(Guid id, CancellationToken token);
    }
}
