using Catalog.Api.Data;
using Catalog.Api.Domain;
using Catalog.Api.Message.Command;
using Crosscutting.CQRS.Infrastructure;

namespace Catalog.Api.Features.AddProduct
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand, AddProductCommandResponse>
    {
        private readonly DatabaseContext _dbContext;

        public AddProductCommandHandler(DatabaseContext dbContext) =>
            _dbContext = dbContext;
        

        public async Task<AddProductCommandResponse> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(Guid.NewGuid(), command.Name, command.Description, command.Categories, command.Price);
            
            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            var response = new AddProductCommandResponse(product.Id);
            return response;
        }
    }
}
