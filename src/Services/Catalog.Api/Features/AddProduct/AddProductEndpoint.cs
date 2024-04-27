using Carter;
using Catalog.Api.Domain;
using Catalog.Api.Message.Command;
using MediatR;

namespace Catalog.Api.Features.AddProduct
{
    public record AddProductRequest(string name, string? description, List<string>? categories, decimal price);
    public record AddProductResponse(Guid Id);
    public class AddProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (AddProductRequest request, ISender _mediator) =>
            {
                var command = new AddProductCommand(request.name, request.description, request.categories, request.price);
                var result = await _mediator.Send(command);
                var response = new AddProductResponse(result.Id);
                return Results.Created($"/products/{response.Id}", response);
            });
        }
    }
}
