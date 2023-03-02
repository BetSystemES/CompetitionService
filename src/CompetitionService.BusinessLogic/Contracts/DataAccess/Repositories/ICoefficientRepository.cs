// TODO: remove unused usings
using System.Runtime.InteropServices;
using CompetitionService.BusinessLogic.Models;

namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories
{
    public interface ICoefficientRepository
    {
        Task Create(Coefficient coefficient, CancellationToken token);

        Task Update(Coefficient coefficient, CancellationToken token);
    }
}
