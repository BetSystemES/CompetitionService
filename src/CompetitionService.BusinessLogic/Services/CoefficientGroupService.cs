using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.BusinessLogic.Services
{
    public class CoefficientGroupService : ICoefficientGroupService
    {
        private readonly ICoefficientGroupRepository _repository;
        private readonly IDataContext _context;

        public CoefficientGroupService(ICoefficientGroupRepository repository, IDataContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task Create(CoefficientGroup coefficientGroup, CancellationToken cancellationToken)
        {
            await _repository.Create(coefficientGroup, cancellationToken);
            await _context.SaveChanges(cancellationToken);
        }

        public async Task Update(CoefficientGroup coefficientGroup, CancellationToken cancellationToken)
        {
            await _repository.Update(coefficientGroup, cancellationToken);
            await _context.SaveChanges(cancellationToken);
        }
    }
}
