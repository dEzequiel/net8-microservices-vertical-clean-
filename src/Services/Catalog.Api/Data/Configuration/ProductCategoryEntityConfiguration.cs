using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Catalog.Api.Data.Configuration
{
    public class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(nameof(ProductCategory)).HasKey(p => p.Id);

            builder.HasData(Enum.GetValues(typeof(ProductCategories))
                .Cast<ProductCategories>()
                .Select(e => new ProductCategory((int)e, e.ToString())));
        }
    }
}
