using CompetitionService.BusinessLogic.Models.Competitions;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Providers
{
    public interface ICompetitionBaseProvider
    {
        Task<CompetitionBase?> GetById(Guid id, CancellationToken token);
    }
}
