using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities;

namespace PromoTik.Data.Mapping
{
    public class PublishChatMessage_PublishingAppMap : IEntityTypeConfiguration<PublishChatMessage_PublishingApp>
    {
        public void Configure(EntityTypeBuilder<PublishChatMessage_PublishingApp> builder)
        {
            builder.ToTable("PUBLISHCHATMESSAGE_PUBLISHINGAPP");

            builder.HasKey(x => new { x.PublishChatMessageID, x.PublishingAppID });

            builder.HasOne(x => x.PublishChatMessage).WithMany(m => m.PublishingApps).HasForeignKey(f => f.PublishChatMessageID);
            builder.HasOne(x => x.PublishingApp).WithMany(m => m.PublishChatMessages).HasForeignKey(f => f.PublishingAppID);
        }
    }
}