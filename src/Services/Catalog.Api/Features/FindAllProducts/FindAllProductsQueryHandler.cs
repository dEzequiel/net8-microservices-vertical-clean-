using Catalog.Api.Data.Repositories;
using Catalog.Api.DTOs;
using Catalog.Api.Message.Query;
using Crosscutting.CQRS.Infrastructure;
using Mapster;

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
            var result = products.Adapt<IReadOnlyCollection<ProductDetailsDTO>>();
            var response = new FindAllProductsQueryResponse(result) ;
            return response;
        }
    }
}
