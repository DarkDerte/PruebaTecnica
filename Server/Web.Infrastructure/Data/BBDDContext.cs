using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;

namespace Api.Infrastructure.Data
{
    public class BBDDContext : DbContext
    {
        public BBDDContext(DbContextOptions<BBDDContext> options) : base(options) { }

        public DbSet<ContractEntity> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
            });
        }
    }
}
