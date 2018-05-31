using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORMBenchmark.Models.EFCore {
    public partial class EFCoreContext : DbContext {
        public virtual DbSet<EFCoreEntity> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if(!optionsBuilder.IsConfigured) {
                string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connstr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<EFCoreEntity>(entity => {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
            modelBuilder.Entity<EFCoreEntity>().ToTable("Entities");
        }
    }
}
