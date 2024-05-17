using Catalog.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Catalog.Handlers
{
    public class FindAllProductsBetweenPricesQueryHandler_IntegrationTest : BaseIntegrationTest
    {
        public FindAllProductsBetweenPricesQueryHandler_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }


        [Fact]
        public async Task FindAllProductsBetweenPricesQueryHandler_ShouldReturnResponse_IntegrationTest()
        {
            // Arrange
            decimal minPrice = 160;
            decimal maxPrice = 350;
            FindAllProductsBetweenPricesQuery query = new FindAllProductsBetweenPricesQuery(minPrice, maxPrice);

            // Act
            var result = await _sender.Send(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.products);
            Assert.All(result.products, prod => Assert.IsType<ProductDetailsDTO>(prod));

            var allBetweenPrices = result.products.Select(p => p.price)
                .All(prc => prc >= minPrice && prc <= maxPrice);

            Assert.True(allBetweenPrices, $"Not al products prices are between {minPrice} and {maxPrice}");

        }
    }
}
