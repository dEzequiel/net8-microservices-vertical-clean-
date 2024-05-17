namespace Catalog.Api.Features.DeleteProduct
{
    public record DeleteProductResponse(bool isSucess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender _mediator) =>
            {
                var command = new DeleteProductCommand(id);
                var result = await _mediator.Send(command);
                var response = new DeleteProductResponse(result.IsSuccess);
                return Results.NoContent();
            });
        }
    }
}
