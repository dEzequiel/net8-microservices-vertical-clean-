using Catalog.Api.Domain.Enums;

namespace IntegrationTest.Catalog.Endpoints
{
    public class DeleteProductEndpoint_IntegrationTest : BaseIntegrationTest
    {
        public DeleteProductEndpoint_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Theory]
        [AutoMoqData]
        public async Task DeleteProductEndpoint_ReturnsResponseAndStatusCode204_IntegrationTest(Product productToAdd)
        {
            // Arrange
            Product prod = new Product(Guid.NewGuid(), productToAdd.Name, productToAdd.Description, productToAdd.ProductCategoryId, (int)ProductCategories.Computer);

            _dbContext.Products.Add(prod);
            _dbContext.SaveChanges();
            _dbContext.Entry(prod).State = EntityState.Detached;

            var deleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"/products/{prod.Id}");

            // Act
            var response = await _client.DeleteAsync(deleteRequest.RequestUri);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
