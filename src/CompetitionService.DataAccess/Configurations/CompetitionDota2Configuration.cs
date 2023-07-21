using CompetitionService.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetitionService.DataAccess.Configurations
{
    public class CompetitionDota2Configuration : IEntityTypeConfiguration<CompetitionDota2>
    {
        public void Configure(EntityTypeBuilder<CompetitionDota2> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CompetitionBaseId).IsRequired();
            builder.Property(x => x.Team1Id).IsRequired();
            builder.Property(x => x.Team2Id).IsRequired();
            builder.Property(x => x.Team1Name).IsRequired();
            builder.Property(x => x.Team2Name).IsRequired();
            builder.Property(x => x.Team1KillAmount).IsRequired();
            builder.Property(x => x.Team2KillAmount).IsRequired();
            builder.Property(x => x.TotalTime).IsRequired();

            builder.HasOne(x => x.CompetitionBase);

            builder.ToTable("CompetitionsDota2");
        }
    }
}
