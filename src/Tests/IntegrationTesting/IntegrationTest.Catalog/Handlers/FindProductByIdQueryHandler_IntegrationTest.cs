using Catalog.Api.DTOs;

namespace IntegrationTest.Catalog.Handlers
{
    public class FindProductByIdQueryHandler_IntegrationTest : BaseIntegrationTest
    {
        public FindProductByIdQueryHandler_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task FindProductByIdQueryHandler_ShouldReturnsResponse_IntegrationTest()
        {
            // Arrange
            var product = InitialData.Products.First();
            FindProductByIdQuery query = new FindProductByIdQuery(product.Id);

            // Act
            var result = await _sender.Send(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Product);
            Assert.Equal(product.Id, result.Product.id);
            Assert.IsType<ProductDTO>(result.Product);

        }
    }
}
