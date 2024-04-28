using Catalog.Api.Domain;

namespace Catalog.Api.Data.Repositories
{
    public interface IProductRepository : IDisposable
    {
        Task<IEnumerable<Product>> GetProducts(CancellationToken ct = default);
        Product GetProductById(Guid Id);
        void InsertProduct(Product Product);
        void DeleteProduct(Guid ProductId);
        void UpdateProduct(Product Product);
        void Save();
    }
}
