﻿namespace Catalog.Api.Domain
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int ProductCategoryId { get; private set; }
        public virtual ProductCategory ProductCategory { get; private set; } = null!;

        public Product(Guid id, string name, string? description, decimal price, int productCategoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ProductCategoryId = productCategoryId;
        }

    }
}
