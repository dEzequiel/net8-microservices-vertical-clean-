using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Catalog.Api.Data.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product)).HasKey(p => p.Id);

            builder.HasOne(e => e.ProductCategory)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.ProductCategoryId)
                .IsRequired();

            builder.Navigation(e => e.ProductCategory).AutoInclude();
        }
    }
}
