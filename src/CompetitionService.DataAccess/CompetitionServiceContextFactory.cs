using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CompetitionService.DataAccess
{
    /// <summary>
    /// Auction service context factory
    /// </summary>
    public class CompetitionServiceContextFactory : IDesignTimeDbContextFactory<CompetitionDbContext>
    {
        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>
        /// An instance of <typeparamref name="TContext" />.
        /// </returns>
        public CompetitionDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CompetitionDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CompetitionDb;User Id=postgres;Password=123");

            return new CompetitionDbContext(optionsBuilder.Options);
        }
    }
}
