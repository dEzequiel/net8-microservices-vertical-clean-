namespace Catalog.Api.DTOs
{
    public record ProductDTO(Guid id, string name, string? description, decimal price, string category);
    public record ProductDetailsDTO(Guid id, string name, string? description, decimal price, ProductCategoryDTO category);

}
