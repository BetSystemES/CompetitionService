using CompetitionService.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetitionService.DataAccess.Configurations
{
    public class CoefficientConfiguration : IEntityTypeConfiguration<Coefficient>
    {
        public void Configure(EntityTypeBuilder<Coefficient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CoefficientGroupId).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Rate).IsRequired();
            builder.Property(x => x.StatusType).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Probability).IsRequired();

            builder.HasOne(x => x.CoefficientGroup).WithMany(x => x.Coefficients).HasForeignKey(x => x.CoefficientGroupId);

            builder.ToTable("Coefficients");
        }
    }
}
