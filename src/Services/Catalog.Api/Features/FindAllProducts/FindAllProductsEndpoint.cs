namespace Catalog.Api.Features.FindAllProducts
{
    public record FindAllProductsResponse(IEnumerable<ProductDetailsDTO> Products);
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
