using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace CompetitionService.DataAccess.Providers
{
    public class CoefficientGroupProvider : ICoefficientGroupProvider
    {
        private readonly DbSet<CoefficientGroup> _entities;

        public CoefficientGroupProvider(DbSet<CoefficientGroup> entities)
        {
            _entities = entities;
        }

        public Task<CoefficientGroup?> GetById(Guid id, CancellationToken token)
        {
            return _entities
                .Include(x => x.Coefficients)
                .FirstOrDefaultAsync(x => x.Id == id, token);
        }
    }
}
