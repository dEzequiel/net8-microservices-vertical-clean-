using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductEntityConfiguration().Configure(modelBuilder.Entity<Product>());
            new ProductCategoryEntityConfiguration().Configure(modelBuilder.Entity<ProductCategory>());

        }
    }
}
