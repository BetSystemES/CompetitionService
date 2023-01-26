using CompetitionService.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetitionService.DataAccess.Configurations
{
    public class CoefficientGroupConfiguration : IEntityTypeConfiguration<CoefficientGroup>
    {
        public void Configure(EntityTypeBuilder<CoefficientGroup> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CompetitionBaseId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            builder.HasMany(x => x.Coefficients).WithOne(x => x.CoefficientGroup).HasForeignKey(x => x.CoefficientGroupId);

            builder.ToTable("CoefficientGroups");
        }
    }
}
