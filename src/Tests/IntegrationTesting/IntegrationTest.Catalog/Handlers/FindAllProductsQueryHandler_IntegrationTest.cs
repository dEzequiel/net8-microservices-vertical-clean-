using Catalog.Api.DTOs;

namespace IntegrationTest.Catalog.Handlers
{
    public class FindAllProductsQueryHandler_IntegrationTest : BaseIntegrationTest
    {
        public FindAllProductsQueryHandler_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task FindAllProductsQueryHandler_ShouldReturnsResponse_IntegrationTest()
        {
            // Arrange
            var query = new FindAllProductsQuery();

            // Act
            var result = await _sender.Send(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Products);
            Assert.All(result.Products, prod => Assert.IsType<ProductDetailsDTO>(prod));
        }
    }
}
