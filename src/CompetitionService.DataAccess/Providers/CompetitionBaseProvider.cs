using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Models.Competitions;
using Microsoft.EntityFrameworkCore;

namespace CompetitionService.DataAccess.Providers
{
    public class CompetitionBaseProvider : ICompetitionBaseProvider
    {
        private readonly DbSet<CompetitionBase> _entities;

        public CompetitionBaseProvider(DbSet<CompetitionBase> entities)
        {
            _entities = entities;
        }

        public Task<CompetitionBase?> GetById(Guid id, CancellationToken token)
        {
            return _entities
                .Include(x => x.CoefficientGroups.Select(x => x.Coefficients))
                .FirstOrDefaultAsync(x => x.Id == id, token);
        }
    }
}
