using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompetitionService.DataAccess.Providers
{
    public class CompetitionDota2Provider : ICompetitionProvider<CompetitionDota2>
    {
        private readonly DbSet<CompetitionDota2> _entities;

        public CompetitionDota2Provider(DbSet<CompetitionDota2> entities)
        {
            _entities = entities;
        }

        public Task<CompetitionDota2?> GetById(Guid id, CancellationToken token)
        {
            return _entities
                .Include(x => x.CompetitionBase)
                .ThenInclude(x => x.CoefficientGroups)
                .ThenInclude(x => x.Coefficients)
                .FirstOrDefaultAsync(x => x.Id == id, token);
        }

        public Task<List<CompetitionDota2>> GetRange(int page, int pageSize, CancellationToken token)
        {
            var result = _entities
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.CompetitionBase)
                .ThenInclude(x => x.CoefficientGroups)
                .ThenInclude(x => x.Coefficients)
                .ToListAsync(token);

            return result;
        }
    }
}
