namespace Catalog.Api.Features.FindProductById
{
    public class FindProductByIdQueryHandler : IQueryHandler<FindProductByIdQuery, FindProductByIdQueryResponse>
    {
        private readonly IProductRepository _productRepository;

        public FindProductByIdQueryHandler(IProductRepository productRepository) =>
            _productRepository = productRepository;


        public async Task<FindProductByIdQueryResponse> Handle(FindProductByIdQuery query, CancellationToken cancellationToken)
        {
            var id = query.Id;
            var product = _productRepository.GetProductById(id);

            if (product is null)
                throw new NullReferenceException();

            var result = product.Adapt<ProductDTO>();
            var response = new FindProductByIdQueryResponse(result);
            return response;
        }
    }
}
