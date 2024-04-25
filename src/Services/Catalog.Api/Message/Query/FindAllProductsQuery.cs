using Catalog.Api.Domain;
using Crosscutting.CQRS.Domain;

namespace Catalog.Api.Message.Query
{
    public class FindAllProductsQuery : IQuery<FindAllProductsQueryResponse>
    {
    }

    public record FindAllProductsQueryResponse(List<Product> Products);
}
