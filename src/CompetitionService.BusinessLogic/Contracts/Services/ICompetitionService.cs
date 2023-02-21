namespace CompetitionService.BusinessLogic.Contracts.Services
{
    public interface ICompetitionService<T> where T : class
    {
        Task Create(T item, CancellationToken token);

        Task Update(T item, CancellationToken token);

        Task<T?> GetById(Guid id, CancellationToken token);

        Task<List<T>> GetRange(int page, int pageSize, CancellationToken token);
    }
}
