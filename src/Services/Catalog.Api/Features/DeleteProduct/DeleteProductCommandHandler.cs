using Catalog.Api.Data.Repositories;
using Catalog.Api.Message.Command;
using Crosscutting.CQRS.Infrastructure;

namespace Catalog.Api.Features.DeleteProduct
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository) =>
            _productRepository = productRepository;

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _productRepository.DeleteProduct(request.Id);
                _productRepository.Save();
                return new DeleteProductCommandResponse(true);
            }
            catch (Exception ex)
            {
                return new DeleteProductCommandResponse(false);
            }
        }
    }
}
