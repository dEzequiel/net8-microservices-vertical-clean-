using Catalog.Api.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Catalog.Api.Domain.Enums;

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
