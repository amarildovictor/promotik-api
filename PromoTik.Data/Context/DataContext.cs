using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PromoTik.Data.Mapping;
using PromoTik.Data.Mapping.Scheduled;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Entities.Auth;
using PromoTik.Domain.Entities.Scheduled;

namespace PromoTik.Data.Context
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<PublishChatMessage>? PublishChatMessage { get; set; }

        public DbSet<PublishingChannel>? PublishingChannel { get; set; }

        public DbSet<PublishingChannelParameter>? PublishingChannelParameters { get; set; }

        public DbSet<PublishingApp>? PublishingApps { get; set; }

        public DbSet<Warehouse>? Warehouse { get; set; }

        public DbSet<PublishChatMessage_PublishingChannel>? PublishChatMessage_PublishingChannels { get; set; }

        public DbSet<PublishChatMessage_Warehouse>? publishChatMessage_Warehouses { get; set; }

        public DbSet<GeneralConfiguration>? GeneralConfigurations { get; set; }

        public DbSet<LineExecution>? LineExecutions { get; set; }

        public DbSet<ScheduledLineExecution>? ScheduledLineExecutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PublishChatMessageMap());
            modelBuilder.ApplyConfiguration(new PublishChatMessage_PublishingAppMap());
            modelBuilder.ApplyConfiguration(new PublishChatMessage_WarehouseMap());
            modelBuilder.ApplyConfiguration(new PublishingChannelMap());
            modelBuilder.ApplyConfiguration(new PublishingChannelParametersMap());
            modelBuilder.ApplyConfiguration(new PublishingAppMap());
            modelBuilder.ApplyConfiguration(new WarehouseMap());
            modelBuilder.ApplyConfiguration(new GeneralConfigurationMap());
            modelBuilder.ApplyConfiguration(new LineExecutionMap());
            modelBuilder.ApplyConfiguration(new ScheduledLineExecutionMap());
        }
    }
}