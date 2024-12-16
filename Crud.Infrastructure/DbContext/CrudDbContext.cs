using Crud.Domain.Entities;

namespace Crud.Infrastructure.DbContext;

using Microsoft.EntityFrameworkCore;

public class CrudDbContext : DbContext{
    
    public CrudDbContext(DbContextOptions options) : base(options){
    }

    public DbSet<Category> Categories{ get; set; }
    public DbSet<Product> Products{ get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)           
            .WithMany(c => c.Products)         
            .HasForeignKey(p => p.CategoryId)  
            .OnDelete(DeleteBehavior.Cascade); 
    }
}