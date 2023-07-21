using CompetitionService.BusinessLogic.Entities;

namespace CompetitionService.BusinessLogic.Contracts.Services
{
    /// <summary>
    /// Implementation of coefficient service
    /// </summary>
    public interface ICoefficientService
    {
        /// <summary>
        /// Deposits to coefficient by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="token">The token.</param>
        /// <returns>Rate value <seealso cref="double"/></returns>
        Task<double> DepositToCoefficientById(Guid id, double amount, CancellationToken token);

        /// <summary>
        /// Update specific coefficient.
        /// </summary>
        /// <param name="coefficient"></param>
        /// <param name="token"></param>
        /// <returns>Task</returns>
        Task Update(Coefficient coefficient, CancellationToken token);

        /// <summary>
        /// Create specific coefficient.
        /// </summary>
        /// <param name="coefficient"></param>
        /// <param name="token"></param>
        /// <returns>Task</returns>
        Task Create(Coefficient coefficient, CancellationToken token);
    }
}
