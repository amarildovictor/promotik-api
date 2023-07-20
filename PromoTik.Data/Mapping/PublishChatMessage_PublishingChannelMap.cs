using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities;

namespace PromoTik.Data.Mapping
{
    public class PublishChatMessage_PublishingChannelMap : IEntityTypeConfiguration<PublishChatMessage_PublishingChannel>
    {
        public void Configure(EntityTypeBuilder<PublishChatMessage_PublishingChannel> builder)
        {
            builder.ToTable("PUBLISHCHATMESSAGE_PUBLISHINGCHANNEL");

            builder.HasKey(x => new { x.PublishChatMessageID, x.PublishingChannelID });

            builder.HasOne(x => x.PublishChatMessage).WithMany(m => m.PublishingChannels).HasForeignKey(f => f.PublishChatMessageID);
            builder.HasOne(x => x.PublishingChannel).WithMany(m => m.PublishChatMessages).HasForeignKey(f => f.PublishingChannelID);
        }
    }
}