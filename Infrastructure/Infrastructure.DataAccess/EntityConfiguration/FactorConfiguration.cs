using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfiguration
{
    public class FactorConfiguration: IEntityTypeConfiguration<Factor>
    {
        public void Configure(EntityTypeBuilder<Factor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).HasMaxLength(40);
            builder.Property(p => p.ToValue).HasMaxLength(100);
            builder.Property(p => p.ToBase).HasMaxLength(100);
            builder.Property(p => p.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasMany(a => a.Units).WithOne(b => b.Factor);
            builder.HasOne(a => a.Kind).WithMany(b => b.Factors).HasForeignKey(c => c.KindId);
        }
    }
}
