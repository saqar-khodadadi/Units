using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure.DataAccess.EntityConfiguration
{
    public class KindConfiguration : IEntityTypeConfiguration<Kind>
    {
        public void Configure(EntityTypeBuilder<Kind> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(40);
            builder.Property(p => p.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasMany(a => a.Factors).WithOne(b => b.Kind);
        }
    }
}
