using CompetitionService.BusinessLogic.Models.Competitions;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories
{
    // TODO: change file location to CashService.DataAccess.Contracts.Repositories
    public interface ICompetitionBaseRepository
    {
        Task Create(CompetitionBase item, CancellationToken token);

        Task Update(CompetitionBase item, CancellationToken token);
    }
}
