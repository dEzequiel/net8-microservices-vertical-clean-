using Crosscutting.CQRS.Domain;

namespace Catalog.Api.Message.Command
{
    public class DeleteProductCommand : ICommand<DeleteProductCommandResponse>
    {
        public Guid Id { get; private set; }

        public DeleteProductCommand(Guid id) =>
            Id = id;
        
    }

    public record DeleteProductCommandResponse(bool IsSuccess);
}
