namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories
{
    public interface ICompetitionRepository<T> where T : class
    {
        // TODO: change file location to CashService.DataAccess.Contracts.Repositories
        Task Create(T item, CancellationToken token);

        Task Update(T item, CancellationToken token);
    }
}
