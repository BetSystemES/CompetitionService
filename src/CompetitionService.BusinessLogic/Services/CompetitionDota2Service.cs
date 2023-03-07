using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.BusinessLogic.Services
{
    public class CompetitionDota2Service : ICompetitionService<CompetitionDota2>
    {
        private readonly ICompetitionProvider<CompetitionDota2> _provider;
        private readonly ICompetitionRepository<CompetitionDota2> _repository;
        private readonly IDataContext _dataContext;

        public CompetitionDota2Service(
            ICompetitionProvider<CompetitionDota2> provider,
            ICompetitionRepository<CompetitionDota2> repository,
            IDataContext dataContext)
        {
            _provider = provider;
            _repository = repository;
            _dataContext = dataContext;
        }

        public async Task Create(CompetitionDota2 item, CancellationToken token)
        {
            await _repository.Create(item, token);
            await _dataContext.SaveChanges(token);
        }

        public Task<CompetitionDota2?> GetById(Guid id, CancellationToken token)
        {
            return _provider.GetById(id, token);
        }

        public Task<List<CompetitionDota2>> GetRange(int page, int pageSize, CancellationToken token)
        {
            return _provider.GetRange(page, pageSize, token);
        }

        public async Task Update(CompetitionDota2 item, CancellationToken token)
        {
            await _repository.Update(item, token);
            await _dataContext.SaveChanges(token);
        }
    }
}
