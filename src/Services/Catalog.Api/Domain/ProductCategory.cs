namespace Catalog.Api.Domain
{
    public class ProductCategory 
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public virtual ICollection<Product> Products { get; } = new List<Product>();

        public ProductCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
