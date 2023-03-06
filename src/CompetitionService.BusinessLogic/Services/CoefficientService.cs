using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Contracts.Services;

namespace CompetitionService.BusinessLogic.Services
{
    public class CoefficientService : ICoefficientService
    {
        private readonly ICoefficientProvider _provider;
        private readonly ICoefficientRepository _repository;
        private readonly IDataContext _context;

        public CoefficientService(
            ICoefficientProvider provider,
            ICoefficientRepository repository,
            IDataContext context)
        {
            _provider = provider;
            _repository = repository;
            _context = context;
        }
        
        public async Task<double> DepositToCoefficientById(Guid id, double amount, CancellationToken token)
        {
            var coefficient = await _provider.GetById(id, token);

            coefficient.Amount += amount;
            var rate = coefficient.Rate;

            await _repository.Update(coefficient, token);
            await _context.SaveChanges(token);

            return rate;
        }
    }
}
