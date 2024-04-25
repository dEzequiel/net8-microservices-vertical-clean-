using Carter;
using Catalog.Api.Domain;
using Catalog.Api.Message.Query;
using MediatR;

namespace Catalog.Api.Features.FindProductById
{
    public record FindProductByIdResponse(Product Product);
    public class FindProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender _mediator) =>
            {
                var query = new FindProductByIdQuery(id);
                var result = await _mediator.Send(query);
                var response = new FindProductByIdResponse(result.Product);
                return Results.Ok(response);
            });
        }
    }
}
