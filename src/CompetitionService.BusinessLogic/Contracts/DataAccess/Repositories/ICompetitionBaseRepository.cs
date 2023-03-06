using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories
{
    public interface ICompetitionBaseRepository
    {
        Task Create(CompetitionBase item, CancellationToken token);

        Task Update(CompetitionBase item, CancellationToken token);
    }
}
