using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities;

namespace PromoTik.Data.Mapping
{
    public class PublishingChannelMap : IEntityTypeConfiguration<PublishingChannel>
    {
        public void Configure(EntityTypeBuilder<PublishingChannel> builder)
        {
            builder.ToTable("PUBLISHING_CHANNEL");

            builder.HasKey(x => x.ID);
            builder.Navigation(x => x.PublishingApp);
            builder.Navigation(x => x.PublishingChannelParameters);

            builder.Property(x => x.Description).HasMaxLength(256);
            builder.Property(x => x.Channel_ID).HasMaxLength(256);
            builder.Property(x => x.Country);
        }
    }
}