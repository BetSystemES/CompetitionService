namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories
{
    public interface ICompetitionRepository<T> where T : class
    {
        Task Create(T item, CancellationToken token);

        Task Update(T item, CancellationToken token);
    }
}
