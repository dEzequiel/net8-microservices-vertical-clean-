using Catalog.Api.Data;
using Catalog.Api.Data.Repositories;
using Catalog.Api.Message.Query;
using Crosscutting.CQRS.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Features.FindAllProducts
{
    public class FindAllProductsQueryHandler : IQueryHandler<FindAllProductsQuery, FindAllProductsQueryResponse>
    {
        private readonly IProductRepository _productRepository;

        public FindAllProductsQueryHandler(IProductRepository productRepository) =>
            _productRepository = productRepository;

        public async Task<FindAllProductsQueryResponse> Handle(FindAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProducts(cancellationToken);
            var response = new FindAllProductsQueryResponse(products.ToList()) ;
            return response;
        }
    }
}
