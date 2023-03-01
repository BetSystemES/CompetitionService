using CompetitionService.BusinessLogic.Models;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Providers
{
    // TODO: change file location to CompetitionService.DataAccess.Contracts.Providers
    public interface ICoefficientGroupProvider
    {
        Task<CoefficientGroup?> GetById(Guid id, CancellationToken token);
    }
}
