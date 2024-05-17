namespace Catalog.Api.Features.FindProductsByCategory
{
    public record FindAllProductsByCategoryRequest(IEnumerable<int> productCategoryIds);
    public record FindAllProductsByCategoryResponse(IEnumerable<ProductDTO> products);
    public class FindProductsByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products/categories", async (FindAllProductsByCategoryRequest request, ISender _mediator) =>
            {
                var query = new FindAllProductsByCategoryQuery(request.productCategoryIds);
                var result = await _mediator.Send(query);
                var response = new FindAllProductsByCategoryResponse(result.Products);
                return Results.Ok(response);
            });
        }
    }
}
