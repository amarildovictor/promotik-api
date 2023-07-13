using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities;

namespace PromoTik.Data.Mapping
{
    public class GeneralConfigurationMap : IEntityTypeConfiguration<GeneralConfiguration>
    {
        public void Configure(EntityTypeBuilder<GeneralConfiguration> builder)
        {
            builder.ToTable("GENERAL_CONFIGURATION");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Description).HasMaxLength(50);
            builder.Property(x => x.Type);
            builder.Property(x => x.Value1).HasMaxLength(50);
            builder.Property(x => x.Value2).HasMaxLength(50);
        }
    }
}