namespace Catalog.Api.Message.Query
{
    public class FindProductByIdQuery : IQuery<FindProductByIdQueryResponse>
    {
        public Guid Id { get; private set; }
        public FindProductByIdQuery(Guid id) => Id = id;
    }

    public record FindProductByIdQueryResponse(ProductDTO Product);
}
