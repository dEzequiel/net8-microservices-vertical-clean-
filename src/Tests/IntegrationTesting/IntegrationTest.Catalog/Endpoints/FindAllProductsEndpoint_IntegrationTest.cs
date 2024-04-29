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
            var result = await _client.SendAsync(getRequest);
            var responseString = await result.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseString);
            JToken? productsToken = jsonResponse.SelectToken("products");

            if(productsToken == null)
                Assert.Fail("Products key in json response not found.");

            var products = productsToken.ToObject<IEnumerable<Product>>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(result);
            Assert.NotEmpty(products);
            var testDbTotalEntities = _dbContext.Products.Count();
            Assert.Equal(testDbTotalEntities, products.Count());
        }
    }
}
