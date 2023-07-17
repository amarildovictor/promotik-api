using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities;

namespace PromoTik.Data.Mapping
{
    public class PublishingAppMap : IEntityTypeConfiguration<PublishingApp>
    {
        public void Configure(EntityTypeBuilder<PublishingApp> builder)
        {
            builder.ToTable("PUBLISHING_APP");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Description).HasMaxLength(256);
            builder.Property(x => x.EndpointUrl).HasMaxLength(256);
        }
    }
}