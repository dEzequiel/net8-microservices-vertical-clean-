using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Features.FindProductsBetweenPrices
{
    public record FindAllProductsByCategoryResponse(IEnumerable<ProductDetailsDTO> products);
    public class FindProductsBetweenPricesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/prices", async ([FromQuery(Name = "minimalPrice")] decimal minimalPrice, 
                                                   [FromQuery(Name = "maxPrice")] decimal maxPrice, 
                                                   ISender _mediator) =>
            {
                var query = new FindAllProductsBetweenPricesQuery(minimalPrice, maxPrice);
                var result = await _mediator.Send(query);
                var response = new FindAllProductsByCategoryResponse(result.products);
                return Results.Ok(response);
            });
        }
    }
}
