using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Providers
{
    public interface ICompetitionBaseProvider
    {
        Task<CompetitionBase?> GetById(Guid id, CancellationToken token);
    }
}
