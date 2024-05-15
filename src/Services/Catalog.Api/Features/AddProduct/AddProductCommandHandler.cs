using Catalog.Api.Data;
using Catalog.Api.Data.Repositories;
using Catalog.Api.Domain;
using Catalog.Api.Domain.Enums;
using Catalog.Api.Message.Command;
using Crosscutting.CQRS.Infrastructure;

namespace Catalog.Api.Features.AddProduct
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand, AddProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository) =>
            _productRepository = productRepository;
        

        public async Task<AddProductCommandResponse> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(Guid.NewGuid(), command.Name, command.Description, command.Price, (int)command.ProductCategory);
            
            _productRepository.InsertProduct(product);
            _productRepository.Save();

            var response = new AddProductCommandResponse(product.Id);
            return response;
        }
    }
}
