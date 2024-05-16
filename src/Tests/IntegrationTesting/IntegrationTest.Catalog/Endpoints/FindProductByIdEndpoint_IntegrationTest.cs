using Catalog.Api.DTOs;

namespace IntegrationTest.Catalog.Endpoints
{
    public class FindProductByIdEndpoint_IntegrationTest : BaseIntegrationTest
    {
        public FindProductByIdEndpoint_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task FindProductByIdEndpoint_ReturnsResponseAndStatusCode200_IntegrationTest()
        {
            // Arrange
            var productId = InitialData.Products.First().Id;
            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"/products/{productId}");

            // Act
            var response = await _client.SendAsync(getRequest);
            var responseString = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? productToken = jsonResponse.SelectToken("product");

            if (productToken == null)
                Assert.Fail("Product key in json response not found.");

            var product = productToken.ToObject<ProductDTO>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
