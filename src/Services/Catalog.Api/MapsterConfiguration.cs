namespace Catalog.Api
{
    public static class MapsterConfiguration
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Product, ProductDetailsDTO>
            .NewConfig().Map(dest => dest.category, src => src.ProductCategory);

            TypeAdapterConfig<Product, ProductDTO>
                .NewConfig().Map(dest => dest.category, src => src.ProductCategory.Name);

            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        }
    }
}

