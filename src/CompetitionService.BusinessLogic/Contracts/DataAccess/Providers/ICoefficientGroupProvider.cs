using CompetitionService.BusinessLogic.Models;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Providers
{
    public interface ICoefficientGroupProvider
    {
        Task<CoefficientGroup?> GetById(Guid id, CancellationToken token);
    }
}
