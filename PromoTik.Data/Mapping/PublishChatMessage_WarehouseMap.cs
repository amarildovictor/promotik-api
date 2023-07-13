using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities;

namespace PromoTik.Data.Mapping
{
    public class PublishChatMessage_WarehouseMap : IEntityTypeConfiguration<PublishChatMessage_Warehouse>
    {
        public void Configure(EntityTypeBuilder<PublishChatMessage_Warehouse> builder)
        {
            builder.ToTable("PUBLISHCHATMESSAGE_WAREHOUSE");

            builder.HasKey(x => new { x.PublishChatMessageID, x.WarehouseID });

            builder.HasOne(x => x.PublishChatMessage).WithMany(m => m.Warehouses).HasForeignKey(f => f.PublishChatMessageID);
            builder.HasOne(x => x.Warehouse).WithMany(m => m.PublishChatMessages).HasForeignKey(f => f.WarehouseID);
        }
    }
}