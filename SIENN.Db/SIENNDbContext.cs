using Microsoft.EntityFrameworkCore;
using SIENN.Models;

namespace SIENN.Db
{
    public class SIENNDbContext: DbContext
    {
        public SIENNDbContext(DbContextOptions<SIENNDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategoryEntity>()
                        .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategoryEntity>()
                        .HasOne<ProductEntity>(pc => pc.Product)
                        .WithMany(p => p.ProductCategories)
                        .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategoryEntity>()
                        .HasOne<CategoryEntity>(pc => pc.Category)
                        .WithMany(c => c.ProductCategories)
                        .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<TypeEntity>()
                        .HasMany(t => t.Products)
                        .WithOne(p => p.Type);
            
            modelBuilder.Entity<UnitEntity>()
                        .HasMany<ProductEntity>(u => u.Products)
                        .WithOne(p => p.Unit)
                        .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<TypeEntity> Types { get; set; }
        public DbSet<UnitEntity> Units { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    }
}
