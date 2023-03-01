using CompetitionService.BusinessLogic.Models;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories
{
    // TODO: change file location to CashService.DataAccess.Contracts.Repositories
    public interface ICoefficientGroupRepository
    {
        Task Create(CoefficientGroup coefficientGroup, CancellationToken token);

        Task Update(CoefficientGroup coefficientGroup, CancellationToken token);
    }
}
