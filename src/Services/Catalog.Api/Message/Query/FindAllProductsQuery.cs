using Catalog.Api.Domain;
using Catalog.Api.DTOs;
using Crosscutting.CQRS.Domain;

namespace Catalog.Api.Message.Query
{
    public class FindAllProductsQuery : IQuery<FindAllProductsQueryResponse>
    {
    }

    public record FindAllProductsQueryResponse(IEnumerable<ProductDetailsDTO> Products);
}
