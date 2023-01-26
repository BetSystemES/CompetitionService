using CompetitionService.BusinessLogic.Models.Competitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetitionService.DataAccess.Configurations
{
    public class CompetitionBaseConfiguration : IEntityTypeConfiguration<CompetitionBase>
    {
        public void Configure(EntityTypeBuilder<CompetitionBase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.StatusType).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            builder.HasMany(x => x.CoefficientGroups).WithOne(x => x.competitionBase).HasForeignKey(x => x.CompetitionBaseId);

            builder.ToTable("CompetitionBases");
        }
    }
}
