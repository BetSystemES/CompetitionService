using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompetitionService.DataAccess.Providers
{
    public class CoefficientProvider : ICoefficientProvider
    {
        private readonly DbSet<Coefficient> _entities;

        public CoefficientProvider(DbSet<Coefficient> entities)
        {
            _entities = entities;
        }

        public Task<Coefficient?> GetById(Guid id, CancellationToken token)
        {
            return _entities.FirstOrDefaultAsync(x => x.Id == id, token);
        }
    }
}
