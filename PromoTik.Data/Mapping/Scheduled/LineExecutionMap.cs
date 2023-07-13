using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities.Scheduled;

namespace PromoTik.Data.Mapping.Scheduled
{
    public class LineExecutionMap : IEntityTypeConfiguration<LineExecution>
    {
        public void Configure(EntityTypeBuilder<LineExecution> builder)
        {
            builder.ToTable("LINE_EXECUTION");

            builder.HasKey(x => x.ID);

            builder.HasOne(x => x.PublishChatMessage);

            builder.Property(x => x.CreationDate);
            builder.Property(x => x.ExecutionDate);
            builder.Property(x => x.Type);
        }
    }
}