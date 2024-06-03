namespace Catalog.Api.Domain
{
    public class Product
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int ProductCategoryId { get; private set; }
        public ProductCategory ProductCategory { get; private set; } = null!;

        public Product(Guid id, Guid userId, string name, string? description, decimal price, int productCategoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ProductCategoryId = productCategoryId;
            UserId = userId;
        }

    }
}
