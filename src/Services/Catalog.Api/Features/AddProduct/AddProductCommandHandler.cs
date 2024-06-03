using Catalog.Api.Services;

namespace Catalog.Api.Features.AddProduct
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand, AddProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserProvider _userProvider;

        public AddProductCommandHandler(IProductRepository productRepository, IUserProvider userProvider)
        {
            _productRepository = productRepository;
            _userProvider = userProvider;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var userId = _userProvider.GetUserId();
            var product = new Product(Guid.NewGuid(), userId, command.Name, command.Description, command.Price, (int)command.ProductCategory);
            
            _productRepository.InsertProduct(product);
            _productRepository.Save();

            var response = new AddProductCommandResponse(product.Id);
            return response;
        }
    }
}
