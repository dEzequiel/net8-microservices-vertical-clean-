using Catalog.Api.DTOs;
using Crosscutting.CQRS.Domain;

namespace Catalog.Api.Message.Query
{
    public class FindAllProductsByCategoryQuery : IQuery<FindAllProductsByCategoryQueryResponse>
    {
        public IEnumerable<int> ProductCategoryIds { get; private set; }

        public FindAllProductsByCategoryQuery(IEnumerable<int> productCategoryId) =>
            ProductCategoryIds = productCategoryId;
        
    }

    public record FindAllProductsByCategoryQueryResponse(IEnumerable<ProductDTO> Products) { }
}
