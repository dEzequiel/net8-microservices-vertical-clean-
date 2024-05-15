using Catalog.Api.Domain;
using Catalog.Api.Domain.Enums;
using Crosscutting.CQRS.Domain;

namespace Catalog.Api.Message.Command
{
    public class AddProductCommand : ICommand<AddProductCommandResponse>
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int ProductCategory { get; private set; }
        public decimal Price { get; private set; }

        public AddProductCommand(string name, string? description, decimal price, ProductCategories productCategory)
        {
            Name = name;
            Description = description;
            ProductCategory = (int)productCategory;
            Price = price;
        }
    }

    public record AddProductCommandResponse(Guid Id);
}
