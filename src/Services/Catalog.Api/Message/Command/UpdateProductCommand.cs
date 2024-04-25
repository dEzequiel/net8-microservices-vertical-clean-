using Crosscutting.CQRS.Domain;

namespace Catalog.Api.Message.Command
{
    public class UpdateProductCommand : ICommand<UpdateProductCommandResponse>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public List<string>? Categories { get; private set; }
        public decimal Price { get; private set; }

        public UpdateProductCommand(Guid id, string name, string? description, List<string>? categories, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Categories = categories;
            Price = price;
        }
    }

    public record UpdateProductCommandResponse(bool IsSuccess);
}
