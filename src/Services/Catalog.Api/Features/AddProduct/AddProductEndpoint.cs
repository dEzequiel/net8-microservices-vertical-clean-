namespace Catalog.Api.Features.AddProduct
{
    public record AddProductRequest(string name, string? description, decimal price, int productCategory);
    public record AddProductResponse(Guid Id);
    public class AddProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (AddProductRequest request, ISender _mediator) =>
            {
                var command = new AddProductCommand(request.name, request.description, request.price, (ProductCategories)request.productCategory);
                var result = await _mediator.Send(command);
                var response = new AddProductResponse(result.Id);
                return Results.Created($"/products/{response.Id}", response);
            });
        }
    }
}
