using Claps.ProductCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Claps.ProductCatalog.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(p => p.Description)
                .HasMaxLength(1000);

            entity.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            entity.Property(p => p.Category)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Status)
                .IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}
