using Catalog.Api.Domain;
using Crosscutting.CQRS.Domain;

namespace Catalog.Api.Message.Command
{
    public class AddProductCommand : ICommand<AddProductCommandResponse>
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public List<string>? Categories { get; private set; }
        public decimal Price { get; private set; }

        public AddProductCommand(string name, string? description, List<string>? categories, decimal price)
        {
            Name = name;
            Description = description;
            Categories = categories;
            Price = price;
        }
    }

    public record AddProductCommandResponse(Guid Id);
}
