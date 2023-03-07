using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompetitionService.DataAccess.Repositories
{
    public class CoefficientGroupRepository : ICoefficientGroupRepository
    {
        private readonly DbSet<CoefficientGroup> _entities;

        public CoefficientGroupRepository(DbSet<CoefficientGroup> entities)
        {
            _entities = entities;
        }

        public Task Create(CoefficientGroup coefficientGroup, CancellationToken token)
        {
            _entities.Add(coefficientGroup);

            return Task.CompletedTask;
        }

        public Task Update(CoefficientGroup coefficientGroup, CancellationToken token)
        {
            _entities.Update(coefficientGroup);

            return Task.CompletedTask;
        }
    }
}
