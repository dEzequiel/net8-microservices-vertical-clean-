using Catalog.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Data.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DatabaseContext context;

        public ProductRepository(DatabaseContext context) =>
            this.context = context;

        public void DeleteProduct(Guid ProductId) =>
            context.Products.Remove(GetProductById(ProductId));

        public Product GetProductById(Guid Id) =>
            context.Products.AsNoTracking().First(x => x.Id == Id);


        public async Task<IEnumerable<Product>> GetProducts(CancellationToken ct = default) =>
            await context.Products.AsNoTracking().ToListAsync(ct);

        public void InsertProduct(Product Product) =>
            context.Products.Add(Product);

        public void Save() =>
            context.SaveChanges();

        public void UpdateProduct(Product Product) =>
            context.Products.Update(Product);

        public async Task<IEnumerable<Product>> GetProductsByCategory(IEnumerable<int> productCategoriesIds, CancellationToken ct = default) =>
            await context.Products.AsNoTracking().Where(x => productCategoriesIds.Contains(x.ProductCategoryId)).ToListAsync(ct);

        public async Task<IEnumerable<Product>> GetProductsBetweenPrices(decimal minPrice, decimal maxPrice, CancellationToken ct = default) =>
            await context.Products.AsNoTracking().Where(x => x.Price <= maxPrice && x.Price >= minPrice).ToListAsync(ct);

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
