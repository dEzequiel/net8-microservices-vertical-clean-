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
            var result = products.Adapt<IEnumerable<ProductDetailsDTO>>();
            var response = new FindAllProductsQueryResponse(result) ;
            return response;
        }
    }
}
