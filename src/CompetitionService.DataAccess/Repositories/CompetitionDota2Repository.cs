using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompetitionService.DataAccess.Repositories
{
    public class CompetitionDota2Repository : ICompetitionRepository<CompetitionDota2>
    {
        private readonly DbSet<CompetitionDota2> _entities;

        public CompetitionDota2Repository(DbSet<CompetitionDota2> entities)
        {
            _entities = entities;
        }

        public Task Create(CompetitionDota2 item, CancellationToken token)
        {
            _entities.Add(item);

            return Task.CompletedTask;
        }

        public Task Update(CompetitionDota2 item, CancellationToken token)
        {
            _entities.Update(item);

            return Task.CompletedTask;
        }
    }
}
