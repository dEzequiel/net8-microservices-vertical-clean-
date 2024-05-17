namespace Catalog.Api.Features.FindProductsBetweenPrices
{
    public class FindProductsBetweenPricesQueryHandler : IQueryHandler<FindAllProductsBetweenPricesQuery, FindAllProductsBetweenPricesQueryResponse>
    {
        private readonly IProductRepository _productRepository;

        public FindProductsBetweenPricesQueryHandler(IProductRepository productRepository) =>
            _productRepository = productRepository;

        public async Task<FindAllProductsBetweenPricesQueryResponse> Handle(FindAllProductsBetweenPricesQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsBetweenPrices(request.MinPrice, request.MaxPrice, cancellationToken);
            var result = products.Adapt<IReadOnlyCollection<ProductDetailsDTO>>();
            var response = new FindAllProductsBetweenPricesQueryResponse(result);
            return response;
        }
    }
}
