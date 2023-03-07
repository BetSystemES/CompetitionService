using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Providers
{
    public interface ICoefficientProvider
    {
        Task<Coefficient?> GetById(Guid id, CancellationToken token);
    }
}
