using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompetitionService.DataAccess.Repositories
{
    public class CompetitionBaseRepository : ICompetitionBaseRepository
    {
        private readonly DbSet<CompetitionBase> _entities;

        public CompetitionBaseRepository(DbSet<CompetitionBase> entities)
        {
            _entities = entities;
        }

        public Task Create(CompetitionBase item, CancellationToken token)
        {
            _entities.Add(item);

            return Task.CompletedTask;
        }

        public Task Update(CompetitionBase item, CancellationToken token)
        {
            _entities.Update(item);

            return Task.CompletedTask;
        }
    }
}
