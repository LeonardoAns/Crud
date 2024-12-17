using Crud.Domain.Entities;

namespace Crud.Infrastructure.DbContext;

using Microsoft.EntityFrameworkCore;

public class CrudDbContext : DbContext {

    public DbSet<User> Users{ get; set; }
    public DbSet<Category> Categories{ get; set; }
    public DbSet<Product> Products{ get; set; }

    public CrudDbContext(DbContextOptions<CrudDbContext> options)
        : base(options){
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasOne(c => c.User)
            .WithMany(u => u.Categories)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}