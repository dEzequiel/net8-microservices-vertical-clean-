using Catalog.Api.Data.Repositories;
using Catalog.Api.DTOs;
using Catalog.Api.Message.Query;
using Crosscutting.CQRS.Infrastructure;
using Mapster;

namespace Catalog.Api.Features.FindProductsByCategory
{
    public class FindProductsByCategoryQueryHandler : IQueryHandler<FindAllProductsByCategoryQuery, FindAllProductsByCategoryQueryResponse>
    {
        private readonly IProductRepository _productRepository;

        public FindProductsByCategoryQueryHandler(IProductRepository productRepository) =>
            _productRepository = productRepository;


        public async Task<FindAllProductsByCategoryQueryResponse> Handle(FindAllProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByCategory(request.ProductCategoryIds, cancellationToken);
            var result = products.Adapt<IReadOnlyCollection<ProductDTO>>();
            var response = new FindAllProductsByCategoryQueryResponse(result);
            return response;
        }
    }
}
