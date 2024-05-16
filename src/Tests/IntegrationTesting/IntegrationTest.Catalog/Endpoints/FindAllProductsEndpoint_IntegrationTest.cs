namespace IntegrationTest.Catalog.Endpoints
{
    public class FindAllProductsEndpoint_IntegrationTest : BaseIntegrationTest
    {
        public FindAllProductsEndpoint_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task FindAllProductsEndpoints_ReturnsResponseAndStatusCode200_IntegrationTest()
        {
            // Arrange
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "/products");

            // Act
            var response = await _client.SendAsync(getRequest);
            var responseString = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? productsToken = jsonResponse.SelectToken("products");

            if(productsToken == null)
                Assert.Fail("Products key in json response not found.");

            var products = productsToken.ToObject<IEnumerable<Product>>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
