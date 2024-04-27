using Carter;
using Catalog.Api.Domain;
using Catalog.Api.Message.Query;
using MediatR;

namespace Catalog.Api.Features.FindAllProducts
{
    public record FindAllProductsResponse(List<Product> Products);
    public class FindAllProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender _mediator) =>
            {
                var query = new FindAllProductsQuery();
                var result = await _mediator.Send(query);
                var response = new FindAllProductsResponse(result.Products);
                return Results.Ok(response);
            });
        }
    }
}
