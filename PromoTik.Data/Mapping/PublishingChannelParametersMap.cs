using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities;

namespace PromoTik.Data.Mapping
{
    public class PublishingChannelParametersMap : IEntityTypeConfiguration<PublishingChannelParameter>
    {
        public void Configure(EntityTypeBuilder<PublishingChannelParameter> builder)
        {
            builder.ToTable("PUBLISHING_CHANNEL_PARAMETERS");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Parameter).HasMaxLength(100);
            builder.Property(x => x.Value);
        }
    }
}