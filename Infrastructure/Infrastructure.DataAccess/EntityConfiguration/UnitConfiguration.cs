using Core.Domain;
using Infrastructure.DataAccess.EntityHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfiguration
{
    internal class UnitConfiguration: IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(400);
            builder.Property(p => p.EnTitle).HasMaxLength(400);
            builder.Property(p => p.Symbol).HasMaxLength(100);
            builder.Property(p => p.Measurment).HasMaxLength(100);
            builder.Property(p => p.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasOne(a => a.Factor).WithMany(b => b.Units).HasForeignKey(c => c.FactorId);
            builder.HasMany(a => a.ChildUnits).WithOne(a => a.ParentUnit).HasForeignKey(d => d.ParentId);
        }
    }
}
