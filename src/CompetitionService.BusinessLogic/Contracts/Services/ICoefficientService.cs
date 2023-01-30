namespace CompetitionService.BusinessLogic.Contracts.Services
{
    public interface ICoefficientService
    {
        Task DepositToCoefficientById(Guid id, double amount, CancellationToken token);
    }
}
