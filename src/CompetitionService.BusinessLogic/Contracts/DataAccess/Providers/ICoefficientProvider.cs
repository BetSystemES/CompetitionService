using CompetitionService.BusinessLogic.Models;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Providers
{
    public interface ICoefficientProvider
    {
        Task<Coefficient?> GetById(Guid id, CancellationToken token);
    }
}
