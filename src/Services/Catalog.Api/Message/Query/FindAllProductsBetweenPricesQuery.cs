using Catalog.Api.DTOs;
using Crosscutting.CQRS.Domain;

namespace Catalog.Api.Message.Query
{
    public class FindAllProductsBetweenPricesQuery : IQuery<FindAllProductsBetweenPricesQueryResponse>
    {
        public decimal MinPrice {  get; private set; }
        public decimal MaxPrice {  get; private set; }

        public FindAllProductsBetweenPricesQuery(decimal minPrice, decimal maxPrice)
        {
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }
    }

    public record FindAllProductsBetweenPricesQueryResponse(IEnumerable<ProductDetailsDTO> products) { }
}
