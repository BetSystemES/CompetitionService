namespace CompetitionService.BusinessLogic.Contracts.DataAccess.Providers
{
    public interface ICompetitionProvider<T> where T : class
    {
        // TODO: change file location to CompetitionService.DataAccess.Contracts.Providers
        Task<T?> GetById(Guid id, CancellationToken token);

        Task<List<T>> GetRange(int page, int pageSize, CancellationToken token);

    }
}
