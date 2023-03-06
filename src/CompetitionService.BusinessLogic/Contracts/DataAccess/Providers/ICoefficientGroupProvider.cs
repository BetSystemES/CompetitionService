using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Providers
{
    public interface ICoefficientGroupProvider
    {
        Task<CoefficientGroup?> GetById(Guid id, CancellationToken token);
    }
}
