using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Entities;
using CompetitionService.BusinessLogic.Extensions;
using CompetitionService.BusinessLogic.Models.Enums;

namespace CompetitionService.BusinessLogic.Services
{
    public class CompetitionBaseService : ICompetitionBaseService
    {
        private readonly ICompetitionBaseProvider _provider;
        private readonly ICompetitionBaseRepository _repository;
        private readonly IDataContext _context;

        private readonly CoefficientStatusType _defaultBlockedStatus = CoefficientStatusType.Blocked;

        public CompetitionBaseService(
            ICompetitionBaseProvider provider,
            ICompetitionBaseRepository repository,
            IDataContext context)
        {
            _provider = provider;
            _repository = repository;
            _context = context;
        }

        public async Task BlockCompetitionBaseById(Guid id, CancellationToken token)
        {
            var competitionBase = await _provider.GetById(id, token);

            competitionBase.SetCoefficientsStatus(_defaultBlockedStatus);

            await _repository.Update(competitionBase, token);
            await _context.SaveChanges(token);
        }

        public async Task CompleteCompetitionBaseOutcomes(CompetitionBase competitionBase, CancellationToken token)
        {
            await _repository.Update(competitionBase, token);
            await _context.SaveChanges(token);
            // TODO: send coefficient statuses to BetService
        }
    }
}
