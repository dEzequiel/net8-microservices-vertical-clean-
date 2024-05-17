namespace Catalog.Api.Message.Query
{
    public class FindAllProductsQuery : IQuery<FindAllProductsQueryResponse>
    {
    }

    public record FindAllProductsQueryResponse(IEnumerable<ProductDetailsDTO> Products);
}
