namespace Catalog.Api.Domain
{
    public class ProductCategory 
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public virtual IEnumerable<Product> Products { get; }

        public ProductCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
