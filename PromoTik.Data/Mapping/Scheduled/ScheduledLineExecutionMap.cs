using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoTik.Domain.Entities.Scheduled;

namespace PromoTik.Data.Mapping.Scheduled
{
    public class ScheduledLineExecutionMap : IEntityTypeConfiguration<ScheduledLineExecution>
    {
        public void Configure(EntityTypeBuilder<ScheduledLineExecution> builder)
        {
            builder.ToTable("SCHEDULED_LINE_EXECUTION");

            builder.HasKey(x => x.ID);

            builder.HasOne(x => x.LineExecution);

            builder.Property(x => x.ScheduledDateTime);
        }
    }
}