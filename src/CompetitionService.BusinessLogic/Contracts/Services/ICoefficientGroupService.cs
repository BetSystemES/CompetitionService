using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.BusinessLogic.Contracts.Services
{
    /// <summary>
    /// Coefficient group service
    /// </summary>
    public interface ICoefficientGroupService
    {
        /// <summary>
        /// Update specific coefficient group.
        /// </summary>
        /// <param name="coefficientGroup"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task</returns>
        Task Update(CoefficientGroup coefficientGroup, CancellationToken cancellationToken);

        /// <summary>
        /// Create specific coefficient group.
        /// </summary>
        /// <param name="coefficientGroup"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Create(CoefficientGroup coefficientGroup, CancellationToken cancellationToken);
    }
}
