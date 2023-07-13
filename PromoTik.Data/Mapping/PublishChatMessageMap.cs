using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities;

namespace PromoTik.Data.Mapping
{
    public class PublishChatMessageMap : IEntityTypeConfiguration<PublishChatMessage>
    {
        public void Configure(EntityTypeBuilder<PublishChatMessage> builder)
        {
            builder.ToTable("PUBLISH_CHAT_MESSAGE");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ImageLink);
            builder.Property(x => x.Title);
            builder.Property(x => x.ValueWithouDiscount).HasPrecision(10,2);
            builder.Property(x => x.Value).HasPrecision(10,2);
            builder.Property(x => x.Coupon);
            builder.Property(x => x.Link);
            builder.Property(x => x.ShortLink);
            builder.Property(x => x.AditionalMessage);
        }
    }
}