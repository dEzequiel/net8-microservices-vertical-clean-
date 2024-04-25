using Crosscutting.CQRS.Domain;

namespace Catalog.Api.Message.Command
{
    public class DeleteProductCommand : ICommand<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }

    public record DeleteProductCommandResponse(bool IsSuccess);
}
