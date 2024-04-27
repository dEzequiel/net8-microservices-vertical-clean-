using Catalog.Api.Data;
using Catalog.Api.Message.Query;
using Crosscutting.CQRS.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Features.FindAllProducts
{
    public class FindAllProductsQueryHandler : IQueryHandler<FindAllProductsQuery, FindAllProductsQueryResponse>
    {
        private readonly DatabaseContext _databaseContext;

        public FindAllProductsQueryHandler(DatabaseContext databaseContext) =>
            _databaseContext = databaseContext;


        public async Task<FindAllProductsQueryResponse> Handle(FindAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _databaseContext.Products.AsNoTracking().ToListAsync(cancellationToken);    
            var response = new FindAllProductsQueryResponse(products);
            return response;
        }
    }
}
