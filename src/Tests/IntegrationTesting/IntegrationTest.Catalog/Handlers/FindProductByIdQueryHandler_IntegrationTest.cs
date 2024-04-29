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
            var productId = InitialData.Products.First().Id;
            FindProductByIdQuery query = new FindProductByIdQuery(productId);

            // Act
            var result = await _sender.Send(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Product);
            Assert.IsType<Product>(result.Product);

        }
    }
}
